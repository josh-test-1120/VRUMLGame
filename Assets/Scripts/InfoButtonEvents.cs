using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonEvents : MonoBehaviour
{
    [SerializeField] CanvasGroup _infoPanel;

    private bool _isOpen;

    // Start is called before the first frame update
    void Start()
    {
        _isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter()
    {
        Debug.Log("Button on Pointer Enter");
    }

    public void OnPointerClick()
    {
        Debug.Log("Button on Pointer Click");
        Debug.Log($"Is Open?: {_isOpen}");
        if (_isOpen)
        {
            _infoPanel.alpha = 0;
        }
        else
        {
            _infoPanel.alpha = 1;
        }

        _isOpen = !_isOpen;
    }
    public void OnPointerExit()
    {
        Debug.Log("Button on Pointer Exit");
    }
}
