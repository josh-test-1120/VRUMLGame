using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMLPanel : MonoBehaviour
{
    // Open the panel for the settings
    public void Open()
    {
        //gameObject.SetActive(true);
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    // Close the panel for the settings
    public void Close()
    {
        Debug.Log("This is the close function");
        Debug.Log(gameObject);
        //gameObject.SetActive(false);
        //CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();

        //canvasGroup.alpha = 0;
        //canvasGroup.interactable = false;
        Messenger.Broadcast(GameEvent.CLOSE_UML_PANEL);

        //GameObject cPanel = GameObject.Find("CenterPanel");
        //Debug.Log(cPanel);
        //cPanel.SetActive(false);
    }
}
