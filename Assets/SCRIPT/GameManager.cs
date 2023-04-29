using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<GameObject> usine = new List<GameObject>();
    [SerializeField] private string Niveau;
    private string lastLevel;
    private GameObject UsineSelect;
    private bool UsineSel = false;
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


    public void Play()
    {
        for(int i = 0; i < usine.Count; i++)
        {
            usine[i].GetComponent<SpawnCamion_Script>().LancerCamion();
        }
    }

   public void Setlevel(string level)
    {
        lastLevel = Niveau;
        Niveau = level;
    }

    public void UsineSelector(GameObject Usine)
    {
        if(UsineSel == false)
        {
            Debug.Log("Usine Select");
            Usine.GetComponent<Usine_Script>().IsSelect();
            UsineSelect = Usine;
        }
        else if(UsineSel == true && Usine.GetComponent<Usine_Script>().select == false)
        {
            Debug.Log("Deselectionner l'usine selectionner");
        }
        else if(UsineSel == true && Usine.GetComponent<Usine_Script>().select == true)
        {
            Usine.GetComponent<Usine_Script>().IsSelect();
        }
        
       
    }
    public void CheckPointSelector(GameObject CheckPoint)
    {
        
        if (UsineSelect != null)
        {
            for (int i = 0; i < UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count; i++)
            {
                if (CheckPoint == UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner[i])
                {
                    UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.RemoveAt(i);
                    Debug.Log("Point Suprimer");
                    break;
                }
                else
                {
                    CheckPoint.GetComponent<checkpoint_Script>().Select(UsineSelect);
                    Debug.Log("Point Enregistrer");
                }

            }

        }
        else
        {
            Debug.Log("Selectionner une Usine");
        }
        
        
       
    }
    public void ChangerLaScene()
    {
        switch (Niveau)
        {
            case "START_MENU":
                SceneManager.LoadScene("LEVEL1");
                break;
            case "GAMEOVER":
                SceneManager.LoadScene(lastLevel);
                break;
            case "WIN_MENU":
                SceneManager.LoadScene("START_MENU");
                break;
            case "LEVEL1":
                SceneManager.LoadScene("WIN_MENU");
                break;
            case "LEVEL2":
                SceneManager.LoadScene("WIN_MENU");
                break;
        }
       
    }
    public void Suite()
    {
        switch (lastLevel)
        {
            case "LEVEL1":
                SceneManager.LoadScene("LEVEL2");
                break;
            case "LEVEL2":
                SceneManager.LoadScene("LEVEL3");
                break;
            case "LEVEL3":
                SceneManager.LoadScene("FIN");
                break;
        }
        
    }
    public void levelLoose()
    {
        SceneManager.LoadScene("GAMEOVER");
    }

    public void quit()
    {
        Application.Quit();
    }

    


}
