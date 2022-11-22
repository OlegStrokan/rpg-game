using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels;

public class GameSession : BaseNotification
{
    private Location _currentLocation;
    public Player CurrentPlayer { get; set; }

    public Location CurrentLocation
    {
        get { return this._currentLocation; }
        set
        {
            _currentLocation = value;
            OnPropertyChanged(nameof(CurrentLocation));
            OnPropertyChanged(nameof(HasLocationToNorth));
            OnPropertyChanged(nameof(HasLocationToEast));
            OnPropertyChanged(nameof(HasLocationToSouth));
            OnPropertyChanged(nameof(HasLocationToWest));
        }
    }
    
    public World CurrentWorld { get; set; }


    public GameSession()
    {
        CurrentPlayer = new Player
        {
           Name = "Oleh",
            Gold = 1000,
            Level = 1,
            CharacterClass = "Wizard",
            HitPoints = 10,
            ExperiencePoints = 2,       
        };
     
        
        CurrentWorld = WorldFactory.CreateWorld();

        CurrentLocation = CurrentWorld.LocationAt(0, -1);

    
    }

    public bool HasLocationToNorth
    {
        get
        {
            return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
        }
    }   
    public bool HasLocationToEast
    {
        get
        {
            return CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
        }
    }    
    public bool HasLocationToSouth
    {
        get
        {
            return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        }
    }  
    public bool HasLocationToWest
    {
        get
        {
            return CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
        }
    }

    public void MoveNorth()
    {
        if (HasLocationToNorth)
        {
             CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }
       
    }
    public void MoveEast()
    {
        if (HasLocationToEast)
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }
    }
    public void MoveSouth()
    {
        if (HasLocationToSouth)
        {
             CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }
       
    }
    public void MoveWest()
    {
        if (HasLocationToWest)
        {
             CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }
       
    }

}