using System.Collections.Generic;
using UnityEngine;

public class ColorCombinationLock : MonoBehaviour
{
    public List<Color> correctCombination; // The correct color combination to unlock the door/container
    public List<Color> playerCombination; // The player's current color combination
    public Light[] feedbackLights; // Array of lights to provide feedback to the player

    public GameObject door;

    private void Start()
    {
        ResetCombination();
    }

    public void AddColorToCombination(Color color)
    {
        feedbackLights[playerCombination.Count].color = color;
        playerCombination.Add(color);

        // Check if the player's combination matches the correct combination
        if (playerCombination.Count == correctCombination.Count)
        {
            bool combinationCorrect = true;

            for (int i = 0; i < playerCombination.Count; i++)
            {
                if (playerCombination[i] != correctCombination[i])
                {
                    combinationCorrect = false;
                    break;
                }
            }

            if (combinationCorrect)
            {
                Unlock();
            }
            else
            {
                ResetCombination();
                // Provide feedback to the player (e.g., turn on the feedback lights to indicate an incorrect combination)
                foreach (Light light in feedbackLights)
                {
                    light.color = Color.red;
                }

                Invoke("ResetCombination", 3f);
            }
        }
    }

    private void Unlock()
    {
        // Unlock the door or reveal the hidden item
        Debug.Log("The door/container is unlocked!");

        foreach (Light light in feedbackLights)
        {
            light.color = Color.green;
        }

        Destroy(door);
    }

    private void ResetCombination()
    {
        playerCombination.Clear();
        // Reset the feedback lights (e.g., turn off the lights)
        foreach (Light light in feedbackLights)
        {
            light.color = Color.white;
        }
    }
}
