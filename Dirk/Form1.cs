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
        private Network DefaultNetworkForDebugging = new Network("irc.amazdong.com", 6667, new string[] { "#test", "#test2" });

        public Connection irc;

        #region Active State
        public string ActiveCategoryKey { get; set; }
        #endregion Active State

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

            // Add the message to the message_view
            AddMessageToMessageView(message_view, line);
        }

        private TreeNode FindOrCreateCategoryNodeByName(TreeNode server_node, string category) {
            if (TreeCategoryNodeLookup.ContainsKey(server_node.Text + '/' + category))
            {
                return TreeCategoryNodeLookup[server_node.Text + '/' + category];
            }
            else
            {
                TreeNode new_category_node = new TreeNode(category);
                TreeCategoryNodeLookup.Add(server_node.Text + '/' + category, new_category_node);

                treeChannels.Invoke((Action)delegate
                {
                    server_node.Nodes.Add(new_category_node);
                    server_node.Expand();
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
                    GridLines = true,
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

        private void SendIrcMessage()
        {
            string message = txtMessage.Text;

            if (message.StartsWith("/"))
            {
                ProcessClientAction(message);
            } else
            {
                // TODO replace this with sending a message to the active node's ingress
                irc.SendChannelMessage(ActiveCategoryKey.Split('/').Last<string>(), message);

                // TODO We also want to append our message to the active node's message view
                //AddMessageToTab(tabsWindowControl.SelectedTab, "<" + DefaultNick + "> " + message);
            }

            // And clear the input box
            txtMessage.Text = "";
        }

        private void ProcessClientAction(string message)
        {
            string[] message_parts = message.ToLower().Split(' ');
            switch(message_parts[0])
            {
                case "/join":
                    string channel_to_join = message_parts[1];
                    irc.JoinChannel(channel_to_join);

                    break;
            }
        }

        // TODO: We could (should?) probably just have a custom control that inherits from ListView, and have an AddMessage handler there
        private void AddMessageToMessageView(ListView message_view, string message)
        {
            string timestamp = DateTime.Now.ToString("hh:mm:ss");
            string person = ParseIRC.GetUsernameSpeaking(message);
            string formatted_line = ParseIRC.GetSpokenLine(message);

            // CODESMELL: It's pretty funky that we need to specify our first column's data in the ListViewItem constructor instead of as a Subitem...
            ListViewItem message_item = new ListViewItem(timestamp);
            message_item.SubItems.Add(person);
            if (ParseIRC.IsMessage(message))
            {
                message_item.SubItems.Add(formatted_line);
            }
            else
            {
                message_item.SubItems.Add(message);
            }

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

        private void treeChannels_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selected_node = e.Node;

            string node_key = selected_node.Text;
            TreeNode current_node = selected_node;
            while (current_node.Parent != null)
            {
                node_key = current_node.Parent.Text + '/' + node_key;
                current_node = current_node.Parent;
            }
            
            ShowCategoryView(node_key);
        }

        #endregion EventHandlers

        private void ShowCategoryView(string node_key)
        {
            // Hide the currently active category view
            if (ActiveCategoryKey != null && MessageListViewLookup.ContainsKey(ActiveCategoryKey))
            {
                MessageListViewLookup[ActiveCategoryKey].Hide();
            }

            // Show the new category view
            if (node_key != null && MessageListViewLookup.ContainsKey(node_key))
            {
                MessageListViewLookup[node_key].Show();

                // Track the new active view
                ActiveCategoryKey = node_key;
            }
        }
    }
}
