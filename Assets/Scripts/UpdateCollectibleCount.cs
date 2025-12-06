using UnityEngine;
using TMPro;
using System;

public class UpdateCollectibleCount : MonoBehaviour
{
    int stars = 0;
    public TextMeshProUGUI collectibleCountTextMesh;
    

    void Start()
    {
        UpdateCollCount();
    }

    void Update()
    {
        
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
