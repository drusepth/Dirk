using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIRC;
using DIRC.Models;

namespace Dirk
{

    public partial class FrmIrcWindow : Form
    {
        // TODO: replace these with some form that has users set up network/user later, but for now we cool
        private User DefaultUserForDebugging = new User("drusepth");
        private Network DefaultNetworkForDebugging = new Network("irc.amazdong.com", 6667, new string[] { "#test" });

        public Connection irc;

        #region LookupTables
        // O(1) lookup tables to avoid iterating over things to find other things

        // Index for this is <server>
        private Dictionary<string, TreeNode> TreeServerNodeLookup = new Dictionary<string, TreeNode>();

        // Index for this is in the form of a concatenated <server/category> string
        private Dictionary<string, TreeNode> TreeCategoryNodeLookup = new Dictionary<string, TreeNode>();

        // Index for this is in the form of a concatenated <server/category> string
        private Dictionary<string, ListView> MessageListViewLookup = new Dictionary<string, ListView>();
        #endregion

        private Dictionary<string, TabPage> TabWindows = new Dictionary<string, TabPage>();

        #region Startup
        public FrmIrcWindow()
        {
            InitializeComponent();
        }

        private void FrmIrcWindow_Load(object sender, EventArgs e)
        {
            // Create a top-level server node in the sidebar to organize everything for this server under
            TreeNode default_network = new TreeNode(DefaultNetworkForDebugging.Server);
            treeChannels.Nodes.Add(default_network);
            default_network.ExpandAll();

            // Save a reference to this node to add channels to later
            TreeServerNodeLookup.Add(DefaultNetworkForDebugging.Server, default_network);

            MessageBox.Show("Connecting to preconfigured server");
            irc = new Connection(DefaultUserForDebugging, DefaultNetworkForDebugging);
            irc.AddLineHandler(DrawGuiLineHandler);
            irc.Connect();
        }
        #endregion Startup

        private void DrawGuiLineHandler(string line)
        {
            // TODO we need to pass the server around whenever we support multiple simultaneous connections
            TreeNode server_node = TreeServerNodeLookup[DefaultNetworkForDebugging.Server];

            /// Create the category node if needed
            string line_category = ParseIRC.GetMessageWindowContext(line);
            TreeNode category_node = FindOrCreateCategoryNodeByName(server_node, line_category);

            // Create the category listview if needed
            ListView message_view = FindOrCreateCategoryListViewByName(server_node, category_node);
            //message_view.Invoke((Action)delegate
            //{
            //    message_view.Items.Add(line);
            //});

            // Add the message to the message_view
            AddMessageToMessageView(message_view, line);

            //TabPage tab = FindOrCreateTabPageByName(line_category);

            //AddMessageToTab(tab, LineFormatterService.FormatIncomingLine(line));
        }

        private TreeNode FindOrCreateCategoryNodeByName(TreeNode server_node, string category) {
            if (TreeCategoryNodeLookup.ContainsKey(server_node.Text + '/' + category))
            {
                return TreeCategoryNodeLookup[server_node.Text + '/' + category];
            } else
            {
                TreeNode new_category_node = new TreeNode(category);
                TreeCategoryNodeLookup.Add(server_node.Text + '/' + category, new_category_node);

                treeChannels.Invoke((Action)delegate
                {
                    server_node.Nodes.Add(new_category_node);
                });

                return new_category_node;
            }
        }

        private ListView FindOrCreateCategoryListViewByName(TreeNode server_node, TreeNode category_node)
        {
            if (MessageListViewLookup.ContainsKey(server_node.Text + '/' + category_node.Text))
            {
                return MessageListViewLookup[server_node.Text + '/' + category_node.Text];
            } else
            {
                ListView category_list_view = new ListView()
                {
                    Dock = DockStyle.Fill,
                    View = View.Details,
                    AllowColumnReorder = true,
                    //GridLines = true,
                    Sorting = SortOrder.Ascending,
                    FullRowSelect = true,
                    Scrollable = true
                };

                category_list_view.Columns.Add("Time");
                category_list_view.Columns.Add("User");
                category_list_view.Columns.Add("Message");

                // Add it to the lookup table for future reference
                MessageListViewLookup.Add(server_node.Text + '/' + category_node.Text, category_list_view);

                // Hide new views by default unless a user purposefully switches to them
                //category_list_view.Hide();

                // Add the new component to the main view
                splitContainerChatWindow.Invoke((Action)delegate
                {
                    splitContainerChatWindow.Panel2.Controls.Add(category_list_view);
                });

                return category_list_view;
            }
        }

        /*
        private TabPage FindOrCreateTabPageByName(string name)
        {
            if (TabWindows.Keys.Contains<string>(name))
            {
                // Return an existing tab
                return TabWindows[name];
            }
            else
            {
                // Create a new tab.
                TabPage tab = new TabPage();
                tab.Text = name;

                ListBox message_log = new ListBox
                {
                    Name = "MessageLog",
                    Dock = DockStyle.Fill,
                    SelectionMode = SelectionMode.MultiExtended,

                };

                tab.Controls.Add(message_log);
                TabWindows.Add(name, tab);
                tabsWindowControl.Invoke((Action)delegate
                {
                    tabsWindowControl.TabPages.Add(tab);
                });

                return tab;
            }
        }
        */

        private void SendIrcMessage()
        {
            string message = txtMessage.Text;

            // TODO replace this with sending a message to the active node's ingress
            irc.SendGlobalMessage(message);

            // TODO We also want to append our message to the active node's message view
            //AddMessageToTab(tabsWindowControl.SelectedTab, "<" + DefaultNick + "> " + message);

            // And clear the input box
            txtMessage.Text = "";
        }
        
        /*
        private void AddMessageToTab(TabPage tab, string line)
        {
            ListBox message_log = (ListBox)tab.Controls.Find("MessageLog", false)[0];

            message_log.Invoke((Action)delegate
            {
                message_log.Items.Add(line);
            });
        }
        */
        // TODO: We could (should?) probably just have a custom control that inherits from ListView, and have an AddMessage handler there
        private void AddMessageToMessageView(ListView message_view, string message)
        {
            // CODESMELL: It's pretty funky that we need to specify our first column's data in the ListViewItem constructor instead of as a Subitem...
            ListViewItem message_item = new ListViewItem("timestamp");
            message_item.SubItems.Add("person");
            message_item.SubItems.Add(message);

            message_view.Invoke((Action)delegate
            {
                message_view.Items.Add(message_item);
            });
        }

        #region EventHandlers
        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendIrcMessage();
            }
        }

        private void BtnMessageSend_Click(object sender, EventArgs e)
        {
            SendIrcMessage();
        }
        
        private void ShowUISandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sandbox = new frmUiSandbox();
            sandbox.Show();
        }

        #endregion EventHandlers
        
    }
}
