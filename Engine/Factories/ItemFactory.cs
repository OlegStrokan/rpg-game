using System.Collections.Generic;
using System.Linq;
using Engine.Models;

namespace Engine.Factories;

public static class ItemFactory
{
    private static List<GameItem> _standartGameItems;

     static ItemFactory()
     {
         _standartGameItems = new List<GameItem>();
         _standartGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
         _standartGameItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
         _standartGameItems.Add(new GameItem(9001, "Snake fang", 1 ));
         _standartGameItems.Add(new GameItem(9002, "Snakeskin", 2 ));
         _standartGameItems.Add(new GameItem(9003, "Rat tail", 1 ));
         _standartGameItems.Add(new GameItem(9004, "Rat fur", 2 ));
         _standartGameItems.Add(new GameItem(9005, "Spider fang", 1 ));
         _standartGameItems.Add(new GameItem(9006, "Spider silk", 2 ));
     }

     public static GameItem CreateGameItem(int itemTypeID)
     {
         GameItem standartItem = _standartGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

         if (standartItem != null)
         {
             return standartItem.Clone();
         }

         return null;
     }
}