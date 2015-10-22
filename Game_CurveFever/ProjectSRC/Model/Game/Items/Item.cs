// Item.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Drawing;
using Game_CurveFever.Properties;

namespace Game_CurveFever.ProjectSRC.Model.Game.Items {
    public class Item {
        public const int TICK_AMOUNT_ITEM_ON_FIELD = 20000;
        public static List<Item> PossibleItems { get; private set; }
        public static void CreateItems() {
            if (PossibleItems != null) throw new InvalidOperationException("Items were already initialized!");
            PossibleItems = new List<Item>();
            PossibleItems.Add(new Item(Resources.green_slow, new Effect(15, 1, Effect.EffectedPlayer.Other, "Other:Slow")));
            PossibleItems.Add(new Item(Resources.red_slow, new Effect(15, 1, Effect.EffectedPlayer.Self, "Self:Slow")));
            PossibleItems.Add(new Item(Resources.green_speed, new Effect(15, 1, Effect.EffectedPlayer.Self, "Self:Speed")));
            PossibleItems.Add(new Item(Resources.red_speed, new Effect(15, 1, Effect.EffectedPlayer.Other, "Other:Speed")));
            PossibleItems.Add(new Item(Resources.green_sharp, new Effect(15, 1, Effect.EffectedPlayer.Other, "Other:Square")));
            PossibleItems.Add(new Item(Resources.red_sharp, new Effect(15, 1, Effect.EffectedPlayer.Self, "Self:Square")));
            PossibleItems.Add(new Item(Resources.red_fat, new Effect(15, 1, Effect.EffectedPlayer.Self, "Self:Big")));
            PossibleItems.Add(new Item(Resources.green_thin, new Effect(15, 1, Effect.EffectedPlayer.Self, "Other:Thin")));
            PossibleItems.Add(new Item(Resources.red_x, new Effect(15, 1, Effect.EffectedPlayer.Self, "Self:No control")));
            PossibleItems.Add(new Item(Resources.red_reverse, new Effect(15, 1, Effect.EffectedPlayer.Self, "Self:Reversed Controls")));
            PossibleItems.Add(new Item(Resources.blue_eraser, new Effect(15, 1, Effect.EffectedPlayer.Global, "Global:Eraser")));
            PossibleItems.Add(new Item(Resources.blue_darkness, new Effect(15, 1, Effect.EffectedPlayer.Global, "Global:Darkness")));
            PossibleItems.Add(new Item(Resources.blue_colorchange, new Effect(15, 1, Effect.EffectedPlayer.Global, "Global:ColorChange")));
        }

        public Image Image { get; private set; }
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public bool ShowCaseItem { get; private set; }

        public int AppearedTick { get; private set; }
        public int RemoveTick { get; private set; }

        public Effect Effect { get; private set; }

        //Used for real items
        public Item(Image image, int posX, int posY, Effect effect) {
            PosX = posX;
            PosY = posY;
            Image = image;
            Effect = effect;
            AppearedTick = Environment.TickCount;
            RemoveTick = Environment.TickCount + TICK_AMOUNT_ITEM_ON_FIELD;
            ShowCaseItem = false;
        }

        //Used for showcase items
        public Item(Image image, Effect effect) {
            Image = image;
            Effect = effect;
            ShowCaseItem = true;
        }

        public Effect Activate() {
            return Effect.Copy();
        }
    }
}