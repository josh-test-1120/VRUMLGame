using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovementPanel : MonoBehaviour
{
    [Header("Player Object (Anchor)")]
    [SerializeField] PlayerCharacter player;

    [Header("Movement Text Object")]
    [SerializeField]
    TextMeshProUGUI textMesh;

    private CanvasGroup _canvasGroup;
    private bool _movementState = true;

    // Listeners attached during enable or disable
    void OnEnable()
    {
        Messenger.AddListener(GameEvent.MOVEMENT_NOTIFY, Open);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.MOVEMENT_NOTIFY, Open);
    }

    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        StartCoroutine(DisappearCoroutine());
    }

    IEnumerator DisappearCoroutine()
    {
        string text = "";
        if (_movementState) text = "Movement has been disabled";
        else text = "Movement has been enabled";

        textMesh.text = text;

        //Print the time of when the function is first called.
        Debug.Log("Started Disappear at timestamp : " + Time.time);
        //Debug.Log($"Text Mesh Pro object in Coroutine: {textMesh.ToString()}");
        //Debug.Log($"Text Mesh Pro text in Coroutine: {textMesh.text.ToString()}");
        _canvasGroup.alpha = 1;

        Vector3 playerPos = player.transform.position;
        Quaternion playerRot = player.transform.rotation;

        playerPos.z += 5;
        playerPos.x += 5;

        this.transform.position = playerPos;
        this.transform.rotation = playerRot;

        //textMesh.text = "Correct Answer!";
        ////textMesh.SetText("Correct Answer!");

        //Debug.Log($"Text Mesh Pro object after set: {textMesh.text.ToString()}");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(5);

        //Destroy(this.gameObject);
        _canvasGroup.alpha = 0;

        _movementState = !_movementState;

        ////After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        // Close out the windows
        //Close();
    }
}
