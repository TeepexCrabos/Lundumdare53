using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint_Script : MonoBehaviour
{
    [SerializeField] bool Selectionner = false;
    [SerializeField] private GameObject[] CheckPointSuivant;
   


    // Start is called before the first frame update
    public void Select()
    {
        Selectionner = true;
    }
}
