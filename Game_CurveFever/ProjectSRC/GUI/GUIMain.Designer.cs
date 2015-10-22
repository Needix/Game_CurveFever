namespace Game_CurveFever.ProjectSRC.GUI {
    partial class GUIMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.groupBox_main_local = new System.Windows.Forms.GroupBox();
            this.b_local_loadSavedGame = new System.Windows.Forms.Button();
            this.b_local_createNewGame = new System.Windows.Forms.Button();
            this.groupBox_internet = new System.Windows.Forms.GroupBox();
            this.b_internet_joinServer = new System.Windows.Forms.Button();
            this.b_internet_createNewServer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.Panel2.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            this.groupBox_main_local.SuspendLayout();
            this.groupBox_internet.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_main
            // 
            this.splitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_main.Name = "splitContainer_main";
            this.splitContainer_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_main.Panel1
            // 
            this.splitContainer_main.Panel1.Controls.Add(this.groupBox_main_local);
            // 
            // splitContainer_main.Panel2
            // 
            this.splitContainer_main.Panel2.Controls.Add(this.groupBox_internet);
            this.splitContainer_main.Size = new System.Drawing.Size(348, 166);
            this.splitContainer_main.SplitterDistance = 81;
            this.splitContainer_main.TabIndex = 0;
            // 
            // groupBox_main_local
            // 
            this.groupBox_main_local.Controls.Add(this.b_local_loadSavedGame);
            this.groupBox_main_local.Controls.Add(this.b_local_createNewGame);
            this.groupBox_main_local.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_main_local.Location = new System.Drawing.Point(0, 0);
            this.groupBox_main_local.Name = "groupBox_main_local";
            this.groupBox_main_local.Size = new System.Drawing.Size(348, 81);
            this.groupBox_main_local.TabIndex = 0;
            this.groupBox_main_local.TabStop = false;
            this.groupBox_main_local.Text = "Local";
            // 
            // b_local_loadSavedGame
            // 
            this.b_local_loadSavedGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_local_loadSavedGame.Location = new System.Drawing.Point(12, 48);
            this.b_local_loadSavedGame.Name = "b_local_loadSavedGame";
            this.b_local_loadSavedGame.Size = new System.Drawing.Size(324, 23);
            this.b_local_loadSavedGame.TabIndex = 1;
            this.b_local_loadSavedGame.Text = "Load saved game...";
            this.b_local_loadSavedGame.UseVisualStyleBackColor = true;
            this.b_local_loadSavedGame.Click += new System.EventHandler(this.b_local_loadSavedGame_Click);
            // 
            // b_local_createNewGame
            // 
            this.b_local_createNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_local_createNewGame.Location = new System.Drawing.Point(12, 19);
            this.b_local_createNewGame.Name = "b_local_createNewGame";
            this.b_local_createNewGame.Size = new System.Drawing.Size(324, 23);
            this.b_local_createNewGame.TabIndex = 0;
            this.b_local_createNewGame.Text = "Create new game...";
            this.b_local_createNewGame.UseVisualStyleBackColor = true;
            this.b_local_createNewGame.Click += new System.EventHandler(this.b_local_createNewGame_Click);
            // 
            // groupBox_internet
            // 
            this.groupBox_internet.Controls.Add(this.b_internet_joinServer);
            this.groupBox_internet.Controls.Add(this.b_internet_createNewServer);
            this.groupBox_internet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_internet.Location = new System.Drawing.Point(0, 0);
            this.groupBox_internet.Name = "groupBox_internet";
            this.groupBox_internet.Size = new System.Drawing.Size(348, 81);
            this.groupBox_internet.TabIndex = 0;
            this.groupBox_internet.TabStop = false;
            this.groupBox_internet.Text = "Internet";
            // 
            // b_internet_joinServer
            // 
            this.b_internet_joinServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_internet_joinServer.Location = new System.Drawing.Point(12, 48);
            this.b_internet_joinServer.Name = "b_internet_joinServer";
            this.b_internet_joinServer.Size = new System.Drawing.Size(324, 23);
            this.b_internet_joinServer.TabIndex = 1;
            this.b_internet_joinServer.Text = "Join Server";
            this.b_internet_joinServer.UseVisualStyleBackColor = true;
            this.b_internet_joinServer.Click += new System.EventHandler(this.b_internet_joinServer_Click);
            // 
            // b_internet_createNewServer
            // 
            this.b_internet_createNewServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_internet_createNewServer.Location = new System.Drawing.Point(12, 19);
            this.b_internet_createNewServer.Name = "b_internet_createNewServer";
            this.b_internet_createNewServer.Size = new System.Drawing.Size(324, 23);
            this.b_internet_createNewServer.TabIndex = 0;
            this.b_internet_createNewServer.Text = "Create new server...";
            this.b_internet_createNewServer.UseVisualStyleBackColor = true;
            this.b_internet_createNewServer.Click += new System.EventHandler(this.b_internet_createNewServer_Click);
            // 
            // GUIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 166);
            this.Controls.Add(this.splitContainer_main);
            this.Name = "GUIMain";
            this.Text = "GUIView";
            this.splitContainer_main.Panel1.ResumeLayout(false);
            this.splitContainer_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
            this.splitContainer_main.ResumeLayout(false);
            this.groupBox_main_local.ResumeLayout(false);
            this.groupBox_internet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.GroupBox groupBox_main_local;
        private System.Windows.Forms.Button b_local_loadSavedGame;
        private System.Windows.Forms.Button b_local_createNewGame;
        private System.Windows.Forms.GroupBox groupBox_internet;
        private System.Windows.Forms.Button b_internet_joinServer;
        private System.Windows.Forms.Button b_internet_createNewServer;
    }
}