using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usine_Script : MonoBehaviour
{
     public bool select;
     public List<GameObject> CheckPointSelectionner;
     public Material Material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCheckPoint(GameObject CheckPoint)
    {
        if(select)
            CheckPointSelectionner.Add(CheckPoint);
    }

    public void IsSelect()
    {
        if(select)
        {
            IsDeselect();
        }
        select = true;
       
    }

    public void IsDeselect()
    {
        select = false;
       
    }
}
