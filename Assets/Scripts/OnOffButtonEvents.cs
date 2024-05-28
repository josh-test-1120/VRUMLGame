using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class OnOffButtonEvents : MonoBehaviour
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
        }

        _isOn = !_isOn;

    }
    public void OnPointerExit()
    {
        Debug.Log("Button on Pointer Exit");
        Destroy(_uml);
    }

    public void SelectionPanelShow()
    {
        Debug.Log("Inside the show selection panel");
        // Setup the selection screen
        int LayerInteractive = LayerMask.NameToLayer("Interactive");

        GameObject[] childobjs = _selectionPanel.GetComponentsInChildren<GameObject>();

        foreach (GameObject item in childobjs)
        {
            item.layer = LayerInteractive;
        }
        Debug.Log("Leaving the show selection panel");

        //// Setup the selection screen
        //int LayerInteractive = LayerMask.NameToLayer("Interactive");
        //_selectionPanel.gameObject.layer = LayerInteractive;
    }
}