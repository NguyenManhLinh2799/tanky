using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundpos : MonoBehaviour
{
    // Start is called before the first frame update
	public Transform[] resPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter2D(Collider2D other)
    {
        Transform transPlayer = other.GetComponent<Transform>();
        
        if (other.tag == "Player")
        {
		int index = Random.Range(0,6);
        	transPlayer.position = resPosition[index].position;
        }
    }
}
