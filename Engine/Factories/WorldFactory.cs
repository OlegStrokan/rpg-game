using System.Net;
using Engine.Models;
using Engine.Utils;

namespace Engine.Factories;

internal static class WorldFactory
{
    internal static World CreateWorld()
    {
        return ConvertToLocation.ConvertData("locations.json", new World());
    }
}