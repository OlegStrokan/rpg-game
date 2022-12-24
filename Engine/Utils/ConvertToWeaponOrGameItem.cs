using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Models;

namespace Engine.Utils;

public  static class ConvertToWeaponOrGameItem
{
    public static List<GameItem> Items = new List<GameItem>();
    public static List<string> Line = new List<string>();
    public static GameItem Item;

    public static List<GameItem> ConvertData(List<string> items)
    {
        foreach (string item in items)
        {
            Line = item.Split(",").ToList();
            if (Line.Count == 3)
            {
                Item = new GameItem(Int32.Parse(Line[0]), Line[1], Int32.Parse(Line[2]));
            }
            else
            {
                Item = new Weapon(Int32.Parse(Line[0]), Line[1], Int32.Parse(Line[2]), Int32.Parse(Line[3]), Int32.Parse(Line[4]));
            }

            Items.Add(Item);

        }

        return Items;
    }
}