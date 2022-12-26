using System;
using System.Collections.Generic;
using Engine.Models;
using Engine.Utils;

namespace Engine.Factories;

public class MonsterFactory
{
    private static readonly List<Monster> _monsters = new List<Monster>();
    static MonsterFactory()
    {
        _monsters = new List<Monster>(ConvertToMonster.ConvertData("monsters.json"));
    }
    public static Monster GetMonster(int monsterID)
    {
        switch (monsterID)
        {
            case 1:
                Monster snake = _monsters.Find(item => item.Id == monsterID);
                AddLootItem(snake, 9001, 25);
                AddLootItem(snake, 9002, 75);

                return snake;
            
            case 2:
                Monster rat = _monsters.Find(item => item.Id == monsterID);
                AddLootItem(rat, 9003, 25);
                AddLootItem(rat, 9004, 75);

                return rat;
            case 3:
                Monster giantSpider = _monsters.Find(item => item.Id == monsterID);
                AddLootItem(giantSpider, 9005, 25);
                AddLootItem(giantSpider, 9006, 75);

                return giantSpider;
            default:
                throw new ArgumentException(string.Format("MonsterType '{0}' doest not exist", monsterID));
         
        }
    }

    private static void AddLootItem(Monster monster, int itemID, int percentage)
    {
        if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
        {
            monster.AddItemToInventory(ItemFactory.CreateGameItem(itemID));
        }
    }
}