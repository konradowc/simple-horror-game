using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private GameObject car;

    private bool isFirstScene = false;

    // Start is called before the first frame update
    void Start()
    {
        Events.events.onBeginningScene += FirstScene;
        Events.events.onRegularScene += SecondScene;
    }

    void FirstScene()
    {
        car.transform.position = new Vector3(660, 0, 287);
        isFirstScene= true;
    }

    void SecondScene()
    {
        car.transform.position = new Vector3(300, 0.65f, 287);
        isFirstScene = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(isFirstScene)
        {
            car.transform.position = new Vector3(car.transform.position.x - GameFlow.game.carSpeed * Time.deltaTime, car.transform.position.y, car.transform.position.z);
            if(car.transform.position.x < 300)
            {
                GameFlow.game.StartRegScene();
            }
        }
    }
}
