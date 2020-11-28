using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //References
    [SerializeField] float maxMana = 10f;
    [SerializeField] float manaConsumptionAmount = 3f;
    [SerializeField] float manaRegenerationAmount = 1f;
    [SerializeField] Image manaBarImg;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] List<GameObject> items;
    Transform cannon;

    // Keys
    [SerializeField] KeyCode shootKey;
    [SerializeField] KeyCode activateItem1Key;
    [SerializeField] KeyCode activateItem2Key;
    [SerializeField] KeyCode activateItem3Key;

    public bool isDisabled = false;
    float currentMana;

    // Start is called before the first frame update
    void Start()
    {
        cannon = GetComponent<Cannon>().cannon;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        manaBarImg.fillAmount = currentMana / maxMana;
        if (GetComponent<Move>().isMyTurn)
        {
            if (Input.GetKeyDown(shootKey))
            {
                Instantiate(projectilePrefab, cannon.position, cannon.rotation);
                currentMana += manaRegenerationAmount;
                if (currentMana > maxMana)
                {
                    currentMana = maxMana;
                }
            }
            else if (Input.GetKeyDown(activateItem1Key) && !isDisabled && currentMana >= manaConsumptionAmount)
            {
                Instantiate(items[0], cannon.position, cannon.rotation);
                currentMana -= manaConsumptionAmount;
            }
            else if (Input.GetKeyDown(activateItem2Key) && !isDisabled && currentMana >= manaConsumptionAmount)
            {
                Instantiate(items[1], cannon.position, cannon.rotation);
                currentMana -= manaConsumptionAmount;
            }
            else if (Input.GetKeyDown(activateItem3Key) && !isDisabled && currentMana >= manaConsumptionAmount)
            {
                Instantiate(items[2], cannon.position, cannon.rotation);
                currentMana -= manaConsumptionAmount;
            }
        }
    }
}
