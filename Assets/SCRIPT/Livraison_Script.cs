using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livraison_Script : MonoBehaviour
{
    public LevelManager levelmanager;
    // Start is called before the first frame update
    void Start()
    {
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log("camion arrivé");
        if (other.gameObject.tag == "camion")
        {
            if(other.gameObject.GetComponent<IA_Camion>().Objectif.name == this.gameObject.name)
            {
                levelmanager.BienArrivé++;
                Destroy(other.gameObject);
            }
        }
    }*/
}
