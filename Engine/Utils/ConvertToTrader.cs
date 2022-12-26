using System;
using System.Collections.Generic;
using System.IO;
using Engine.Factories;
using Engine.Models;
using Newtonsoft.Json;

namespace Engine.Utils;

public static class ConvertToTrader
{
    public static List<Trader> Traders = new List<Trader>();
    public static string basePath = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\";
    
    public static List<Trader> ConvertData (string path)
    {
        string jsonData = File.ReadAllText(basePath + path);
        dynamic data = JsonConvert.DeserializeObject(jsonData);
        var jsonItems = data.traders;

        
        foreach (dynamic trader in jsonItems)
        {
            Trader newTrader = new Trader(trader.Name.ToString());
             foreach (var items in trader.Items)
             {
                 int item = unchecked((int)items.ItemId);
                 newTrader.AddItemToInventory(ItemFactory.CreateGameItem(item));
             }
            Traders.Add(newTrader);
           
        }

        return Traders;
    }

}