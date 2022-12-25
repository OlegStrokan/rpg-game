using System;
using System.Collections.Generic;
using System.IO;
using Engine.Models;
using Newtonsoft.Json;

namespace Engine.Utils;

public static class ConvertToWeapon
{
    public static List<Weapon> Weapons = new List<Weapon>();
    public static string basePath = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\";
    
    public static List<Weapon> ConvertData (string path)
    {
        string jsonData = File.ReadAllText(basePath + path);
        dynamic data = JsonConvert.DeserializeObject(jsonData);
        var jsonItems = data.weapons;
        
        foreach (dynamic item in jsonItems)
        {
            int Id = unchecked((int)item.ItemTypeID.Value);
            int Price = unchecked((int)item.Price.Value);
            int MinDamage = unchecked((int)item.MinDamage.Value);
            int MaxDamage = unchecked((int)item.MaxDamage.Value);
           Weapons.Add(new Weapon(Id, item.Name.ToString(), Price, MinDamage, MaxDamage));
        }

        return Weapons;
    }

}