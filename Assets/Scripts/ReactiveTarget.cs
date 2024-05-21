using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        // Set alive state if component exists
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        // Fire the Die Enumerated function
        StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        Debug.Log("Attempting to rotate NPC");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.freezeRotation = false;
        
        Animator anim = GetComponentInChildren<Animator>();
        //anim.StopPlayback();
        anim.GetComponent<Animator>().enabled = false;
        anim.transform.Rotate(-75, 0, 0);
        anim.GetComponent<Animator>().enabled = false;
        rb.freezeRotation = true;
        //this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}