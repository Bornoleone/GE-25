using System;
using UnityEngine;

public class PlayerSwapper : MonoBehaviour
{
    [Tooltip("First player setup will active when started")]
    [SerializeField] private GameObject[] playerSetups;
    [SerializeField] private int activePlayerSetup;
    [SerializeField] private KeyCode playerChangeButton = KeyCode.Y;

	private void Start()
	{
        foreach (var playerSetup in playerSetups)
        {
            playerSetup.SetActive(false);
        }
        playerSetups[0].SetActive(true);
        activePlayerSetup = 0;

	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(playerChangeButton))
        {
            SetNextPlayerSetupActive();
        }
    }

	private void SetNextPlayerSetupActive()
	{
		playerSetups[activePlayerSetup].SetActive(false);
		print(activePlayerSetup);
		print(playerSetups.Length - 1);
		print((activePlayerSetup + 1) % (playerSetups.Length - 1));
		activePlayerSetup = (activePlayerSetup + 1) % (playerSetups.Length);

		playerSetups[activePlayerSetup].SetActive(true);



	}
}
