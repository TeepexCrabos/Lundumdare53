using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCamion_Script : MonoBehaviour
{

    [SerializeField] GameObject[] Prefab_Camion;
    [SerializeField] int SelectionCamion;
    private int camionModel;
    
    public void LancerCamion()
    {
        if(SelectionCamion == -1)
            SelectionCamion = Random.Range(0, Prefab_Camion.Length);
        camionModel = SelectionCamion;
        Instantiate(Prefab_Camion[camionModel]);
    }
    
}
