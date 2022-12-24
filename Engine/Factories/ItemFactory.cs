using System.Collections.Generic;
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
         List<GameItem> gameItems = ConvertToWeaponOrGameItem.ConvertData(FileData.ReadFromFile("file.txt"));
         foreach (GameItem gameItem in gameItems)
         {
             _standardGameItems.Add(gameItem);
         }
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