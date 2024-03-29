﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Engine.Factories;

namespace Engine.Models;

public class Location
{
    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public List<Quest> QuestsAvailableHere { get; } = new List<Quest>();

    public List<MonsterEncounter> MonstersHere { get; } = new List<MonsterEncounter>();
    
    public Trader TraderHere { get; set; }

    public Location(int xCoordinate, int yCoordinate, string name, string description, string imageName)
    {
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
        Name = name;
        Description = description;
        ImageName =   ImageName = $"/Engine;component/Images/Locations/{imageName}";
    }
 
    public void AddMonster(int monsterID, int chanceOfEncountering)
    {
        if (MonstersHere.Exists(m => m.MonsterID == monsterID))
        {
            MonstersHere.First(m => m.MonsterID == monsterID).ChangeOfEncountering = chanceOfEncountering;
        }
        else
        {
            MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
        }
    }

    public Monster GetMonster()
    {
        if (!MonstersHere.Any())
        {
            return null;
        }

        int totalChances = MonstersHere.Sum(m => m.ChangeOfEncountering);

        int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

        int runningTotal = 0;

        foreach (MonsterEncounter monsterEncounter in MonstersHere)
        {
            runningTotal += monsterEncounter.ChangeOfEncountering;

            if (randomNumber <= runningTotal)
            {
                return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
            }
        }
          return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
    }
}