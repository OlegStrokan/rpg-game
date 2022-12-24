using System;
using System.Collections.Generic;
using System.IO;
using Engine.Models;
using Newtonsoft.Json;

namespace Engine.Utils;

public static class ConvertToQuest
{
    public static List<Quest> Quests = new List<Quest>();
    public static List<ItemQuantity> ItemsToComplete = new List<ItemQuantity>();
    public static List<ItemQuantity> RewardItems = new List<ItemQuantity>();
    public static string basePath = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\";
    
    public static List<Quest> ConvertData (string path)
    {
        string jsonData = File.ReadAllText(basePath + path);
        dynamic data = JsonConvert.DeserializeObject(jsonData);
        var jsonItems = data.quests;

        foreach (var itemQuantity in jsonItems)
        {
            if (itemQuantity.ItemsToComplete != null)
            {
                foreach (var itemToComplete in itemQuantity.ItemsToComplete)
                {
                    int ItemID = unchecked((int)itemToComplete.ItemID.Value);
                    int Quantity = unchecked((int)itemToComplete.Quantity.Value);
                    ItemsToComplete.Add(new ItemQuantity(ItemID, Quantity));
                }
            } 
            if (itemQuantity.RewardItems != null)
            {
                foreach (var itemToComplete in itemQuantity.RewardItems)
                {
                    int ItemID = unchecked((int)itemToComplete.ItemID.Value);
                    int Quantity = unchecked((int)itemToComplete.Quantity.Value);
                    RewardItems.Add(new ItemQuantity(ItemID, Quantity));
                }
            }
            
        }
        
        foreach (dynamic item in jsonItems)
        {
            int Id = unchecked((int)item.Id.Value);
            int RewardExperiencePoints = unchecked((int)item.RewardExperiencePoints.Value);
            int RewardGold = unchecked((int)item.RewardGold.Value);
            Quests.Add(new Quest(Id, item.Name.ToString(), item.Description.ToString(), ItemsToComplete, RewardExperiencePoints, RewardGold, RewardItems));
        }

        return Quests;
    }

}