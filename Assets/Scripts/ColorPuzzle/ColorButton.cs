using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public Color buttonColor; // The color assigned to this button
    public ColorCombinationLock lockScript; // Reference to the ColorCombinationLock script

    private void OnMouseDown()
    {
        lockScript.AddColorToCombination(buttonColor);
    }
}
