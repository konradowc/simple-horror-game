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

    [SerializeField] private Terrain terrain;

    [SerializeField] private LayerMask theGround;

    void Start()
    {
        //terrain.treeDistance = 1000;
        //terrain.treeBillboardDistance = 10;
    }
}
