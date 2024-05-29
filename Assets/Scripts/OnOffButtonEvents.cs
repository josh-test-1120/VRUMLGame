using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class OnOffButtonEvents : ReticleButtonClamp
{
    // UML panels to diplay from
    [Header("UML Assets")]
    [SerializeField] List<GameObject> umlObjs;

    [Header("Answer Panel")]
    [SerializeField] CanvasGroup selectionPanel;

    [Header("Anchor Point")]
    [SerializeField] GameObject anchorPoint;

    [Header("Diagram Box")]
    [SerializeField] GameObject boxParent;

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

        Debug.Log($"This is the On/Off button readiness: {clamped}");
        if (clamped)
        {
            if (!_isOn)
            {
                
                SelectionPanelShow();

            }
            else
            {
                //Debug.Log("Destroy the UML object");
                SelectionPanelClose();
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
        Debug.Log("Entering the show selection panel");
        // Instantiate a random UML diagram from list
        int index = Random.Range(0, umlObjs.Count);
        Debug.Log($"This is the random index: {index}");
        Debug.Log($"This is the UML Object Count: {umlObjs.Count}");
        _uml = Instantiate(umlObjs[index]) as GameObject;
        // Translate and rotate based on parent
        _uml.transform.parent = boxParent.transform;
        _uml.transform.rotation = boxParent.transform.rotation;

        _uml.transform.localPosition = Vector3.forward * 5;

        //Vector3 pos = _uml.transform.position;
        //pos.z += 5;

        //_uml.transform.position = pos;

        //Vector3 pos = new Vector3();
        //pos.y = 0;
        //pos.z = 5;

        // Update the visibility of the panel
        selectionPanel.alpha = 1;
        // Setup the selection screen
        int LayerInteractive = LayerMask.NameToLayer("Interactive");
        // Update the child objects with the proper interactive layer
        CanvasRenderer[] childobjs = selectionPanel.GetComponentsInChildren<CanvasRenderer>();

        foreach (CanvasRenderer item in childobjs) item.gameObject.layer = LayerInteractive;

    }

    public void SelectionPanelClose()
    {
        Debug.Log("Inside the close selection panel");
        // Destroy the UML asset
        Destroy(_uml);
        // Update the visibility of the panel
        selectionPanel.alpha = 0;
        // Setup the selection screen
        int LayerUI = LayerMask.NameToLayer("UI");

        // Update the child objects with the proper UI layer (non interactive)
        CanvasRenderer[] childobjs = selectionPanel.GetComponentsInChildren<CanvasRenderer>();

        foreach (CanvasRenderer item in childobjs) item.gameObject.layer = LayerUI;
    }
}