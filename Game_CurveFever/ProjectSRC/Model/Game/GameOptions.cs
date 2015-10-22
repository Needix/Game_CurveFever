// GameOptions.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Game_CurveFever.ProjectSRC.Model.Game.Items;

namespace Game_CurveFever.ProjectSRC.Model.Game {
    public class GameOptions {
        public enum Host {
            Client = 1,
            Server = 2,
        }

        public enum AllowedPause {
            Everyone = 1,
            Server = 2,
            Nobody = 3
        }

        public enum PlayerStartPositions {
            Random = 1,
            Line = 2,
            Circle = 3,
        }

        public Boolean Items { get; private set; }
        public int PlayerSpeed { get; private set; }
        public int NeededWins { get; private set; }
        public Host HostType { get; private set; }
        public AllowedPause AllowedPauseType { get; private set; }
        public PlayerStartPositions PlayerStartPositionsType { get; private set; }
        public Boolean CreatePhotoFinish { get; private set; }
        public List<Item> AllowedItems { get; private set; }

        public GameOptions(bool items, int playerSpeed, Host hostType, int neededWins, AllowedPause allowedPauseType, PlayerStartPositions playerStartPositionsType, bool createPhotoFinish, List<Item> allowedItems) {
            Items = items;
            PlayerSpeed = playerSpeed;
            HostType = hostType;
            NeededWins = neededWins;
            AllowedPauseType = allowedPauseType;
            PlayerStartPositionsType = playerStartPositionsType;
            CreatePhotoFinish = createPhotoFinish;
            if(items && allowedItems!=null) AllowedItems = allowedItems; 
            else AllowedItems = new List<Item>();
        }

        public Item GetItem(String name) {
            foreach (Item item in AllowedItems) {
                if (item.Effect.Name.Equals(name)) return item;
            }
            return null;
        }

        public override string ToString() {
            return string.Format("Items: {0}, PlayerSpeed: {1}, NeededWins: {2}, HostType: {3}, AllowedPauseType: {4}, PlayerStartPositionsType: {5}, CreatePhotoFinish: {6}", Items, PlayerSpeed, NeededWins, HostType, AllowedPauseType, PlayerStartPositionsType, CreatePhotoFinish);
        }
    }
}