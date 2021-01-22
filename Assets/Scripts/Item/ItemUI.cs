using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image[] player1ItemImgs;
    [SerializeField] Image[] player2ItemImgs;
    GameSelection gameSelection;

    // Start is called before the first frame update
    void Start()
    {
        gameSelection = FindObjectOfType<GameSelection>();

        for (int i = 0; i < player1ItemImgs.Length; i++)
        {
            var icon = gameSelection.FindItemByName(gameSelection.player1ItemNames[i]).icon;
            player1ItemImgs[i].sprite = icon;
        }

        for (int i = 0; i < player2ItemImgs.Length; i++)
        {
            var icon = gameSelection.FindItemByName(gameSelection.player2ItemNames[i]).icon;
            player2ItemImgs[i].sprite = icon;
        }
    }
}
