﻿namespace Engine.Models;

public class Weapon : GameItem
{
    
    public int MinimumDamage { get; }
    public int MaximumDamage { get; }
    
    public Weapon(int itemTypeId, string name, int price, int minDamage, int maxDamage) : base(itemTypeId, name, price, true)
    {
        MinimumDamage = minDamage;
        MaximumDamage = maxDamage;
    }

    public new Weapon Clone()
    {
        return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
    }
}