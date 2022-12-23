using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Engine.Models;

namespace Engine.Utils;

public static class ConvertData
{
    public static List<GameItem> Items = new List<GameItem>();
    public static List<string> Line = new List<string>();
    public static GameItem Item;

    public static List<GameItem> ConverToGameItem(List<string> items)
    {
        foreach (string item in items)
        {
            Line = item.Split(",").ToList();
            Item = new GameItem(Int32.Parse(Line[0]), Line[1] , Int32.Parse(Line[2]));
            Items.Add(Item);
            
        }
        return Items;
    }  
    // public static List<GameItem> ConverToWeapon(List<string> name)
    // {
    //     while (name != null)
    //     {
    //         
    //     }
    //     GameItem item = new GameItem(Int32.Parse(Items[0]), Items[1] , Int32.Parse(Items[2]));
    //     return item;
    // }
}