using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.SceneManagement;

public class NavBTN : MonoBehaviour
{
    public void ButtonMainMenu()
    {
        Debug.Log("Click 1");
       SceneManager.LoadScene(0);

    }

    public void ButtonRestart()
    {
        Debug.Log("Click 2");
        //Lightmapping.ClearLightingDataAsset();
        SceneManager.LoadScene(1);
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     
    }
}
