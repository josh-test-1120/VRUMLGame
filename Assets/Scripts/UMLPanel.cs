using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMLPanel : MonoBehaviour
{
    // UML panels to diplay from
    [SerializeField] List<GameObject> _umlObjs;

    private bool _isOn = false;
    private GameObject _uml;

    // Open the panel for the settings
    public void Open()
    {
        //gameObject.SetActive(true);
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    // Open the panel for the settings
    public void OnOffButton()
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
        }

        ////gameObject.SetActive(true);
        //CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();

        //canvasGroup.alpha = 1;
        //canvasGroup.interactable = true;
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

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        Debug.Log("On Pointer Enter");
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        Debug.Log("On Pointer Exit");
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        Debug.Log("On Pointer Click");
        OnOffButton();
    }
}
