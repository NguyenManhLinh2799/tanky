using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //References
    [SerializeField] float maxMana = 10f;
    [SerializeField] Image manaBarImg;
    [SerializeField] GameObject projectilePrefab;
    public List<GameObject> itemPrefabs;
    Transform cannonTransform;

    // Keys
    [SerializeField] KeyCode shootKey;
    [SerializeField] KeyCode activateItem1Key;
    [SerializeField] KeyCode activateItem2Key;
    [SerializeField] KeyCode activateItem3Key;

    public bool isDisabled = false;
    float manaPerItem = 3f;
    float manaRegenAmount = 1f;
    float currentMana;

    // Start is called before the first frame update
    void Start()
    {
        cannonTransform = GetComponent<Cannon>().cannonTransform;
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
                LaunchProjectile();
            }
            else if (Input.GetKeyDown(activateItem1Key) && !isDisabled && currentMana >= manaPerItem)
            {
                Activate(itemPrefabs[0]);
            }
            else if (Input.GetKeyDown(activateItem2Key) && !isDisabled && currentMana >= manaPerItem)
            {
                Activate(itemPrefabs[1]);
            }
            else if (Input.GetKeyDown(activateItem3Key) && !isDisabled && currentMana >= manaPerItem)
            {
                Activate(itemPrefabs[2]);
            }
        }
    }

    private void LaunchProjectile()
    {
        Instantiate(projectilePrefab, cannonTransform.position, cannonTransform.rotation);
        currentMana += manaRegenAmount;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    private void Activate(GameObject itemPrefab)
    {
        Instantiate(itemPrefab, cannonTransform.position, itemPrefab.transform.rotation);
        ModifyMana(-manaPerItem);
    }

    public void ModifyMana(float deltaMana)
    {
        currentMana += deltaMana;
        currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
    }
}
