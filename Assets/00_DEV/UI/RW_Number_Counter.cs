using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine.Rendering;
using Coffee.UIExtensions;

public class RW_Number_Counter : MonoBehaviour
{
    [SerializeField]
    TMP_Text field;
    [SerializeField]
    float targetScore;
    [SerializeField]
     float currentDisplayScore = 1f;
    
    public bool check { get; set; }
     


    void Start()
    {
        
        StartCoroutine(CountUpToTarget()); 
       
    }


    IEnumerator CountUpToTarget()
    {
        while (currentDisplayScore < targetScore)
        {

                currentDisplayScore += Time.deltaTime*200; // or whatever to get the speed you like
                currentDisplayScore = Mathf.Clamp(currentDisplayScore, 0f, targetScore);
                field.text = Mathf.RoundToInt(currentDisplayScore) + "";
                yield return null;
            

        }

    }

}