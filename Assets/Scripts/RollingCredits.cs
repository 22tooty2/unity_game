using System.Collections;
using UnityEngine;
using TMPro;

public class RollingCredits : MonoBehaviour
{
    public TextMeshProUGUI creditsText;
    public float scrollSpeed = 20f;
    public GameObject button;

    private bool isScrolling = true;
    public string[] creditLines;
    private RectTransform creditsTransform;
    private int currentLineIndex;

    private void Start()
    {
        creditsTransform = creditsText.GetComponent<RectTransform>();
        creditsText.text = string.Join("\n", creditLines);
        StartCoroutine(ScrollCredits());
    }

    private IEnumerator ScrollCredits()
    {
        float screenHeight = Screen.height;
        float contentHeight = creditsText.preferredHeight;

        while (isScrolling)
        {
            Vector2 position = creditsTransform.anchoredPosition;
            position.y += scrollSpeed * Time.deltaTime;
            creditsTransform.anchoredPosition = position;

            if (position.y >= contentHeight - screenHeight / 2)
            {
                isScrolling = false;
                button.SetActive(true);
                break;
            }

            yield return null;
        }
    }
}
