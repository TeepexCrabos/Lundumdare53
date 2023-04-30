using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usine_Script : MonoBehaviour
{
     public bool select = false;
     public List<GameObject> CheckPointSelectionner;
     
    public GameObject Objectif;

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
    public void change()
    {
        select = false;
        this.gameObject.GetComponent<checkpoint_Script>().Select(this.gameObject, this.gameObject);
    }

    public void IsSelect()
    {
        if(select)
        {
            IsDeselect();
        }
        select = true;
        this.gameObject.GetComponent<checkpoint_Script>().Select(this.gameObject,this.gameObject);
        
        Debug.Log("usine select confirm");


    }

    public void IsDeselect()
    {
        select = false;
        CheckPointSelectionner.Clear();
    }
}
