using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class OnOffButtonEvents : MonoBehaviour
{
    // UML panels to diplay from
    [Header("UML Assets")]
    [SerializeField] List<GameObject> _umlObjs;

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
        }
    }
    public void OnPointerExit()
    {
        Debug.Log("Button on Pointer Exit");
        Destroy(_uml);
    }

}