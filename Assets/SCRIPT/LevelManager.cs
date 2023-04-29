using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> UsineDansLeNiveau = new List<GameObject>();
    private GameManager GameManager;
    [SerializeField] private string Niveau;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.Setlevel(Niveau);
        GameManager.SetUsine(UsineDansLeNiveau);
    }

   /* public void play()
    {
        Debug.Log("bob");
        for (int i = 0; i < UsineDansLeNiveau.Count; i++)
        {
            Debug.Log(UsineDansLeNiveau[i].GetComponent<SpawnCamion_Script>());
            UsineDansLeNiveau[i].GetComponent<SpawnCamion_Script>();//LancerCamion();
           
        }
        Debug.Log("bob3");
    }*/
}
