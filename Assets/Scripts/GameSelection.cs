using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelection : MonoBehaviour
{
    public enum GameMode
    {
        PvP,
        VsAI
    }

    public enum TankType
    {
        Ignition,
        Disable,
        Unstoppable,
        NoMercy,
        Bloodthirst,
        GhostRider,
        Excited,
        Cheater
    }

    public enum Item
    {
        Triple,
        C4,
        BigBoy,
        Signal,
        GasBomb,
        Venom,
        SuperGlue,
        Potion,
        Gasoline,
        Shield,
        Invisible
    }

    public GameMode gameMode;
    public TankType player1Type;
    public TankType player2Type;
    public List<Item> player1Items;
    public List<Item> player2Items;

    void Awake()
    {
        if (FindObjectsOfType<GameSelection>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            player1Items = new List<Item>();
            player2Items = new List<Item>();
        }
    }

    public void SetGameMode(string mode)
    {
        FindObjectOfType<GameSelection>().gameMode = StringToGameMode(mode);
    }

    public void SetPlayer1Type(string type)
    {
        FindObjectOfType<GameSelection>().player1Type = StringToTankType(type);
    }

    public void SetPlayer2Type(string type)
    {
        FindObjectOfType<GameSelection>().player2Type = StringToTankType(type);
    }

    public void AddPlayer1Item(string item)
    {
        FindObjectOfType<GameSelection>().player1Items.Add(StringToItem(item));
    }

    public void AddPlayer2Item(string item)
    {
        FindObjectOfType<GameSelection>().player2Items.Add(StringToItem(item));
    }

    // Parse string
    public GameMode StringToGameMode(string mode)
    {
        return (GameMode)Enum.Parse(typeof(GameMode), mode);
    }

    public TankType StringToTankType(string type)
    {
        return (TankType) Enum.Parse(typeof(TankType), type);
    }

    public Item StringToItem(string item)
    {
        return (Item)Enum.Parse(typeof(Item), item);
    }
}
