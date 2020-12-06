using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheater : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab;
    GameObject self;
    GamePhase gamePhase;
    float probability = 0.2f;
    bool cheated = false;

    // Start is called before the first frame update
    void Start()
    {
        self = transform.parent.gameObject;
        gamePhase = FindObjectOfType<GamePhase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (self.GetComponent<Move>().isMyTurn && !cheated)
        {
            int sample = Random.Range(0, (int)(1 / probability));
            if (sample == 0)
            {
                gamePhase.isPlayer1Turn = !gamePhase.isPlayer1Turn;
                Instantiate(effectPrefab, transform.position, effectPrefab.transform.rotation);
            }
            cheated = true;
        }
        else if (!self.GetComponent<Move>().isMyTurn && cheated)
        {
            cheated = false;
        }
    }
}
