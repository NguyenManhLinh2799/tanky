using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitThenScale());
    }

    IEnumerator WaitThenScale()
    {
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(1.5f, 1.5f, 0f);
        Bullet bulletComponent = GetComponent<Bullet>();
        bulletComponent.SetDamage(bulletComponent.GetDamage() * 1.5f);
        Destroy(this);
    }
}
