using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    [SerializeField] GameObject player1Prefab;
    [SerializeField] GameObject player2Prefab;
    [SerializeField] GameObject AIPrefab;

    GameSelection gameSelection;
    GamePhase gamePhase;

    // Start is called before the first frame update
    void Awake()
    {
        gameSelection = FindObjectOfType<GameSelection>();
        gamePhase = FindObjectOfType<GamePhase>();

        SetupMap();

        SetupPlayer1();

        if (gameSelection.gameMode == "PvP")
        {
            SetupPlayer2();
        }
        else if (gameSelection.gameMode == "AI")
        {
            SetupAI();
        }
    }

    void SetupMap()
    {
        var map = gameSelection.FindMapByName(gameSelection.map);
        Instantiate(map.mapPrefab, transform.position, Quaternion.identity);
    }

    private void SetupAI()
    {
        var AI = Instantiate(AIPrefab, new Vector3(35f, 0f, 0f), AIPrefab.transform.rotation);

        // Set health, gasoline, mana bar, power slider
        AI.GetComponent<Health>().healthBarImg = GameObject.Find("Health Bar Image 2").GetComponent<Image>();
        AI.GetComponent<Move>().gasolineBarImg = GameObject.Find("Gasoline Bar Image 2").GetComponent<Image>();
        AI.GetComponent<AIInventory>().manaBarImg = GameObject.Find("Mana Bar Image 2").GetComponent<Image>();
        AI.GetComponent<AICannon>().powerSlider = GameObject.Find("Power Slider 2").GetComponent<Slider>();

        // Set up player 2 passive
        Passive AIPassive = gameSelection.FindPassiveByName(gameSelection.player2PassiveName);
        var AIPassiveComponent = AI.GetComponent<PlayerPassive>();
        AIPassiveComponent.passivePrefab = AIPassive.passivePrefab;
        AIPassiveComponent.R = AIPassive.R;
        AIPassiveComponent.G = AIPassive.G;
        AIPassiveComponent.B = AIPassive.B;

        // Set up player 2 items
        var AIItemPrefabs = AI.GetComponent<AIInventory>().itemPrefabs;
        foreach (string itemName in gameSelection.player2ItemNames)
        {
            Item item = gameSelection.FindItemByName(itemName);
            AIItemPrefabs.Add(item.itemPrefab);
        }

        // Set up game phase
        gamePhase.player2 = AI;
    }

    private void SetupPlayer2()
    {
        var player2 = Instantiate(player2Prefab, new Vector3(35f, 0f, 0f), player2Prefab.transform.rotation);

        // Set health, gasoline, mana bar, power slider
        player2.GetComponent<Health>().healthBarImg = GameObject.Find("Health Bar Image 2").GetComponent<Image>();
        player2.GetComponent<Move>().gasolineBarImg = GameObject.Find("Gasoline Bar Image 2").GetComponent<Image>();
        player2.GetComponent<Inventory>().manaBarImg = GameObject.Find("Mana Bar Image 2").GetComponent<Image>();
        player2.GetComponent<Cannon>().powerSlider = GameObject.Find("Power Slider 2").GetComponent<Slider>();

        // Set up player 2 passive
        Passive player2Passive = gameSelection.FindPassiveByName(gameSelection.player2PassiveName);
        var player2PassiveComponent = player2.GetComponent<PlayerPassive>();
        player2PassiveComponent.passivePrefab = player2Passive.passivePrefab;
        player2PassiveComponent.R = player2Passive.R;
        player2PassiveComponent.G = player2Passive.G;
        player2PassiveComponent.B = player2Passive.B;

        // Set up player 2 items
        var player2ItemPrefabs = player2.GetComponent<Inventory>().itemPrefabs;
        foreach (string itemName in gameSelection.player2ItemNames)
        {
            Item item = gameSelection.FindItemByName(itemName);
            player2ItemPrefabs.Add(item.itemPrefab);
        }

        // Set up game phase
        gamePhase.player2 = player2;
    }

    private void SetupPlayer1()
    {
        var player1 = Instantiate(player1Prefab, new Vector3(-35f, 0f, 0f), player1Prefab.transform.rotation);

        // Set health, gasoline, mana bar, power slider
        player1.GetComponent<Health>().healthBarImg = GameObject.Find("Health Bar Image 1").GetComponent<Image>();
        player1.GetComponent<Move>().gasolineBarImg = GameObject.Find("Gasoline Bar Image 1").GetComponent<Image>();
        player1.GetComponent<Inventory>().manaBarImg = GameObject.Find("Mana Bar Image 1").GetComponent<Image>();
        player1.GetComponent<Cannon>().powerSlider = GameObject.Find("Power Slider 1").GetComponent<Slider>();

        // Set up player 1 passive
        Passive player1Passive = gameSelection.FindPassiveByName(gameSelection.player1PassiveName);
        var player1PassiveComponent = player1.GetComponent<PlayerPassive>();
        player1PassiveComponent.passivePrefab = player1Passive.passivePrefab;
        player1PassiveComponent.R = player1Passive.R;
        player1PassiveComponent.G = player1Passive.G;
        player1PassiveComponent.B = player1Passive.B;

        // Set up player 1 items
        var player1ItemPrefabs = player1.GetComponent<Inventory>().itemPrefabs;
        foreach (string itemName in gameSelection.player1ItemNames)
        {
            Item item = gameSelection.FindItemByName(itemName);
            player1ItemPrefabs.Add(item.itemPrefab);
        }

        // Set up game phase
        gamePhase.player1 = player1;
    }
}
