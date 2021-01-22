using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUnstableArea : MonoBehaviour
{
	public float speed = 10f;
	public float timeToChange;
	public bool isLeft = false;
	public bool isNearToFar = true;
	float remainingTimeToChange;
    void Start()
    {
        remainingTimeToChange = timeToChange;
    }

    // Update is called once per frame
	int i = -1;
    void Update()
    {
		remainingTimeToChange -= Time.deltaTime;
		if(remainingTimeToChange<=0)
		{
			i++;
			remainingTimeToChange += timeToChange * 2;
			if(i == 4){
				i = 0;
			}
		}
		//Input.GetAxis("Horizontal")Input.GetAxis("Vertical")
		Vector2 director = new Vector2(0.0f, 0.0f);
		if(isNearToFar){
			if(i == -1){
			director = isLeft == true? new Vector2(0.0f, -1.0f) : new Vector2(0.0f, 1.0f);
			}else if(i==0){
				director = isLeft == true? new Vector2(-1.0f, 0.0f) : new Vector2(1.0f, 0.0f);
			}else if(i==1){
				director = isLeft == true? new Vector2(0.0f, 1.0f) : new Vector2(0.0f, -1.0f);
			}else if(i==2){
				director = isLeft == true? new Vector2(1.0f, 0.0f) : new Vector2(-1.0f, 0.0f);
			}else if(i==3){
				director = isLeft == true? new Vector2(0.0f, -1.0f) : new Vector2(0.0f, 1.0f);
			}
		}else{
			if(i == -1){
			director = isLeft == true? new Vector2(0.0f, -1.0f) : new Vector2(0.0f, 1.0f);
			}else if(i==0){
				director = isLeft == true? new Vector2(1.0f, 0.0f) : new Vector2(-1.0f, 0.0f);
			}else if(i==1){
				director = isLeft == true? new Vector2(0.0f, 1.0f) : new Vector2(0.0f, -1.0f);
			}else if(i==2){
				director = isLeft == true? new Vector2(-1.0f, 0.0f) : new Vector2(1.0f, 0.0f);
			}else if(i==3){
				director = isLeft == true? new Vector2(0.0f, -1.0f) : new Vector2(0.0f, 1.0f);
			}
		}
		
        moveIsland(director);

    }
	
	void moveIsland(Vector2 direction)
	{
		transform.Translate(direction * speed * Time.deltaTime);
		
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("vao");
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.transform.SetParent(this.transform);
		}
		else
		{
			other.gameObject.transform.SetParent(this.transform);
			if(other.gameObject.GetComponent<Molotov>())
			{
				other.gameObject.GetComponent<Molotov>().fireEffect.transform.SetParent(this.transform);
			}
		}
	}
	private void OnCollisionExit2D(Collision2D other)
	{
		other.gameObject.transform.SetParent(null);
	}
}
