using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PC : MonoBehaviour
{
    public GameObject rug;

    public Interactions interactions;

    public Button basementButton;

    public GameObject page0;

    public TextMeshPro idCountText;

    void Start()
    {
        rug.gameObject.SetActive(true);

        basementButton.gameObject.SetActive(false);

        page0.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Show buttons based on IDs
        int idCount = 0;
        if (interactions.ID1) idCount++;
        if (interactions.ID2) idCount++;
        if (interactions.ID3) idCount++;
        if (interactions.ID4) idCount++;
        if (interactions.ID5) idCount++;
        if (interactions.ID6) idCount++;

        idCountText.text = "IDs unlocked: " + idCount.ToString() + "/6";

        basementButton.gameObject.SetActive(interactions.ID1 && interactions.ID2 && interactions.ID3 && interactions.ID4 && interactions.ID5 && interactions.ID6);
    }

    public void OnBasementClick()
    {
        rug.gameObject.SetActive(false);
    }
}
