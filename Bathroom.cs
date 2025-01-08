using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bathroom : MonoBehaviour
{

    private Light bathroomLight;
    public Interactions interactions;
    public TextMeshPro ID6Text;
    public TextMeshPro scaleText;
    
    void Start()
    {
        bathroomLight = GetComponent<Light>();
        ID6Text.gameObject.SetActive(false);
        scaleText.text = "TOO LIGHT";
    }

    // Update is called once per frame
    void Update()
    {      
        if(interactions.switched)
        {
            bathroomLight.color = new Color(.5f, 0, 1f);
            bathroomLight.intensity = 3;
            ID6Text.gameObject.SetActive(true);
            interactions.ID6 = true;
            scaleText.text = "JUST RIGHT";
        }
        else
        {
            bathroomLight.color = Color.white;
            bathroomLight.intensity = 1;
        }
    }
}
