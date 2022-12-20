using System;
using Engine.Models;

namespace Engine.Utils;

public static class ConvertData
{
    public static string[] Items;

    public static GameItem ConverToObject(string name)
    {
        Items = name.Split(" ");
        GameItem item = new GameItem(Int32.Parse(Items[0]), Items[1] , Int32.Parse(Items[2]));
        return item;
    }
}