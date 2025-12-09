using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	private string sceneToLoad;
	public bool loadSceneAdditively = true;

	public void LoadTargetScene(string sceneToLoad)
	{
		if (loadSceneAdditively)
		{
			SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
		}
		else
		{
			SceneManager.LoadScene(sceneToLoad);
		}
	}

	public void UnLoadTargetScene(string sceneToLoad)
	{
		SceneManager.UnloadSceneAsync(sceneToLoad);
	}
}
