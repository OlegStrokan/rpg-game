using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Models;
using Engine.Utils;

namespace Engine.Factories;

public static class TraderFactory
{
    private static readonly List<Trader> _traders = new List<Trader>();

    static TraderFactory()
    {

        List<Trader> traders = new List<Trader>(ConvertToTrader.ConvertData("traders.json"));
        
        foreach (Trader trader in traders)
        {
            AddTraderToList(trader);
        }
    }

    public static Trader GetTraderByName(string name)
    {
        return _traders.FirstOrDefault(t => t.Name == name);
    }

    public static void AddTraderToList(Trader trader)
    {
        if (_traders.Any(t => t.Name == trader.Name))
        {
            throw new ArgumentException($"There is already a trader named '{trader.Name}'");
        }

        _traders.Add(trader);
    }
}