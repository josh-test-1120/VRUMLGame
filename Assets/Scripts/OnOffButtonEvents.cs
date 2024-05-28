using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class OnOffButtonEvents : ReticleButtonClamp
{
    // UML panels to diplay from
    [Header("UML Assets")]
    [SerializeField] List<GameObject> _umlObjs;

    [Header("Answer Panel")]
    [SerializeField] CanvasGroup _selectionPanel;

    private GameObject _uml;
    private bool _isOn = false;

    public void OnPointerEnter()
    {
        Debug.Log("Button on Pointer Enter");
    }

    public void OnPointerClick()
    {
        Debug.Log("Button on Pointer Click");

        bool clamped = ReticleNormalize();

        Debug.Log($"This is the On/Off button state: {clamped}");
        if (clamped)
        {
            if (!_isOn)
            {
                int index = Random.Range(0, _umlObjs.Count);
                Debug.Log($"This is the random index: {index}");
                Debug.Log($"This is the UML Object Count: {_umlObjs.Count}");
                _uml = Instantiate(_umlObjs[index]) as GameObject;

                Vector3 pos = this.transform.position;
                pos.z += 5;
                pos.y = 0;

                _uml.transform.position = pos;
                //float angle = Random.Range(0, 360);
                //enemy.transform.Rotate(0, angle, 0);

                _selectionPanel.alpha = 1;

                Debug.Log("Entering the show selection panel");
                SelectionPanelShow();

            }
            else
            {
                Debug.Log("Destroy the UML object");
                Destroy(_uml);
                _selectionPanel.alpha = 0;

                SelectionPanelClose();

                //int LayerUI = LayerMask.NameToLayer("UI");
                //gameObject.layer = LayerUI;
            }

            _isOn = !_isOn;
            Debug.Log($"Is On state: {_isOn}");
        }

    }
    public void OnPointerExit()
    {
        Debug.Log("Button on Pointer Exit");
    }

    public void SelectionPanelShow()
    {
        //Debug.Log("Inside the show selection panel");
        // Setup the selection screen
        int LayerInteractive = LayerMask.NameToLayer("Interactive");

        CanvasRenderer[] childobjs = _selectionPanel.GetComponentsInChildren<CanvasRenderer>();

        //Debug.Log($"This is the size of the child objects: {childobjs.Length}");

        foreach (CanvasRenderer item in childobjs)
        {
            item.gameObject.layer = LayerInteractive;
            //Debug.Log($"This is the layer: {item.gameObject.layer} for item: {item}");
        }
        //Debug.Log("Leaving the show selection panel");

    }

    public void SelectionPanelClose()
    {
        Debug.Log("Inside the close selection panel");
        // Setup the selection screen
        int LayerUI = LayerMask.NameToLayer("UI");

        CanvasRenderer[] childobjs = _selectionPanel.GetComponentsInChildren<CanvasRenderer>();

        //Debug.Log($"This is the size of the child objects: {childobjs.Length}");

        foreach (CanvasRenderer item in childobjs)
        {
            item.gameObject.layer = LayerUI;
            //Debug.Log($"This is the layer: {item.gameObject.layer} for item: {item}");
        }
        Debug.Log("Leaving the close selection panel");

    }
}