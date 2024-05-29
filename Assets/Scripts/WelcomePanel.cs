using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomePanel : MonoBehaviour
{
    // Private variables
    private CanvasGroup _canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();
        StartCoroutine(DisappearCoroutine());
    }

    IEnumerator DisappearCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Welcome Panel at timestamp : " + Time.time);
        //Debug.Log($"Text Mesh Pro object in Coroutine: {textMesh.ToString()}");
        //Debug.Log($"Text Mesh Pro text in Coroutine: {textMesh.text.ToString()}");
        _canvasGroup.alpha = 1;

        //textMesh.text = "Correct Answer!";
        ////textMesh.SetText("Correct Answer!");

        //Debug.Log($"Text Mesh Pro object after set: {textMesh.text.ToString()}");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(60);

        Destroy(this.gameObject);
        //_canvasGroup.alpha = 0;

        ////After we have waited 5 seconds print the time again.
        Debug.Log("Finished Welcome Panel Coroutine at timestamp : " + Time.time);
        // Close out the windows
        //Close();
    }
}
