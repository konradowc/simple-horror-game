using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetup : MonoBehaviour
{
    [SerializeField] private GameObject tree1;
    [SerializeField] private GameObject tree2;
    [SerializeField] private GameObject tree3;
    [SerializeField] private GameObject tree4;

    [SerializeField] private float treeHeight = 0.0f;

    private GameObject[] treeArray;

    [SerializeField] private LayerMask theGround;

    void Start()
    {
        treeArray = new GameObject[] { tree1, tree2, tree3, tree4 };
        MakeBackgroundForest(100, 500, 210, 260);
    }

    void MakeBackgroundForest(int startXPos, int endXPos, int startZPos, int endZPos)
    {
        GameObject go;
        RaycastHit hit;

        int treeCounter = 0;
        for (int i = startXPos; i < endXPos; i+=10)
        {
            for(int j = startZPos; j < endZPos; j+=20)
            {
                go = Instantiate(treeArray[treeCounter], new Vector3(i + UnityEngine.Random.Range(-1,1), 15, j + UnityEngine.Random.Range(-1, 1)), transform.rotation);
                go.transform.Rotate(0.0f, UnityEngine.Random.Range(0, 360), 0.0f, Space.Self); // rotates by random amount

                //Physics.Raycast(go.transform.position, Vector3.down, out hit, theGround); // hit.distance stores distance
                //Debug.Log(hit.distance);
                //go.transform.position -= Vector3.up * (treeHeight - hit.distance);
                go.transform.position = new Vector3(go.transform.position.x, 0, go.transform.position.z);

                treeCounter++;
                if (treeCounter == 4)
                    treeCounter = 0;
            }
        }
        
        
    }
}
