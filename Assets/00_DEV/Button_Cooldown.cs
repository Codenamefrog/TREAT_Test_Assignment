using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Button_Cooldown : MonoBehaviour
{
    [SerializeField]
    Button myButton;
    [SerializeField]
    Animator ButtonAnimator;
    [SerializeField]
    float cooldownDuration = 5.0f;
    [SerializeField]
    Button OtherButton1;
    [SerializeField]
    Button OtherButton2;
     [SerializeField]
    Animator OtherAnimator1;
    [SerializeField]
    Animator OtherAnimator2;
     [SerializeField]

    void Awake()
    {
        // Get a reference to your button
        myButton = GetComponent<Button>();
        
        if (myButton != null)
        {
            // Listen to its onClick event
            myButton.onClick.AddListener(OnButtonClick);
        }
    }

    // This method is called whenever myButton is pressed
    void OnButtonClick()
    {
        StartCoroutine(Cooldown());
    }

    // Coroutine that will deactivate and reactivate the button 
    IEnumerator Cooldown()
    {
        OtherAnimator1.SetBool("Waiting",true);
        OtherAnimator2.SetBool("Waiting",true);
        OtherButton1.interactable = false;
        OtherButton2.interactable = false;
       

        // Deactivate myButton
        myButton.interactable = false;
        // Wait for cooldown duration
        yield return new WaitForSeconds(cooldownDuration);
        ButtonAnimator.SetTrigger("Activated");
        // Reactivate myButton
        yield return new WaitForSeconds(0.5f);
        myButton.interactable = true;
        OtherAnimator1.SetBool("Waiting",false);
        OtherAnimator2.SetBool("Waiting",false);
        OtherButton1.interactable = true;
        OtherButton2.interactable = true;
    }
}