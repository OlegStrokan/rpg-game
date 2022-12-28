using System;
using System.Collections.Generic;
using System.IO;
using Engine.Factories;
using Engine.Models;
using Newtonsoft.Json;

namespace Engine.Utils;

public static class ConvertToLocation
{
    
    public static List<TraderHere> traders = new List<TraderHere>();
    public static List<QuestHere> quests = new List<QuestHere>();
    public static List<MonsterHere> monsters = new List<MonsterHere>();
    
    public static string basePath = @"C:\Users\oleh.strokan\RiderProjects\rpg-game\User data\";
    
    public static World ConvertData (string path, World world)
    {
        string jsonData = File.ReadAllText(basePath + path);
        dynamic data = JsonConvert.DeserializeObject(jsonData);
        var jsonItems = data.locations;

        foreach (var item in jsonItems)
        {
            if (item.TraderHere != null)
            {
                foreach (var trader in item.TraderHere)
                {
                    traders.Add(new TraderHere(trader.Name.ToString(), item.Name.ToString()));
                }
            } 
            if (item.QuestsAvailableHere != null)
            {
                foreach (var quest in item.QuestsAvailableHere)
                {
                    int id = unchecked((int)quest.Id.Value);
                    quests.Add(new QuestHere(id, item.Name.ToString()));
                }
            }    
            if (item.MonstersHere != null)
            {
                foreach (var monster in item.MonstersHere)
                {
                    int id = unchecked((int)monster.Id.Value);
                    int chanceOfEncountering = unchecked((int)monster.ChanceOfEncountering.Value);
                    monsters.Add(new MonsterHere(id, chanceOfEncountering, item.Name.ToString()));
                }
            }
            
            int XCoordinate = unchecked((int)item.XCoordinate.Value);
            int YCoordinate = unchecked((int)item.YCoordinate.Value);
            world.AddLocation(XCoordinate, YCoordinate, item.Name.ToString(), item.Description.ToString(), item.ImageName.ToString());

            foreach (TraderHere trader in traders)
            {
                if (item.Name.ToString() == trader.LocationName)
                {
                    world.LocationAt(XCoordinate, YCoordinate).TraderHere = TraderFactory.GetTraderByName(trader.TraderName);
                }
            }

            foreach (QuestHere quest in quests)
            {
                if (item.Name.ToString() == quest.LocationName)
                {
                     world.LocationAt(XCoordinate, YCoordinate).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(quest.Id));
                }
               
            }

            foreach (MonsterHere monster in monsters)
            {
                if (item.Name.ToString() == monster.LocationName)
                {
                    world.LocationAt(XCoordinate, YCoordinate).AddMonster(monster.Id, monster.ChanceOfEncountering);   
                }
              
            }
        }

        return world;
    }

}