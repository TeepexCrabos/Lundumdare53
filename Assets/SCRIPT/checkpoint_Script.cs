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
                Selectionner = true;
                UsineSelect.GetComponent<Usine_Script>().AddCheckPoint(this.gameObject);
            }
            break;
        }
        
    }
}
