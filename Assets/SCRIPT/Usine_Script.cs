using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usine_Script : MonoBehaviour
{
    [SerializeField] private bool select;
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
        select = true;
        for(int i = 0; i < CheckPointSelectionner.Count; i++)
        {
            CheckPointSelectionner[i].GetComponent<MeshRenderer>().material = Material;
        }
    }

    public void IsDeselect()
    {
        select = false;

    }
}
