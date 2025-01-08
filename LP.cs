using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LP : MonoBehaviour
{

    public Button CU;
    public Button CD;
    public Button AU;
    public Button AD;
    public Button TU;
    public Button TD;

    public TextMeshPro cL;
    public TextMeshPro aL;
    public TextMeshPro tL;

    public TextMeshProUGUI passwordCorrect;

    private char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private int cIndex = 2;
    private int aIndex = 0;
    private int tIndex = 0;

    public Interactions interactions;

    private void Start()
    {
        CU.onClick.AddListener(CUClick);
        CD.onClick.AddListener(CDClick);
        AU.onClick.AddListener(AUClick);
        AD.onClick.AddListener(ADClick);
        TU.onClick.AddListener(TUClick);
        TD.onClick.AddListener(TDClick);
        passwordCorrect.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(cL.text == "C" && aL.text == "A" && tL.text == "T")
        {
            CU.gameObject.SetActive(false);
            CD.gameObject.SetActive(false);
            AU.gameObject.SetActive(false);
            AD.gameObject.SetActive(false);
            TU.gameObject.SetActive(false);
            TD.gameObject.SetActive(false);
            passwordCorrect.gameObject.SetActive(true);
            interactions.ID5 = true;
        }
    }

    void CUClick()
    {
        cIndex = (cIndex + 1) % letters.Length;
        cL.text = letters[cIndex].ToString();
    }
    void CDClick()
    {
        cIndex = (cIndex - 1 + letters.Length) % letters.Length;
        cL.text = letters[cIndex].ToString();
    }
    void AUClick()
    {
        aIndex = (aIndex + 1) % letters.Length;
        aL.text = letters[aIndex].ToString();
    }
    void ADClick()
    {
        aIndex = (aIndex - 1 + letters.Length) % letters.Length;
        aL.text = letters[aIndex].ToString();
    }
    void TUClick()
    {
        tIndex = (tIndex + 1) % letters.Length;
        tL.text = letters[tIndex].ToString();
    }
    void TDClick()
    {
        tIndex = (tIndex - 1 + letters.Length) % letters.Length;
        tL.text = letters[tIndex].ToString();
    }
}
