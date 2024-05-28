using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] targets;

    void OnTriggerEnter(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Open");
            Debug.Log("Entered Trigger Zone");
        }
    }

    void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Close");
            Debug.Log("Exited Trigger Zone");
        }
    }
}
