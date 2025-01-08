using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseLight : MonoBehaviour
{
    private Light light;
    private float dotDuration = .5f;
    private float dashDuration = 1f;
    private float symbolOffDuration = .25f; //X
    private float letterOffDuration = 1f; //Y
    private float resetDuration = 4f; //Z
    private string morse = "-X.X-X.Y.X-Y-Z";

    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(PlayMorseCode());
    }

    
   IEnumerator PlayMorseCode()
    {
        while (true)
        {
            foreach (char symbol in morse)
            {
                switch (symbol)
                {
                    case '.':
                        yield return StartCoroutine(BlinkLight(dotDuration));
                        break;
                    case '-':
                        yield return StartCoroutine(BlinkLight(dashDuration));
                        break;
                    case 'X':
                        yield return new WaitForSeconds(symbolOffDuration);
                        break;
                    case 'Y':
                        yield return new WaitForSeconds(letterOffDuration);
                        break;
                    case 'Z':
                        yield return new WaitForSeconds(resetDuration);
                        break;
                }
            }
        }
    }
    IEnumerator BlinkLight(float duration)
    {
        light.enabled = true;
        yield return new WaitForSeconds(duration);
        light.enabled = false;
        yield return new WaitForSeconds(symbolOffDuration);
    }
}
