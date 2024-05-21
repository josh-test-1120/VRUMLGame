using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    // Public variables
    public float baseSpeed = 3.0f;
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    // Serialized private variables
    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    // Private variables
    private bool isAlive = true;
    private int terrainBlocked = 0;

    // Message Listeners
    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        //if (isAlive) transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (fireball == null)
                {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position =
                    transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hitObject.GetComponent<Terrain>() || terrainBlocked <= 10)
            {
                //Debug.Log("Ran into Terrain");
                terrainBlocked++;
            }
            else if (hitObject.GetComponent<Terrain>() || terrainBlocked > 10)
            {
                Debug.Log("Blocked terrain adjustment");
                terrainBlocked = 0;
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);

            }    
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
            //Debug.Log(hitObject.GetComponent<Terrain>());
        }
    }

    // Public setter
    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}
