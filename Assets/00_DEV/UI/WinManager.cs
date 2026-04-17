using System.Collections; // Required for Coroutines
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject successObject;
    [SerializeField] private GameObject rewardObject;

    private HashSet<int> pressedIDs = new HashSet<int>();
    private bool hasWon = false;

    void Start()
    {
        if (winScreen != null) winScreen.SetActive(false);
        if (successObject != null) successObject.SetActive(true);
        if (rewardObject != null) rewardObject.SetActive(false);
    }

    public void RegisterButtonPress(int id)
    {
        if (hasWon) return;

        pressedIDs.Add(id);

        if (pressedIDs.Count >= 3)
        {
            hasWon = true; // Set this immediately to prevent double-triggering
            StartCoroutine(TriggerWinWithDelay(3f));
        }
    }

    // This runs in the background while the dog finishes its animation
    private IEnumerator TriggerWinWithDelay(float delay)
    {
        Debug.Log($"All conditions met! Waiting {delay} seconds for animation...");
        
        // Wait for the specified time
        yield return new WaitForSeconds(delay);

        if (winScreen != null)
        {
            winScreen.SetActive(true);
            Debug.Log("Win screen activated!");
        }
    }

    public void ClaimReward()
    {
        if (successObject != null && rewardObject != null)
        {
            successObject.SetActive(false);
            rewardObject.SetActive(true);
        }
    }

        public void BackToGame()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(false);
            Debug.Log("BackToGame!");
        }
    }
}