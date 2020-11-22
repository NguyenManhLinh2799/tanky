using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelection : MonoBehaviour
{
    public enum TankType
    {
        FireTank,
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

    public TankType player1Type;
    public List<Item> player1Items;

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
        }
    }

    public void SetPlayer1Type(string type)
    {
        FindObjectOfType<GameSelection>().player1Type = StringToTankType(type);
    }

    public void AddPlayer1Item(string item)
    {
        FindObjectOfType<GameSelection>().player1Items.Add(StringToItem(item));
    }

    // Parse string
    public TankType StringToTankType(string type)
    {
        return (TankType) Enum.Parse(typeof(TankType), type);
    }

    public Item StringToItem(string type)
    {
        return (Item)Enum.Parse(typeof(Item), type);
    }
}
