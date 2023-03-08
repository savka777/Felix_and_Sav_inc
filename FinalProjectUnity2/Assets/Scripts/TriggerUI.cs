using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
  public  GameObject winScreen;
    // Start is called before the first frame update


    void OnTriggerEnter(Collider other)
    {   
        
        if(other.tag == "Player")
        {
            winScreen.SetActive(true);
        }
    }
       
    }


