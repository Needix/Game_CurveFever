// KeyMessageFilter.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game_CurveFever.ProjectSRC.Controller.GUI {
    public class KeyMessageFilter :IMessageFilter { //http://stackoverflow.com/questions/1100285/how-to-detect-the-currently-pressed-key
        private readonly KeysConverter _converted = new KeysConverter();

        private Dictionary<String, bool> _keyTable = new Dictionary<String, bool>();

        public Dictionary<String, bool> KeyTable {
            get { return this._keyTable; }
            private set { this._keyTable = value; }
        }

        public bool IsKeyPressed() {
            return this._keyPressed;
        }

        public bool IsKeyPressed(String k) {
            bool pressed;

            if(KeyTable.TryGetValue(k, out pressed)) {
                return pressed;
            }

            return false;
        }

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private bool _keyPressed;

        public bool PreFilterMessage(ref Message m) {
            String converted = _converted.ConvertToString((Keys)m.WParam).ToUpper();
            if(m.Msg == WM_KEYDOWN) {
                KeyTable[converted] = true;

                this._keyPressed = true;
            }

            if(m.Msg == WM_KEYUP) {
                KeyTable[converted] = false;

                this._keyPressed = false;
            }

            return false;
        }
    }
}