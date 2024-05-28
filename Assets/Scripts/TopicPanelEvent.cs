using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicPanelEvent : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Open()
    {
        _canvasGroup.alpha = 1;
        //_canvasGroup.interactable = true;
    }

    // Update is called once per frame
    void Close()
    {
        _canvasGroup.alpha = 0;
        //_canvasGroup.interactable = true;
    }
}
