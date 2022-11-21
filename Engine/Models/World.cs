using System.Collections.Generic;

namespace Engine.Models;

public class World
{
    private List<Location> _locations = new List<Location>();

    internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
    {
        Location loc = new Location();
        loc.XCoordinate = xCoordinate;
        loc.YCoordinate = yCoordinate;
        loc.Name = name;
        loc.Description = description;
        loc.ImageName = imageName;
        
        _locations.Add(loc);
    }

    internal Location LocationAt(int xCoordinate, int yCoordinate)
    {
        foreach (Location loc in _locations)
        {
            if (loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate)
            {
                return loc;
            }
        }

        return null;
    }
}