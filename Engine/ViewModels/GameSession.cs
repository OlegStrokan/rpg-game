using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Engine.EventArgs;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels;

public class GameSession : BaseNotification
{
    public event EventHandler<GameMessageEventArgs> OnMessageRaised; 
    #region Properties
    
    private Location _currentLocation;
    private Monster _currentMonster;
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
            GivePlayerQuestsAtLocation();
            GetMonsterAtLocation();
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

        if (!CurrentPlayer.Weapons.Any())
        {
            CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
        }
        
        CurrentWorld = WorldFactory.CreateWorld();
        
        CurrentLocation = CurrentWorld.LocationAt(0, 0);
    }

    public Weapon CurrentWeapon { get; set; }
    public Monster CurrentMonster
    {
        get { return _currentMonster; }
        set
        {
            _currentMonster = value;
            
            OnPropertyChanged(nameof(CurrentMonster));
            OnPropertyChanged(nameof(HasMonster));

            if (CurrentMonster != null) 
            {
                RaiseMessage("");
                RaiseMessage($"You see a {CurrentMonster.Name} here!");
            }
        }
    }

    public bool HasMonster => CurrentMonster != null;

    #endregion
    public bool HasLocationToNorth =>
        CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
      
    public bool HasLocationToEast => 
        CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
     
    public bool HasLocationToSouth => 
        CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        
    public bool HasLocationToWest =>
        CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;

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

    public void GivePlayerQuestsAtLocation()
    {
        foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
        {
            if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
            {
                CurrentPlayer.Quests.Add(new QuestStatus(quest));
            }
        }
    }
    public void GetMonsterAtLocation()
    {
        CurrentMonster = CurrentLocation.GetMonster();
    }

    public void RaiseMessage(string message)
    {
        OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
    }

    public void AttackCurrentMonster()
    {
        if (CurrentWeapon == null)
        {
            RaiseMessage("You must select a weapon, to attack");
            return;
        }

        int damageToMonster =
            RandomNumberGenerator.NumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);

        if (damageToMonster == 0)
        {
            RaiseMessage($"You missed the {CurrentMonster.Name}");
        }
        else
        {
            CurrentMonster.HitPoints -= damageToMonster;
            RaiseMessage($"You hit the {CurrentMonster.Name} for {damageToMonster} points. ");
        }

        if (CurrentMonster.HitPoints <= 0)
        {
            RaiseMessage("");
            RaiseMessage($"You defeated the {CurrentMonster.Name}");

            CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExperiencePoints;
            RaiseMessage($"You receive {CurrentMonster.RewardExperiencePoints}");

            CurrentPlayer.Gold += CurrentMonster.RewardGold;
            RaiseMessage($"You receive {CurrentMonster.RewardGold}");

            foreach (ItemQuantity itemQuantity in CurrentMonster.Inventory)
            {
                GameItem item = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                CurrentPlayer.AddItemToInventory(item);
            }

            GetMonsterAtLocation();
        }
        else
        {
            int damageToPlayer = RandomNumberGenerator.NumberBetween(CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);

            if (damageToPlayer == 0)
            {
                RaiseMessage("The monster attacks, but missed you");
            }

            else
            {
                CurrentPlayer.HitPoints -= damageToPlayer;
                RaiseMessage($"The {CurrentMonster.Name} hit you for {damageToPlayer} points.");
            }

            if (CurrentPlayer.HitPoints <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"The {CurrentMonster.Name} killed you.");

                CurrentLocation = CurrentWorld.LocationAt(0, -1);
                CurrentPlayer.HitPoints = CurrentPlayer.Level * 10;
            }

        }
    }
}