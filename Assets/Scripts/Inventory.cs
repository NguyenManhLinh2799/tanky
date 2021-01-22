using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //References
    [SerializeField] protected float maxMana = 10f;
    public Image manaBarImg;
    [SerializeField] protected GameObject projectilePrefab;
    public List<GameObject> itemPrefabs;
    Transform cannonTransform;
    Transform barrelTransform;

    // Keys
    [SerializeField] KeyCode shootKey;
    [SerializeField] KeyCode activateItem1Key;
    [SerializeField] KeyCode activateItem2Key;
    [SerializeField] KeyCode activateItem3Key;

    public bool isDisabled = false;
    protected float manaPerItem = 3f;
    float manaRegenAmount = 1f;
    protected float currentMana;

    // Start is called before the first frame update
    void Start()
    {
        cannonTransform = GetComponent<Cannon>().cannonTransform;
        barrelTransform = GetComponent<Cannon>().barrelTransform;
        currentMana = maxMana;
    }

    // Update is called once per frame
    protected virtual void Update()
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

    protected void LaunchProjectile()
    {
        Instantiate(projectilePrefab, cannonTransform.position, cannonTransform.rotation);
        currentMana += manaRegenAmount;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    protected void Activate(GameObject itemPrefab)
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
