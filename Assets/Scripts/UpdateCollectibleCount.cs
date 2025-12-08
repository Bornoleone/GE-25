using UnityEngine;
using TMPro;
using System;

public class UpdateCollectibleCount : MonoBehaviour
{
    int stars = 0;
    public TextMeshProUGUI collectibleCountTextMesh;
    public TextMeshProUGUI winTextMesh;


    void Start()
    {
        UpdateCollCount();
    }

    void Update()
    {
        if(stars == 10)
        {
            winTextMesh.text = "Congratulations! You Win!";
        }
    }

    public void UpdateCollCount()
    {
        collectibleCountTextMesh.text = "" + stars;
    }

    public void AddCollectibleCount()
    {

        stars = stars + 1;
        Debug.Log("current star count " + stars);
        UpdateCollCount();
    }
}
