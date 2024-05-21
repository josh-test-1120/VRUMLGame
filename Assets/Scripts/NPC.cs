using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //public GameObject obj;
    private bool IsAlive;

    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("");
        IsAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 3;
        //if (IsAlive) transform.Translate(0, 0, speed * Time.deltaTime);

        // Slope rotation alignment.
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log("Hit the ground");
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        }

        // Auto rotation.

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);


        //// Anti jitter movement solution.
        //float step = speed * Time.deltaTime;
        //float folX = (obj.transform.position.x - transform.position.x) * step;
        //float folZ = (obj.transform.position.z - transform.position.z) * step;

        //Rigidbody rb = GetComponent<Rigidbody>();
        //Vector3 v = rb.velocity;

        //v.x = folX;
        //v.z = folZ;

        //rb.velocity = v;

    }
}