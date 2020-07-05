namespace Dirk
{
    partial class FrmIrcWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUISandboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerChatWindow = new System.Windows.Forms.SplitContainer();
            this.treeChannels = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMessageSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerChatWindow)).BeginInit();
            this.splitContainerChatWindow.Panel1.SuspendLayout();
            this.splitContainerChatWindow.Panel2.SuspendLayout();
            this.splitContainerChatWindow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1114, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUISandboxToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fileToolStripMenuItem.Text = "Debug";
            // 
            // showUISandboxToolStripMenuItem
            // 
            this.showUISandboxToolStripMenuItem.Name = "showUISandboxToolStripMenuItem";
            this.showUISandboxToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.showUISandboxToolStripMenuItem.Text = "Show UI Sandbox";
            this.showUISandboxToolStripMenuItem.Click += new System.EventHandler(this.ShowUISandboxToolStripMenuItem_Click);
            // 
            // splitContainerChatWindow
            // 
            this.splitContainerChatWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerChatWindow.Location = new System.Drawing.Point(0, 24);
            this.splitContainerChatWindow.Name = "splitContainerChatWindow";
            // 
            // splitContainerChatWindow.Panel1
            // 
            this.splitContainerChatWindow.Panel1.Controls.Add(this.treeChannels);
            // 
            // splitContainerChatWindow.Panel2
            // 
            this.splitContainerChatWindow.Panel2.Controls.Add(this.panel1);
            this.splitContainerChatWindow.Size = new System.Drawing.Size(1114, 690);
            this.splitContainerChatWindow.SplitterDistance = 221;
            this.splitContainerChatWindow.TabIndex = 4;
            // 
            // treeChannels
            // 
            this.treeChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeChannels.Location = new System.Drawing.Point(0, 0);
            this.treeChannels.Name = "treeChannels";
            this.treeChannels.Size = new System.Drawing.Size(221, 690);
            this.treeChannels.TabIndex = 4;
            this.treeChannels.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeChannels_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMessageSend);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 664);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 26);
            this.panel1.TabIndex = 6;
            // 
            // btnMessageSend
            // 
            this.btnMessageSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMessageSend.Location = new System.Drawing.Point(764, 0);
            this.btnMessageSend.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnMessageSend.Name = "btnMessageSend";
            this.btnMessageSend.Size = new System.Drawing.Size(125, 26);
            this.btnMessageSend.TabIndex = 1;
            this.btnMessageSend.Text = "Send";
            this.btnMessageSend.UseVisualStyleBackColor = true;
            this.btnMessageSend.Click += new System.EventHandler(this.BtnMessageSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(889, 26);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_KeyDown);
            // 
            // FrmIrcWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 714);
            this.Controls.Add(this.splitContainerChatWindow);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmIrcWindow";
            this.Text = "Dirk";
            this.Load += new System.EventHandler(this.FrmIrcWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainerChatWindow.Panel1.ResumeLayout(false);
            this.splitContainerChatWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerChatWindow)).EndInit();
            this.splitContainerChatWindow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showUISandboxToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerChatWindow;
        private System.Windows.Forms.TreeView treeChannels;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMessageSend;
        private System.Windows.Forms.TextBox txtMessage;
    }
}

