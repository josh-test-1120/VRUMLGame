using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    // Private variable
    private Camera cam;
    public bool freezeCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        // Attach the camera component
        cam = GetComponent<Camera>();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse button press
        // && !EventSystem.current.IsPointerOverGameObject()
        if (Input.GetMouseButtonDown(0) && !freezeCamera)
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                    Messenger.Broadcast(GameEvent.ENEMY_HIT);
                    Debug.Log("We have a hit");
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                    Debug.Log("We have a no hit");
                }
            }
        }
    }

    void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Enumerated Raycast hit vectors
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
