namespace Game_CurveFever.ProjectSRC.GUI {
    partial class GUIInternetCreate {
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbox_player_stearRight = new System.Windows.Forms.CheckBox();
            this.cbox_player_stearLeft = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_player_name = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_openServer = new System.Windows.Forms.Button();
            this.b_startServer = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox_player = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_options_createWinPhoto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_options_pauseAllowed = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_options_neededWins = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_options_playerSpeed = new System.Windows.Forms.ComboBox();
            this.comboBox_options_items = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_server_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(584, 376);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_player_stearRight);
            this.groupBox1.Controls.Add(this.cbox_player_stearLeft);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_player_name);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Info";
            // 
            // cbox_player_stearRight
            // 
            this.cbox_player_stearRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbox_player_stearRight.Location = new System.Drawing.Point(293, 45);
            this.cbox_player_stearRight.Name = "cbox_player_stearRight";
            this.cbox_player_stearRight.Size = new System.Drawing.Size(277, 24);
            this.cbox_player_stearRight.TabIndex = 3;
            this.cbox_player_stearRight.Text = "Stear Right";
            this.cbox_player_stearRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbox_player_stearRight.UseVisualStyleBackColor = true;
            // 
            // cbox_player_stearLeft
            // 
            this.cbox_player_stearLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbox_player_stearLeft.Location = new System.Drawing.Point(12, 45);
            this.cbox_player_stearLeft.Name = "cbox_player_stearLeft";
            this.cbox_player_stearLeft.Size = new System.Drawing.Size(275, 24);
            this.cbox_player_stearLeft.TabIndex = 2;
            this.cbox_player_stearLeft.Text = "Stear Left";
            this.cbox_player_stearLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbox_player_stearLeft.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Name:";
            // 
            // tb_player_name
            // 
            this.tb_player_name.Location = new System.Drawing.Point(88, 19);
            this.tb_player_name.Name = "tb_player_name";
            this.tb_player_name.Size = new System.Drawing.Size(482, 20);
            this.tb_player_name.TabIndex = 0;
            this.tb_player_name.Text = "Host";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_openServer);
            this.groupBox2.Controls.Add(this.b_startServer);
            this.groupBox2.Controls.Add(this.splitContainer2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tb_server_name);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 290);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Info";
            // 
            // b_openServer
            // 
            this.b_openServer.Location = new System.Drawing.Point(12, 45);
            this.b_openServer.Name = "b_openServer";
            this.b_openServer.Size = new System.Drawing.Size(558, 23);
            this.b_openServer.TabIndex = 6;
            this.b_openServer.Text = "Open Server";
            this.b_openServer.UseVisualStyleBackColor = true;
            // 
            // b_startServer
            // 
            this.b_startServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_startServer.Location = new System.Drawing.Point(6, 261);
            this.b_startServer.Name = "b_startServer";
            this.b_startServer.Size = new System.Drawing.Size(572, 23);
            this.b_startServer.TabIndex = 5;
            this.b_startServer.Text = "Init";
            this.b_startServer.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(6, 74);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(572, 181);
            this.splitContainer2.SplitterDistance = 190;
            this.splitContainer2.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox_player);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 181);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player";
            // 
            // listBox_player
            // 
            this.listBox_player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_player.FormattingEnabled = true;
            this.listBox_player.Location = new System.Drawing.Point(3, 16);
            this.listBox_player.Name = "listBox_player";
            this.listBox_player.Size = new System.Drawing.Size(184, 162);
            this.listBox_player.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.comboBox_options_createWinPhoto);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.comboBox_options_pauseAllowed);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.comboBox_options_neededWins);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.comboBox_options_playerSpeed);
            this.groupBox4.Controls.Add(this.comboBox_options_items);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(378, 181);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Player start positions: ";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Random",
            "Circle",
            "Line"});
            this.comboBox1.Location = new System.Drawing.Point(132, 149);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(240, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Photo finish?: ";
            // 
            // comboBox_options_createWinPhoto
            // 
            this.comboBox_options_createWinPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_options_createWinPhoto.FormattingEnabled = true;
            this.comboBox_options_createWinPhoto.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBox_options_createWinPhoto.Location = new System.Drawing.Point(132, 122);
            this.comboBox_options_createWinPhoto.Name = "comboBox_options_createWinPhoto";
            this.comboBox_options_createWinPhoto.Size = new System.Drawing.Size(240, 21);
            this.comboBox_options_createWinPhoto.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Paused allowed?: ";
            // 
            // comboBox_options_pauseAllowed
            // 
            this.comboBox_options_pauseAllowed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_options_pauseAllowed.FormattingEnabled = true;
            this.comboBox_options_pauseAllowed.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBox_options_pauseAllowed.Location = new System.Drawing.Point(132, 95);
            this.comboBox_options_pauseAllowed.Name = "comboBox_options_pauseAllowed";
            this.comboBox_options_pauseAllowed.Size = new System.Drawing.Size(240, 21);
            this.comboBox_options_pauseAllowed.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Needed wins: ";
            // 
            // comboBox_options_neededWins
            // 
            this.comboBox_options_neededWins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_options_neededWins.FormattingEnabled = true;
            this.comboBox_options_neededWins.Location = new System.Drawing.Point(132, 68);
            this.comboBox_options_neededWins.Name = "comboBox_options_neededWins";
            this.comboBox_options_neededWins.Size = new System.Drawing.Size(240, 21);
            this.comboBox_options_neededWins.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Player Speed: ";
            // 
            // comboBox_options_playerSpeed
            // 
            this.comboBox_options_playerSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_options_playerSpeed.FormattingEnabled = true;
            this.comboBox_options_playerSpeed.Location = new System.Drawing.Point(132, 40);
            this.comboBox_options_playerSpeed.Name = "comboBox_options_playerSpeed";
            this.comboBox_options_playerSpeed.Size = new System.Drawing.Size(240, 21);
            this.comboBox_options_playerSpeed.TabIndex = 14;
            // 
            // comboBox_options_items
            // 
            this.comboBox_options_items.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_options_items.FormattingEnabled = true;
            this.comboBox_options_items.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.comboBox_options_items.Location = new System.Drawing.Point(132, 13);
            this.comboBox_options_items.Name = "comboBox_options_items";
            this.comboBox_options_items.Size = new System.Drawing.Size(240, 21);
            this.comboBox_options_items.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Items: ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(485, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(85, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "28960";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port: ";
            // 
            // tb_server_name
            // 
            this.tb_server_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_server_name.Location = new System.Drawing.Point(88, 19);
            this.tb_server_name.Name = "tb_server_name";
            this.tb_server_name.Size = new System.Drawing.Size(332, 20);
            this.tb_server_name.TabIndex = 1;
            this.tb_server_name.Text = "New CurveFever Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Servername: ";
            // 
            // GUIInternetCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 376);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(16, 415);
            this.Name = "GUIInternetCreate";
            this.Text = "GUIInternetCreate";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbox_player_stearRight;
        private System.Windows.Forms.CheckBox cbox_player_stearLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_player_name;
        private System.Windows.Forms.TextBox tb_server_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button b_startServer;
        private System.Windows.Forms.Button b_openServer;
        private System.Windows.Forms.ListBox listBox_player;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_options_createWinPhoto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_options_pauseAllowed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_options_neededWins;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_options_playerSpeed;
        private System.Windows.Forms.ComboBox comboBox_options_items;
        private System.Windows.Forms.Label label10;
    }
}