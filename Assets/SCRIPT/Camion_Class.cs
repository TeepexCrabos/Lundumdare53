using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camion_Class
{
    private float Vitesse;
    public List<GameObject> Destination;

    public Camion_Class(float vitesse,List<GameObject>destination)
    {
        Vitesse = vitesse;
        Destination = destination;
    }

    public Vector3 GetNextDestination(int i)
    {
        return Destination[i].transform.position;
    }

}
