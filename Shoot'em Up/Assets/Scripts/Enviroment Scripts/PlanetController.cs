using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] GameObject[] planets;

    Queue<GameObject> avaliablePlanets = new Queue<GameObject>();

    void Start()
    {
        avaliablePlanets.Enqueue(planets[0]);
        avaliablePlanets.Enqueue(planets[1]);
        avaliablePlanets.Enqueue(planets[2]);

        InvokeRepeating("MovePlanetDown", 0, 15f);
    }

    void MovePlanetDown()
    {
        EnqueuePlanets();

        if (avaliablePlanets.Count == 0)
            return;

        GameObject aPlanet = avaliablePlanets.Dequeue();

        aPlanet.GetComponent<Planet>().isMoving = true;
    }

    void EnqueuePlanets()
    {
        foreach (GameObject aPlanet in planets) 
        {
            if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                aPlanet.GetComponent<Planet>().ResetPosition();

                avaliablePlanets.Enqueue(aPlanet);
            }
        }
    }
}
