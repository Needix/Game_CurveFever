﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Game_CurveFever.ProjectSRC.Controller.Game;
using Game_CurveFever.ProjectSRC.Controller.GUI;
using Game_CurveFever.ProjectSRC.Model.Game;

namespace Game_CurveFever.ProjectSRC.GUI {
    public partial class GUILocalNew :Form {
        private const int MAX_NEEDED_WINS = 50;
        private const int MAX_PLAYER_SPEED = 100;

        private CheckBox _keyListenerCheckbox;
        private char _stearLeftChar;
        private char _stearRightChar;
        private List<Player> _players = new List<Player>();

        public GUILocalNew() {
            InitializeComponent();
            CustomInitComponents();
            RegisterEvents();
        }

        private void RegisterEvents() {
            this.KeyPress += OnKeyPress;
            this.Closing += OnClosing;
            b_addPlayer.Click += AddPlayer;
            b_removeSelectedPlayer.Click += RemovePlayer;
            b_startLocalGame.Click += StartLocalGame;
            cbox_player_stearLeft.CheckedChanged += Stear;
            cbox_player_stearRight.CheckedChanged += Stear;
        }
        
        private void CustomInitComponents() {
            for(int i = 1; i < MAX_NEEDED_WINS; i++) {
                comboBox_options_neededWins.Items.Add(i);
            }
            for (int i = 1; i < MAX_PLAYER_SPEED; i++) {
                comboBox_options_playerSpeed.Items.Add(i);
            }

            comboBox_options_neededWins.SelectedIndex = 4;
            comboBox_options_createWinPhoto.SelectedIndex = 0;
            comboBox_options_items.SelectedIndex = 0;
            comboBox_options_pauseAllowed.SelectedIndex = 0;
            comboBox_options_playerSpeed.SelectedIndex = 24;
            comboBox_options_playerStart.SelectedIndex = 0;
        }

        private void AddPlayer(object sender, EventArgs e) {
            Player p = new Player(tb_player_name.Text, _stearLeftChar, _stearRightChar);
            listBox_player.Items.Add(p.Name+" ("+p.StearLeft+"/"+p.StearRight+")");
            _players.Add(p);

            if (_players.Count >= 2) b_startLocalGame.Enabled = true;
        }

        private void RemovePlayer(object sender, EventArgs e) {
            int index = listBox_player.SelectedIndex;
            listBox_player.Items.RemoveAt(index);
            _players.RemoveAt(index);

            if(_players.Count < 2) b_startLocalGame.Enabled = false;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e) {
            Debug.WriteLine("DebugPressedKey, GUILocalNew_OnKeyPress; return on space/backspace: "+(int)e.KeyChar);
            if (_keyListenerCheckbox == null) return; //TODO: Return on space/backspace char
            _keyListenerCheckbox.Checked = false;
            _keyListenerCheckbox.Text = (e.KeyChar+"");

            if (_keyListenerCheckbox == cbox_player_stearLeft) _stearLeftChar = e.KeyChar;
            else _stearRightChar = e.KeyChar;

            _keyListenerCheckbox = null;
        }

        private void Stear(object sender, EventArgs e) {
            CheckBox cbox = (CheckBox) sender;
            if (_keyListenerCheckbox != null) {
                _keyListenerCheckbox.Checked = false;
            }
            _keyListenerCheckbox = cbox;
        }

        private void StartLocalGame(object sender, EventArgs e) {
            bool items = comboBox_options_items.Items[comboBox_options_items.SelectedIndex].Equals("On");
            int playerSpeed = Convert.ToInt32(comboBox_options_playerSpeed.Items[comboBox_options_playerSpeed.SelectedIndex]);
            int neededWins = Convert.ToInt32(comboBox_options_neededWins.Items[comboBox_options_neededWins.SelectedIndex]);
            bool pauseAllowed = comboBox_options_pauseAllowed.Items[comboBox_options_pauseAllowed.SelectedIndex].Equals("Yes");
            bool photoFinish = comboBox_options_createWinPhoto.Items[comboBox_options_createWinPhoto.SelectedIndex].Equals("Yes");
            String playerStart = (String)comboBox_options_playerStart.Items[comboBox_options_playerStart.SelectedIndex];
            bool holes = true; //TODO: Add holes in GUI as option

            GameOptions.AllowedPause pause = pauseAllowed ? GameOptions.AllowedPause.Everyone : GameOptions.AllowedPause.Nobody;
            GameOptions.PlayerStartPositions startPos;
            if(playerStart.Equals("Line")) startPos = GameOptions.PlayerStartPositions.Line;
            else if(playerStart.Equals("Circle")) startPos = GameOptions.PlayerStartPositions.Circle;
            else startPos = GameOptions.PlayerStartPositions.Random;

            int guiW = 1500;
            int guiH = 900;
            Rectangle screenSize = Screen.FromControl(this).Bounds;
            if (screenSize.Width < guiW) guiW = screenSize.Width;
            if (screenSize.Height < guiH) guiH = screenSize.Height;

            //FinalizePlayer(startPos);

            GameOptions options = new GameOptions(holes, items, playerSpeed, GameOptions.Host.Server, neededWins, pause, startPos, photoFinish, null);
            MainLoop main = new MainLoop(guiW, guiH, options, _players);
            this.Visible = false;
            
        }

        private void OnClosing(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
