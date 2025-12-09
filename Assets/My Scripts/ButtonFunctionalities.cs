using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctionalities : MonoBehaviour
{
    public GameObject targetGameObject;

    public void ToggleTheTarget()
    { 
        targetGameObject.SetActive(!targetGameObject.activeSelf);
    }

    public void Activate()
    {
        targetGameObject.SetActive(true);
    }

    public void Deactivate()
	{
		targetGameObject.SetActive(false);        
	}
    public void ExitGame()
    {
        print("Exiting");
        Application.Quit();
    }
}
