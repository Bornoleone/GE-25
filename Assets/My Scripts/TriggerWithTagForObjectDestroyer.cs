using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TriggerWithTagForObjectDestroyer : MonoBehaviour
{
    public string tagToCheck = "Spawner";
    //public UnityEvent onTriggerEvent;
    //public UnityEvent onTriggerExitEvent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCheck))
        {
            Debug.Log($"hit {tagToCheck}");
            Destroy(other.gameObject);
            // You can do here things you want to trigger
            //onTriggerEvent.Invoke();
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCheck))
        {
            Debug.Log($"{tagToCheck} left");
            // You can do here things you want to trigger
            onTriggerExitEvent.Invoke();
        }
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }*/
    
    
}
