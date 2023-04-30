using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> UsineDansLeNiveau = new List<GameObject>();
    private GameManager GameManager;
    [SerializeField] private string Niveau;
    public int BienArrivé;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.Setlevel(Niveau);
        GameManager.SetUsine(UsineDansLeNiveau);
    }
    private void FixedUpdate()
    {
        if (BienArrivé == UsineDansLeNiveau.Count)
        {
            GameManager.ChangerLaScene();
        }
    }
    
}
