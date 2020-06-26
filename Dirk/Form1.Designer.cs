namespace Dirk
{
    partial class frmIrcWindow
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
            this.tabsWindowControl = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMessageSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUISandboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsWindowControl
            // 
            this.tabsWindowControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsWindowControl.Location = new System.Drawing.Point(0, 24);
            this.tabsWindowControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabsWindowControl.Multiline = true;
            this.tabsWindowControl.Name = "tabsWindowControl";
            this.tabsWindowControl.SelectedIndex = 0;
            this.tabsWindowControl.Size = new System.Drawing.Size(712, 535);
            this.tabsWindowControl.TabIndex = 0;
            this.tabsWindowControl.SelectedIndexChanged += new System.EventHandler(this.tabsWindowControl_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMessageSend);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 559);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 26);
            this.panel1.TabIndex = 1;
            // 
            // btnMessageSend
            // 
            this.btnMessageSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMessageSend.Location = new System.Drawing.Point(587, 0);
            this.btnMessageSend.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnMessageSend.Name = "btnMessageSend";
            this.btnMessageSend.Size = new System.Drawing.Size(125, 26);
            this.btnMessageSend.TabIndex = 1;
            this.btnMessageSend.Text = "Send";
            this.btnMessageSend.UseVisualStyleBackColor = true;
            this.btnMessageSend.Click += new System.EventHandler(this.btnMessageSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(712, 26);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
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
            this.showUISandboxToolStripMenuItem.Click += new System.EventHandler(this.showUISandboxToolStripMenuItem_Click);
            // 
            // frmIrcWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 585);
            this.Controls.Add(this.tabsWindowControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmIrcWindow";
            this.Text = "Dirk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabsWindowControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMessageSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showUISandboxToolStripMenuItem;
    }
}

