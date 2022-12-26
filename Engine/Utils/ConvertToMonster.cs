using System;
using System.Collections.Generic;
using System.IO;
using Engine.Models;
using Newtonsoft.Json;

namespace Engine.Utils;

public static class ConvertToMonster
{
    public static List<Monster> Monsters = new List<Monster>();
    public static string basePath = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\";
    
    public static List<Monster> ConvertData (string path)
    {
        string jsonData = File.ReadAllText(basePath + path);
        dynamic data = JsonConvert.DeserializeObject(jsonData);
        var jsonItems = data.monsters;
        
        foreach (dynamic item in jsonItems)
        {
            int id = unchecked((int)item.Id.Value);
            int maximumHitPoints = unchecked((int)item.MaximumHitPoints.Value);
            int currentHitPoints = unchecked((int)item.CurrentHitPoints.Value);
            int rewardExperiencePoints = unchecked((int)item.RewardExperiencePoints.Value);
            int rewardGold = unchecked((int)item.RewardGold.Value);
            int minimumDamage = unchecked((int)item.MinimumDamage.Value);
            int maximumDamage = unchecked((int)item.MaximumDamage.Value);
            Monsters.Add(new Monster(id, item.Name.ToString(), item.ImageName.ToString(), maximumHitPoints,
                currentHitPoints, rewardExperiencePoints, rewardGold, minimumDamage, maximumDamage));
        }

        return Monsters;
    }

}