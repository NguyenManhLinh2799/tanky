﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelection : MonoBehaviour
{
    public Map[] maps;
    public Passive[] passives;
    public Item[] items;

    public string gameMode;

    public string map;

    public string player1PassiveName;
    public string player2PassiveName;

    public List<string> player1ItemNames;
    public List<string> player2ItemNames;

    void Awake()
    {
        var instances = FindObjectsOfType<GameSelection>();
        if (instances.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        gameMode = "";
        map = "";
        player1PassiveName = "";
        player2PassiveName = "";
        player1ItemNames.Clear();
        player2ItemNames.Clear();
    }

    public void SetGameMode(string gameMode)
    {
        FindObjectOfType<GameSelection>().gameMode = gameMode;
    }

    public void SetMap(string map)
    {
        FindObjectOfType<GameSelection>().map = map;
    }

    public void SetPlayer1Passive(string passive)
    {
        FindObjectOfType<GameSelection>().player1PassiveName = passive;
    }

    public void SetPlayer2Passive(string passive)
    {
        FindObjectOfType<GameSelection>().player2PassiveName = passive;
    }

    public void AddPlayer1Item(string item)
    {
        GameSelection gameSelection = FindObjectOfType<GameSelection>();

        if (gameSelection.player1ItemNames.Contains(item))
        {
            gameSelection.player1ItemNames.Remove(item);
            return;
        }


        gameSelection.player1ItemNames.Add(item);
    }

    public void AddPlayer2Item(string item)
    {
        GameSelection gameSelection = FindObjectOfType<GameSelection>();

        if (gameSelection.player2ItemNames.Contains(item))
        {
            gameSelection.player2ItemNames.Remove(item);
            return;
        }


        gameSelection.player2ItemNames.Add(item);
    }

    public Map FindMapByName(string name)
    {
        foreach (var map in maps)
        {
            if (map.mapName == name)
            {
                return map;
            }
        }
        return null;
    }

    public Passive FindPassiveByName(string name)
    {
        foreach (Passive passive in passives)
        {
            if (passive.passiveName == name)
            {
                return passive;
            }
        }
        return null;
    }

    public Item FindItemByName(string name)
    {
        foreach (Item item in items)
        {
            if (item.itemName == name)
            {
                return item;
            }
        }
        return null;
    }
}
