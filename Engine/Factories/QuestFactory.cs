﻿using System.Collections.Generic;
using System.Linq;
using Engine.Models;

namespace Engine.Factories;

internal static class QuestFactory
{
    private static readonly List<Quest> _quests = new List<Quest>();

    static QuestFactory()
    {
        List<ItemQuantity> itemsToComplete = new List<ItemQuantity>();
        List<ItemQuantity> rewardItems = new List<ItemQuantity>();
        
        itemsToComplete.Add(new ItemQuantity(9001, 5));
        rewardItems.Add(new ItemQuantity(1002, 1));
        
        _quests.Add(new Quest(
            1, 
            "Clear the herb garden", 
            "Defeat the snaked in the Herbalist's garden",
            itemsToComplete, 
            25,
            10, 
            rewardItems
            ));
        _quests.Add(new Quest(
            2, 
            "Kill the boss", 
            "Defeat the boss of the location",
            itemsToComplete, 
            50,
            0, 
            rewardItems
            ));
    }

    internal static Quest GetQuestByID(int id)
    {
        return _quests.FirstOrDefault(quest => quest.ID == id);
    }
}