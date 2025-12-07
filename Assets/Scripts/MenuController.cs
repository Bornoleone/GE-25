using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuParent;
    public KeyCode toggleKey = KeyCode.P;
    //public bool hasBeenPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleTheTarget();  
        }
    }

	public void ToggleTheTarget()
	{
        if (!menuParent.activeSelf) //(!hasBeenPaused)
        {
            //hasBeenPaused = true;
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;//unlock cursor
            Cursor.visible = true;//cursor visible
            //menuParent.SetActive(true);
        }
        else
        {
            //hasBeenPaused = false;
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;//lock cursor
            Cursor.visible = false;//cursor unvisible
            //menuParent.SetActive(false);
        }
        
		menuParent.SetActive(!menuParent.activeSelf);
	}
}
