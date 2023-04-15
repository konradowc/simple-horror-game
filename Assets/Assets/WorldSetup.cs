using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetup : MonoBehaviour
{
    [SerializeField] private GameObject house1;
    [SerializeField] private GameObject house2;
    [SerializeField] private GameObject house3;
    [SerializeField] private GameObject house4;
    [SerializeField] private GameObject house5;

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
            new Coord(50, 50, Rotation.RIGHT),
            new Coord(50, 70, Rotation.RIGHT),
            new Coord(25, -10, Rotation.LEFT),

            new Coord(60, 0, Rotation.LEFT),

            new Coord(-30, 50, Rotation.RIGHT),
            new Coord(-15, 50, Rotation.RIGHT)
        };

        // generate houses on map
        GameObject go;
        for(int i = 0; i < houseLocs.Length; i++)
        {
            go = Instantiate(house1, new Vector3(houseLocs[i].x, 15, houseLocs[i].z), transform.rotation);
            go.transform.localScale = new Vector3(40, 40, 40);

            if (houseLocs[i].rot == Rotation.RIGHT)
            {
                go.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                go.transform.localPosition = new Vector3(go.transform.position.x - 70, go.transform.position.y, go.transform.position.z);
            }
        }

    }
}
