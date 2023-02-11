using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetup : MonoBehaviour
{
    [SerializeField] private GameObject house;

    void Start()
    {
        // generate houses on map
        for (int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(house, new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), transform.rotation);
            go.transform.localScale = new Vector3(10, 10, 10);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
