using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetup : MonoBehaviour
{
    [SerializeField] private GameObject house;

    enum Rotation
    {
        LEFT, RIGHT, UP, DOWN
    }

    struct Coord
    {
        public float x;
        public float z;

        public Rotation rot;

        public Coord(float intX, float intZ, Rotation rotation)
        {
            this.x = intX;
            this.z = intZ;
            this.rot = rotation;
        }
    }

    void Start()
    {
        Coord[] houseLocs = new Coord[] {
            new Coord(10, 10, Rotation.LEFT),
            new Coord(40, 10, Rotation.LEFT),
            new Coord(70, 10, Rotation.LEFT),
            new Coord(110, 10, Rotation.LEFT),

            new Coord(10, 50, Rotation.RIGHT),
            new Coord(40, 50, Rotation.RIGHT),
            new Coord(70, 50, Rotation.RIGHT),
            new Coord(110, 50, Rotation.RIGHT),
        };

        // generate houses on map
        GameObject go;
        for(int i = 0; i < houseLocs.Length; i++)
        {
            go = Instantiate(house, new Vector3(houseLocs[i].x, 15, houseLocs[i].z), transform.rotation);
            go.transform.localScale = new Vector3(40, 40, 40);

            if (houseLocs[i].rot == Rotation.RIGHT)
            {
                go.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                go.transform.localPosition = new Vector3(go.transform.position.x - 70, go.transform.position.y, go.transform.position.z);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
