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
    float cooldownDuration = 60f;

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
        // Deactivate myButton
        myButton.interactable = false;
        // Wait for cooldown duration
        yield return new WaitForSeconds(cooldownDuration);
        ButtonAnimator.SetTrigger("Activated");
        // Reactivate myButton
        yield return new WaitForSeconds(0.5f);
        myButton.interactable = true;
    }
}