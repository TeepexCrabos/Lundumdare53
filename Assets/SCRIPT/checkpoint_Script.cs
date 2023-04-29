using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint_Script : MonoBehaviour
{
    public bool Selectionner = false;
    [SerializeField] private GameObject[] CheckPointSuivant;
   


    // Start is called before the first frame update
    public bool Select(GameObject UsineSelect,GameObject lastSelect)
    {
        bool validation = false;
        int count = 0;
        if (UsineSelect.name == this.gameObject.name)
        {
            Debug.Log("Select CheckPoint");
            Selectionner = true;
            validation = true;
        }
        else
        {
            foreach (GameObject PointSuivant in CheckPointSuivant)
            {
                if (PointSuivant == lastSelect)
                {
                    count++;
                    
                }
                else
                {
                    
                }


            }
            
        }
        if(count == 1)
        {
            Selectionner = true;
            UsineSelect.GetComponent<Usine_Script>().AddCheckPoint(this.gameObject);
            Debug.Log("CheckPointAjouterAlaliste");
            validation = true;
        }
        else
        {
            Debug.Log("vous ne pouvez pas selectionner se passage");
            validation = false;
        }

        return validation;
        /* for(int i = 0; i < CheckPointSuivant.Length; i++)
         {
             if(CheckPointSuivant[i].GetComponent<checkpoint_Script>().Selectionner == true)
             {
                 int count = 0;
                 /*foreach (GameObject PointSuivant in CheckPointSuivant[i].GetComponent<checkpoint_Script>().CheckPointSuivant)
                 {
                     if (PointSuivant.GetComponent<checkpoint_Script>().Selectionner == true)
                     {
                         count++;
                     }
                 }
                 if (count == 2)
                 {
                     Selectionner = true;
                     UsineSelect.GetComponent<Usine_Script>().AddCheckPoint(this.gameObject);
                     Debug.Log("CheckPointAjouterAlaliste");
                 }

                 else if(count == 1)
                 {
                     Debug.Log("vous ne pouvez pas selectionner se passage");

                 }
                 else if(count == 3)
                 {

                 }

                 break;
             }
         }
         */

    }
}
