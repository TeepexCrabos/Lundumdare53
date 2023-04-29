using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint_Script : MonoBehaviour
{
    public bool Selectionner = false;
    [SerializeField] private GameObject[] CheckPointSuivant;
   


    // Start is called before the first frame update
    public void Select(GameObject UsineSelect)
    {

      
        for(int i = 0; i < CheckPointSuivant.Length; i++)
        {
            if(CheckPointSuivant[i].GetComponent<checkpoint_Script>().Selectionner == true)
            {
                int count = 0;
                foreach (GameObject PointSuivant in CheckPointSuivant[i].GetComponent<checkpoint_Script>().CheckPointSuivant)
                {
                    if (PointSuivant.GetComponent<checkpoint_Script>().Selectionner == true)
                    {
                        count++;
                    }
                }
                if(count > 1)
                {
                    Debug.Log("vous ne pouvez pas selectionner se passage");
                }
                else
                {
                    Selectionner = true;
                    UsineSelect.GetComponent<Usine_Script>().AddCheckPoint(this.gameObject);
                    Debug.Log("CheckPointAjouterAlaliste");
                }
               
                break;
            }
        }
        if(UsineSelect.name == this.gameObject.name)
        {
            Debug.Log("Select CheckPoint");
            Selectionner = true;
        }
        
    }
}
