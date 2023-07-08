using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [System.Serializable]
    public class DialogueItem
    {
        public bool isText;
        public string text;
        public Sprite image;
    }

    public TextMeshProUGUI dialogueText;
    public Image dialogueImage;
    public List<DialogueItem> dialogueItems;
    public GameObject dialogueObject;
    private int currentItemIndex = 0;

    private void Update()
    {
        if (dialogueItems[currentItemIndex].isText)
        {
            dialogueText.gameObject.SetActive(true);
            dialogueImage.gameObject.SetActive(false);
            dialogueText.text = dialogueItems[currentItemIndex].text;
        }
        else
        {
            dialogueText.gameObject.SetActive(false);
            dialogueImage.gameObject.SetActive(true);
            dialogueImage.sprite = dialogueItems[currentItemIndex].image;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentItemIndex < dialogueItems.Count - 1)
            {
                currentItemIndex++;
            }
            else
            {
                dialogueObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentItemIndex > 0)
            {
                currentItemIndex--;
            }
        }
    }
}
