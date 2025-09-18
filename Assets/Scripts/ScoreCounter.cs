using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;

    private TextMeshProUGUI uiText; //change the text to text mesh pro 


    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>(); //change from text to text mesh 
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0"); //this is a zero 
    }
}
