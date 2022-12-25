using System;
using System.Collections.Generic;
using System.IO;
using Engine.Models;
using Newtonsoft.Json;

namespace Engine.Utils;

public static class ConvertToGameItem
{
    public static List<GameItem> GameItems = new List<GameItem>();
    public static string basePath = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\";
    
    public static List<GameItem> ConvertData (string path)
    {
        string jsonData = File.ReadAllText(basePath + path);
        dynamic data = JsonConvert.DeserializeObject(jsonData);
        var jsonItems = data.items;
        
        foreach (dynamic item in jsonItems)
        {
            int Id = unchecked((int)item.ItemTypeID.Value);
            int Price = unchecked((int)item.Price.Value);
           GameItems.Add(new GameItem(Id, item.Name.ToString(), Price));
        }

        return GameItems;
    }

}