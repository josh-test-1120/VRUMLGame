using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicButtonEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
    }
    public void OnPointerExit()
    {
        Debug.Log("Button on Pointer Exit");
    }
}
