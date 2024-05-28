using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RightSelection : MonoBehaviour
{
    [Header("Answer Text Object")]
    [SerializeField]
    TextMeshProUGUI textMesh;

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
        Debug.Log($"Text Mesh Pro text object: {textMesh.text}");
        

        Open();

    }
    public void OnPointerExit()
    {
        Debug.Log("Button on Pointer Exit");
    }

    // Start is called before the first frame update
    void Open()
    {
        _canvasGroup.alpha = 1;

        StartCoroutine(FlashTextCoroutine());


        //_canvasGroup.interactable = true;
    }

    // Update is called once per frame
    void Close()
    {
        _canvasGroup.alpha = 0;
        //_canvasGroup.interactable = true;
    }

    IEnumerator FlashTextCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Flashtext at timestamp : " + Time.time);
        Debug.Log($"Text Mesh Pro object in Coroutine: {textMesh.ToString()}");
        Debug.Log($"Text Mesh Pro text in Coroutine: {textMesh.text.ToString()}");

        textMesh.text = "Correct Answer!";
        //textMesh.SetText("Wrong Answer!");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);


        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
