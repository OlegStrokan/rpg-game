﻿using System.Collections.Generic;
using System.Linq;
using Engine.Models;
using Engine.Utils;
namespace Engine.Factories;

public static class ItemFactory
{
    private static readonly List<GameItem> _standardGameItems = new List<GameItem>();

     static ItemFactory()
     {
         _standardGameItems = new List<GameItem>();
         _standardGameItems.Add(ConvertData.ConverToObject(FileData.ReadFromFile()));
         _standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
         _standardGameItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
         _standardGameItems.Add(new GameItem(9001, "Snake fang", 1 ));
         _standardGameItems.Add(new GameItem(9002, "Snakeskin", 2 ));
         _standardGameItems.Add(new GameItem(9003, "Rat tail", 1 ));
         _standardGameItems.Add(new GameItem(9004, "Rat fur", 2 ));
         _standardGameItems.Add(new GameItem(9005, "Spider fang", 1 ));
         _standardGameItems.Add(new GameItem(9006, "Spider silk", 2 ));
     }

     public static GameItem CreateGameItem(int itemTypeID)
     {
         GameItem standartItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

         if (standartItem != null)
         {
             if (standartItem is Weapon)
             {
                 return (standartItem as Weapon).Clone();
             }
             return standartItem.Clone();
         }

         return null;
     }
}