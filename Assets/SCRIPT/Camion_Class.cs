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
        if (i < Destination.Count)
       {
            return Destination[i].transform.position;
           
       }
        else
        {
            return Destination[Destination.Count-1].transform.position;
        }
    }

}
