using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomPrefabs : MonoBehaviour
{
    public GameObject[] prefab;

    private GameObject instance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (prefab == null)
            {
                Debug.LogError("Prefab is NULL");
                return;
            }

            if (instance != null)
            {
                Destroy(instance);
            }

            var rotation = Quaternion.identity;
            var position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
            instance = Instantiate(prefab[Random.Range(0,prefab.Length)], position, rotation);
        }
    }
}
