using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject[] openChestPrefab;

    public void Open()
    {
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        Debug.Log(this.gameObject);
        Destroy(this.gameObject);
        // Randomize the prefab chest to show
        int index = Random.Range(0, 2);
        GameObject chest = Instantiate(openChestPrefab[index]) as GameObject;
        chest.transform.position = position;
        chest.transform.rotation = rotation;
    }
}
