using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DogAnimController_test : MonoBehaviour
{
    [SerializeField] Animator dogAnim;
    [SerializeField] Button BtnBark;
    [SerializeField] Button BtnRoll;
    [SerializeField] Button BtnSpin;

    // Trackers for our idle system
    private float idleTimer = 0f;
    private bool isAnimating = false;

    void Awake()
    {
        if (dogAnim == null) dogAnim = GetComponent<Animator>();

        if (BtnRoll != null && BtnBark != null && BtnSpin != null)
        {
            BtnRoll.onClick.AddListener(() => OnActionButtonClicked(1));
            BtnBark.onClick.AddListener(() => OnActionButtonClicked(2));
            BtnSpin.onClick.AddListener(() => OnActionButtonClicked(3));
        }
    }

    // Update runs every frame
    void Update()
    {
        // Only count up the idle timer if the dog isn't currently doing a trick
        if (!isAnimating)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= 10f)
            {
                TriggerIdleSit();
            }
        }
    }

    void OnActionButtonClicked(int animState)
    {
        StopAllCoroutines(); 
        
        // Reset the idle timer as soon as a user clicks a button
        idleTimer = 0f; 
        
        StartCoroutine(PlayAnimationSequence(animState));
    }

    void TriggerIdleSit()
    {
        // Reset the timer so it doesn't spam this trigger every frame after 10 seconds
        idleTimer = 0f; 
        
        dogAnim.SetInteger("Sit_ID", Random.Range(0, 3));
        dogAnim.SetTrigger("Sit");
    }

    IEnumerator PlayAnimationSequence(int animState)
    {
        isAnimating = true;
        dogAnim.SetBool("ButPressed", true);

        if (animState == 1) // Roll
        {
            dogAnim.SetTrigger("ToSit");
            dogAnim.SetInteger("Com_ID", 1);
        }
        else if (animState == 2) // Bark
        {
            dogAnim.SetInteger("Com_ID", 0);
            dogAnim.SetTrigger("ToStand");
        }
        else if (animState == 3) // Spin
        {
            dogAnim.SetTrigger("ToStand");
            dogAnim.SetInteger("Com_ID", 2);
        }

        // Wait for the 3-second animation to finish
        yield return new WaitForSeconds(3f);
        
        // Reset the dog's states so it's ready for the next trick or idle
        dogAnim.SetBool("ButPressed", false);
        isAnimating = false;
        
        // Reset the idle timer again so the dog doesn't instantly sit right after finishing a trick
        idleTimer = 0f; 
    }
}