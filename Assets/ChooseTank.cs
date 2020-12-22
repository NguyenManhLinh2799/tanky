using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseTank : MonoBehaviour
{
    public Sprite[] sprite;
    // Start is called before the first frame update
    
    public void setChooseTank(string tankName)
    {
        gameObject.GetComponent<Image>().enabled = true;
        if (tankName == "Bloodthirst")
        {
            gameObject.GetComponent<Image>().sprite = sprite[0];
        }else if(tankName == "Cheater")
        {
            gameObject.GetComponent<Image>().sprite = sprite[1];
        }
        else if (tankName == "Disable")
        {
            gameObject.GetComponent<Image>().sprite = sprite[2];
        }
        else if (tankName == "Ghost Rider")
        {
            gameObject.GetComponent<Image>().sprite = sprite[3];
        }
        else if (tankName == "Intensity")
        {
            gameObject.GetComponent<Image>().sprite = sprite[4];
        }
        else if (tankName == "Venom")
        {
            gameObject.GetComponent<Image>().sprite = sprite[5];
        }
    }
}
