using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeftSelection : MonoBehaviour
{
    [Header("Answer Text Object")]
    [SerializeField]
    TextMeshProUGUI textMesh;

    [Header("Parent Button Handler")]
    [SerializeField]
    OnOffButtonEvents uiButton;

    private CanvasGroup _canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = textMesh.GetComponent<CanvasGroup>();
    }

    public void OnPointerEnter()
    {
        Debug.Log("Button on Pointer Enter");

    }

    public void OnPointerClick()
    {
        Debug.Log("Button on Pointer Click");
        Debug.Log($"Text Mesh Pro object: {textMesh.ToString()}");
        Open();

    }
    public void OnPointerExit()
    {
        Debug.Log("Button on Pointer Exit");
    }

    // Start is called before the first frame update
    void Open()
    {
        Debug.Log($"Text Mesh Pro object: {textMesh.ToString()}");
        _canvasGroup.alpha = 1;
        //_canvasGroup.blocksRaycasts = false;


        StartCoroutine(FlashTextCoroutine());
    }

    // Update is called once per frame
    void Close()
    {
        _canvasGroup.alpha = 0;

        uiButton.SendMessage("SelectionPanelClose");
        //_canvasGroup.blocksRaycasts = true;
        //_canvasGroup.interactable = true;
    }

    IEnumerator FlashTextCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Flashtext at timestamp : " + Time.time);
        Debug.Log($"Text Mesh Pro object in Coroutine: {textMesh.ToString()}");
        Debug.Log($"Text Mesh Pro text in Coroutine: {textMesh.text.ToString()}");

        textMesh.text = "Correct Answer!";
        //textMesh.SetText("Correct Answer!");

        Debug.Log($"Text Mesh Pro object after set: {textMesh.text.ToString()}");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(5);


        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        // Close out the windows
        Close();
    }
}
