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
            if (!Selectionner)
            {
                Selectionner = true;
                return validation = true;
            }
            else
            {
                Selectionner = false;
               return validation = false;
            }
          
        }
        else
        {
            foreach (GameObject PointSuivant in CheckPointSuivant)
            {
                if (PointSuivant == lastSelect)
                {
                    count++;
                    
                }
                


            }
            
        }
        if(count == 1)
        {
            Selectionner = true;
            UsineSelect.GetComponent<Usine_Script>().AddCheckPoint(this.gameObject);
            Debug.Log("CheckPointAjouterAlaliste");
            return validation = true;
        }
        else
        {
            Debug.Log("vous ne pouvez pas selectionner se passage");
            return validation = false;
        }

        return validation;
        

               

    }
}
