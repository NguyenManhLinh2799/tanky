using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    GameSelection gameSelection;

    // Start is called before the first frame update
    void Awake()
    {
        gameSelection = FindObjectOfType<GameSelection>();

        // Set up player 1 passive
        Passive player1Passive = gameSelection.FindPassiveByName(gameSelection.player1PassiveName);
        player1.GetComponent<PlayerPassive>().passivePrefab = player1Passive.passivePrefab;

        // Set up player 2 passive
        Passive player2Passive = gameSelection.FindPassiveByName(gameSelection.player2PassiveName);
        player2.GetComponent<PlayerPassive>().passivePrefab = player2Passive.passivePrefab;

        // Set up player 1 items
        var player1ItemPrefabs = player1.GetComponent<Inventory>().itemPrefabs;
        foreach (string itemName in gameSelection.player1ItemNames)
        {
            Item item = gameSelection.FindItemByName(itemName);
            player1ItemPrefabs.Add(item.itemPrefab);
        }

        // Set up player 2 items
        var player2ItemPrefabs = player2.GetComponent<Inventory>().itemPrefabs;
        foreach (string itemName in gameSelection.player2ItemNames)
        {
            Item item = gameSelection.FindItemByName(itemName);
            player2ItemPrefabs.Add(item.itemPrefab);
        }
    }
}
