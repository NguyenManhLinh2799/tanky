using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInventory : Inventory
{
    public bool isDelayed = false;

    // Update is called once per frame
    protected override void Update()
    {
        manaBarImg.fillAmount = currentMana / maxMana;
        if (GetComponent<Move>().isMyTurn)
        {
            if (!isDelayed)
            {
                if (!isDisabled && currentMana >= manaPerItem)
                {
                    int sample = Random.Range(0, 4);
                    switch (sample)
                    {
                        case 0: LaunchProjectile(); break;
                        case 1: Activate(itemPrefabs[0]); break;
                        case 2: Activate(itemPrefabs[1]); break;
                        case 3: Activate(itemPrefabs[2]); break;
                    }
                }
                else
                {
                    LaunchProjectile();
                }
            }
        }
    }
}
