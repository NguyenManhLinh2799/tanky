using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //References
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] List<GameObject> items;
    Transform cannon;

    // Keys
    [SerializeField] KeyCode shootKey;
    [SerializeField] KeyCode activateItem1Key;
    [SerializeField] KeyCode activateItem2Key;
    [SerializeField] KeyCode activateItem3Key;

    public bool isDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        cannon = GetComponent<Cannon>().cannon;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Move>().isMyTurn)
        {
            if (Input.GetKeyDown(shootKey))
            {
                Instantiate(projectilePrefab, cannon.position, cannon.rotation);
            }
            else if (Input.GetKeyDown(activateItem1Key) && !isDisabled)
            {
                Instantiate(items[0], cannon.position, cannon.rotation);
            }
            else if (Input.GetKeyDown(activateItem2Key) && !isDisabled)
            {
                Instantiate(items[1], cannon.position, cannon.rotation);
            }
            else if (Input.GetKeyDown(activateItem3Key) && !isDisabled)
            {
                Instantiate(items[2], cannon.position, cannon.rotation);
            }
        }
    }
}
