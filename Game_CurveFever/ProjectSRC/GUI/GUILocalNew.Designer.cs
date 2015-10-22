namespace Game_CurveFever.ProjectSRC.GUI {
    partial class GUILocalNew {
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
            this.splitContainer_local_keys_options = new System.Windows.Forms.SplitContainer();
            this.groupBox_keys = new System.Windows.Forms.GroupBox();
            this.cbox_player_stearRight = new System.Windows.Forms.CheckBox();
            this.cbox_player_stearLeft = new System.Windows.Forms.CheckBox();
            this.tb_player_name = new System.Windows.Forms.TextBox();
            this.b_removeSelectedPlayer = new System.Windows.Forms.Button();
            this.b_addPlayer = new System.Windows.Forms.Button();
            this.listBox_player = new System.Windows.Forms.ListBox();
            this.groupBox_options = new System.Windows.Forms.GroupBox();
            this.b_startLocalGame = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_options_playerStart = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_options_createWinPhoto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_options_pauseAllowed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_options_neededWins = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_options_playerSpeed = new System.Windows.Forms.ComboBox();
            this.comboBox_options_items = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_local_keys_options)).BeginInit();
            this.splitContainer_local_keys_options.Panel1.SuspendLayout();
            this.splitContainer_local_keys_options.Panel2.SuspendLayout();
            this.splitContainer_local_keys_options.SuspendLayout();
            this.groupBox_keys.SuspendLayout();
            this.groupBox_options.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_local_keys_options
            // 
            this.splitContainer_local_keys_options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_local_keys_options.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_local_keys_options.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_local_keys_options.Name = "splitContainer_local_keys_options";
            // 
            // splitContainer_local_keys_options.Panel1
            // 
            this.splitContainer_local_keys_options.Panel1.Controls.Add(this.groupBox_keys);
            // 
            // splitContainer_local_keys_options.Panel2
            // 
            this.splitContainer_local_keys_options.Panel2.Controls.Add(this.groupBox_options);
            this.splitContainer_local_keys_options.Size = new System.Drawing.Size(669, 229);
            this.splitContainer_local_keys_options.SplitterDistance = 311;
            this.splitContainer_local_keys_options.TabIndex = 0;
            // 
            // groupBox_keys
            // 
            this.groupBox_keys.Controls.Add(this.cbox_player_stearRight);
            this.groupBox_keys.Controls.Add(this.cbox_player_stearLeft);
            this.groupBox_keys.Controls.Add(this.tb_player_name);
            this.groupBox_keys.Controls.Add(this.b_removeSelectedPlayer);
            this.groupBox_keys.Controls.Add(this.b_addPlayer);
            this.groupBox_keys.Controls.Add(this.listBox_player);
            this.groupBox_keys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_keys.Location = new System.Drawing.Point(0, 0);
            this.groupBox_keys.Name = "groupBox_keys";
            this.groupBox_keys.Size = new System.Drawing.Size(311, 229);
            this.groupBox_keys.TabIndex = 0;
            this.groupBox_keys.TabStop = false;
            this.groupBox_keys.Text = "Player";
            // 
            // cbox_player_stearRight
            // 
            this.cbox_player_stearRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbox_player_stearRight.Location = new System.Drawing.Point(156, 45);
            this.cbox_player_stearRight.Name = "cbox_player_stearRight";
            this.cbox_player_stearRight.Size = new System.Drawing.Size(149, 24);
            this.cbox_player_stearRight.TabIndex = 5;
            this.cbox_player_stearRight.Text = "Stear Right";
            this.cbox_player_stearRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbox_player_stearRight.UseVisualStyleBackColor = true;
            // 
            // cbox_player_stearLeft
            // 
            this.cbox_player_stearLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbox_player_stearLeft.Location = new System.Drawing.Point(12, 45);
            this.cbox_player_stearLeft.Name = "cbox_player_stearLeft";
            this.cbox_player_stearLeft.Size = new System.Drawing.Size(138, 24);
            this.cbox_player_stearLeft.TabIndex = 4;
            this.cbox_player_stearLeft.Text = "Stear Left";
            this.cbox_player_stearLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbox_player_stearLeft.UseVisualStyleBackColor = true;
            // 
            // tb_player_name
            // 
            this.tb_player_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_player_name.Location = new System.Drawing.Point(12, 19);
            this.tb_player_name.Name = "tb_player_name";
            this.tb_player_name.Size = new System.Drawing.Size(293, 20);
            this.tb_player_name.TabIndex = 3;
            this.tb_player_name.Text = "Playername";
            // 
            // b_removeSelectedPlayer
            // 
            this.b_removeSelectedPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_removeSelectedPlayer.Location = new System.Drawing.Point(96, 71);
            this.b_removeSelectedPlayer.Name = "b_removeSelectedPlayer";
            this.b_removeSelectedPlayer.Size = new System.Drawing.Size(209, 23);
            this.b_removeSelectedPlayer.TabIndex = 2;
            this.b_removeSelectedPlayer.Text = "Remove selected Player";
            this.b_removeSelectedPlayer.UseVisualStyleBackColor = true;
            // 
            // b_addPlayer
            // 
            this.b_addPlayer.Location = new System.Drawing.Point(12, 71);
            this.b_addPlayer.Name = "b_addPlayer";
            this.b_addPlayer.Size = new System.Drawing.Size(78, 23);
            this.b_addPlayer.TabIndex = 1;
            this.b_addPlayer.Text = "Add Player";
            this.b_addPlayer.UseVisualStyleBackColor = true;
            // 
            // listBox_player
            // 
            this.listBox_player.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_player.FormattingEnabled = true;
            this.listBox_player.Location = new System.Drawing.Point(12, 104);
            this.listBox_player.Name = "listBox_player";
            this.listBox_player.Size = new System.Drawing.Size(293, 108);
            this.listBox_player.TabIndex = 0;
            // 
            // groupBox_options
            // 
            this.groupBox_options.Controls.Add(this.b_startLocalGame);
            this.groupBox_options.Controls.Add(this.label6);
            this.groupBox_options.Controls.Add(this.comboBox_options_playerStart);
            this.groupBox_options.Controls.Add(this.label5);
            this.groupBox_options.Controls.Add(this.comboBox_options_createWinPhoto);
            this.groupBox_options.Controls.Add(this.label4);
            this.groupBox_options.Controls.Add(this.comboBox_options_pauseAllowed);
            this.groupBox_options.Controls.Add(this.label3);
            this.groupBox_options.Controls.Add(this.comboBox_options_neededWins);
            this.groupBox_options.Controls.Add(this.label2);
            this.groupBox_options.Controls.Add(this.comboBox_options_playerSpeed);
            this.groupBox_options.Controls.Add(this.comboBox_options_items);
            this.groupBox_options.Controls.Add(this.label1);
            this.groupBox_options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_options.Location = new System.Drawing.Point(0, 0);
            this.groupBox_options.Name = "groupBox_options";
            this.groupBox_options.Size = new System.Drawing.Size(354, 229);
            this.groupBox_options.TabIndex = 0;
            this.groupBox_options.TabStop = false;
            this.groupBox_options.Text = "Options";
            // 
            // b_startLocalGame
            // 
            this.b_startLocalGame.Enabled = false;
            this.b_startLocalGame.Location = new System.Drawing.Point(9, 176);
            this.b_startLocalGame.Name = "b_startLocalGame";
            this.b_startLocalGame.Size = new System.Drawing.Size(339, 36);
            this.b_startLocalGame.TabIndex = 12;
            this.b_startLocalGame.Text = "Start local game";
            this.b_startLocalGame.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Player start positions: ";
            // 
            // comboBox_options_playerStart
            // 
            this.comboBox_options_playerStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_options_playerStart.FormattingEnabled = true;
            this.comboBox_options_playerStart.Items.AddRange(new object[] {
            "Random",
            "Circle",
            "Line"});
            this.comboBox_options_playerStart.Location = new System.Drawing.Point(132, 149);
            this.comboBox_options_playerStart.Name = "comboBox_options_playerStart";
            this.comboBox_options_playerStart.Size = new System.Drawing.Size(216, 21);
            this.comboBox_options_playerStart.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
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
            this.comboBox_options_createWinPhoto.Size = new System.Drawing.Size(216, 21);
            this.comboBox_options_createWinPhoto.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Paused allowed?: ";
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
            this.comboBox_options_pauseAllowed.Size = new System.Drawing.Size(216, 21);
            this.comboBox_options_pauseAllowed.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Needed wins: ";
            // 
            // comboBox_options_neededWins
            // 
            this.comboBox_options_neededWins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_options_neededWins.FormattingEnabled = true;
            this.comboBox_options_neededWins.Location = new System.Drawing.Point(132, 68);
            this.comboBox_options_neededWins.Name = "comboBox_options_neededWins";
            this.comboBox_options_neededWins.Size = new System.Drawing.Size(216, 21);
            this.comboBox_options_neededWins.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player Speed: ";
            // 
            // comboBox_options_playerSpeed
            // 
            this.comboBox_options_playerSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_options_playerSpeed.FormattingEnabled = true;
            this.comboBox_options_playerSpeed.Location = new System.Drawing.Point(132, 40);
            this.comboBox_options_playerSpeed.Name = "comboBox_options_playerSpeed";
            this.comboBox_options_playerSpeed.Size = new System.Drawing.Size(216, 21);
            this.comboBox_options_playerSpeed.TabIndex = 2;
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
            this.comboBox_options_items.Size = new System.Drawing.Size(216, 21);
            this.comboBox_options_items.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Items: ";
            // 
            // GUILocalNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 229);
            this.Controls.Add(this.splitContainer_local_keys_options);
            this.KeyPreview = true;
            this.Name = "GUILocalNew";
            this.Text = "GUILocal";
            this.splitContainer_local_keys_options.Panel1.ResumeLayout(false);
            this.splitContainer_local_keys_options.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_local_keys_options)).EndInit();
            this.splitContainer_local_keys_options.ResumeLayout(false);
            this.groupBox_keys.ResumeLayout(false);
            this.groupBox_keys.PerformLayout();
            this.groupBox_options.ResumeLayout(false);
            this.groupBox_options.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_local_keys_options;
        private System.Windows.Forms.GroupBox groupBox_keys;
        private System.Windows.Forms.TextBox tb_player_name;
        private System.Windows.Forms.Button b_removeSelectedPlayer;
        private System.Windows.Forms.Button b_addPlayer;
        private System.Windows.Forms.ListBox listBox_player;
        private System.Windows.Forms.GroupBox groupBox_options;
        private System.Windows.Forms.ComboBox comboBox_options_items;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_options_playerSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_options_neededWins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_options_pauseAllowed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_options_createWinPhoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_options_playerStart;
        private System.Windows.Forms.Button b_startLocalGame;
        private System.Windows.Forms.CheckBox cbox_player_stearLeft;
        private System.Windows.Forms.CheckBox cbox_player_stearRight;
    }
}