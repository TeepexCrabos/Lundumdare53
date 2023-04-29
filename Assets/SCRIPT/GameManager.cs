using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<GameObject> usine = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void SetUsine(List<GameObject>UsineDansleNiveau)
    {
        for(int i = 0; i < usine.Count; i++)
        {
            usine.RemoveAt(i);
        }
        for(int j = 0; j < UsineDansleNiveau.Count; j++)
        {
            usine.Add(UsineDansleNiveau[j]);
        }
    }
    private void Play()
    {
        for(int i = 0; i < usine.Count; i++)
        {
            usine[i].GetComponent<SpawnCamion_Script>().LancerCamion();
        }
    }

    
}
