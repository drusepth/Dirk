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

namespace Dirk
{

    public partial class frmIrcWindow : Form
    {
        public static string DefaultNick = "drusepth";
        public static string IrcServer = "irc.amazdong.com";
        public static int IrcPort = 6667;
        public static string[] IrcChannels = new string[] { "#fj" };

        public Connection irc;

        private Dictionary<string, TabPage> TabWindows = new Dictionary<string, TabPage>();

        #region Startup
        public frmIrcWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Connecting to preconfigured server");
            irc = new Connection(DefaultNick, IrcServer, IrcPort);

            foreach (string default_channel in IrcChannels)
            {
                irc.AddChannel(default_channel);
            }

            //irc.AddLineHandler(GuiDisplayLineHandler.Draw);
            irc.AddLineHandler(DrawGuiLineHandler);
            
            irc.Connect();
        }
        #endregion Startup

        private void DrawGuiLineHandler(string line)
        {
            string line_category = ParseIRC.GetMessageWindowContext(line);
            TabPage tab = FindOrCreateTabPageByName(line_category);

            AddMessageToTab(tab, LineFormatterService.FormatIncomingLine(line));
        }

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

        private void SendIrcMessage()
        {
            string message = txtMessage.Text;
            irc.SendGlobalMessage(message);

            // We also want to append our message to the tab page
            AddMessageToTab(tabsWindowControl.SelectedTab, "<" + DefaultNick + "> " + message);

            // And clear the input box
            txtMessage.Text = "";
        }
        
        private void AddMessageToTab(TabPage tab, string line)
        {
            ListBox message_log = (ListBox)tab.Controls.Find("MessageLog", false)[0];

            message_log.Invoke((Action)delegate
            {
                message_log.Items.Add(line);
            });
        }

        #region EventHandlers
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendIrcMessage();
            }
        }

        private void btnMessageSend_Click(object sender, EventArgs e)
        {
            SendIrcMessage();
        }
        
        private void showUISandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sandbox = new frmUiSandbox();
            sandbox.Show();
        }

        #endregion EventHandlers

        private void tabsWindowControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
