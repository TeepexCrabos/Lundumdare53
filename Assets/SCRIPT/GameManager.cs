using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private List<GameObject> usine = new List<GameObject>();
    [SerializeField] private string Niveau;
    private string lastLevel;
    public GameObject UsineSelect;
    private bool UsineSel = false;
    public SpawnCamion_Script usineee;
    public GameObject lastSelection;
    private string Message;
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
        usine = UsineDansleNiveau;
        
    }


    public void Play()
    {
        bool valider = false;
         for(int i = 0; i < usine.Count; i++)
        {
            if(usine[i].GetComponent<Usine_Script>().CheckPointSelectionner[0]!=null)
            {
                valider = true;
            }
            else
            {
                valider = false;
            }
            
        }
         if(valider == true)
        {
            for (int i = 0; i < usine.Count; i++)
            {
                usine[i].GetComponent<SpawnCamion_Script>().LancerCamion();
            }
        }
        
    }

   public void Setlevel(string level)
    {
        lastLevel = Niveau;
        Niveau = level;
    }

    public void UsineSelector(GameObject Usine)
    {
        if(UsineSelect == null)
        {
            //Debug.Log("Usine Select");
            Usine.GetComponent<Usine_Script>().IsSelect();
            UsineSelect = Usine;
            lastSelection = UsineSelect;
        }
        else if(Usine.name == UsineSelect.name)
        {
            //Debug.Log("deselect usine");
            Usine.GetComponent<Usine_Script>().IsSelect();
            UsineSelect = null;
            lastSelection = null;
        }
        else if(Usine.name != UsineSelect.name)
        {
            //Debug.Log("Change usine");
            UsineSelect.GetComponent<Usine_Script>().change();
            Usine.GetComponent<Usine_Script>().IsSelect();
            UsineSelect = Usine;
            lastSelection = UsineSelect;
        }
        
       
    }
    public void CheckPointSelector(GameObject CheckPoint)
    {
        bool effectuer = false;
        bool suppr = false;
        int j = 0;
        int count = 0;
        if (UsineSelect != null)
        {
            //Debug.Log("CheckPoint select");
            if (UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count > 0)
            {
                //Debug.Log("pointselectsupp0");
                foreach (GameObject PointSelect in UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner)
                {
                    if(PointSelect.name == CheckPoint.name)
                    {
                        
                       
                        suppr = true;
                    }
                }
                if(suppr == true)
                {
                    for (int i = 0; i < UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count; i++)
                    {
                        if (UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner[i].name == CheckPoint.name)
                        {
                            j = i;
                            count = UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count;
                        }
                    }
                    //Debug.Log("Bob");
                    while(count > j)
                    {
                        UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.RemoveAt(j);
                        //Debug.Log("Point Suprimer");
                        //Debug.Log(count);
                        //Debug.Log(j);
                        count--;
                    }
                    
                        lastSelection = UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner[UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count - 1];

                    
                }
                
                if (suppr == false)
                {
                    effectuer = CheckPoint.GetComponent<checkpoint_Script>().Select(UsineSelect,lastSelection);
                    if (effectuer)
                    {
                        lastSelection = CheckPoint;
                    }
                    //Debug.Log("Point Enregistrer");
                }
               
            }
            else
            {
                effectuer = CheckPoint.GetComponent<checkpoint_Script>().Select(UsineSelect, lastSelection);
                if (effectuer)
                {
                    lastSelection = CheckPoint;
                }
                //Debug.Log("Point Enregistrer");
            }
            
        }
        else
        {
            //Debug.Log("Selectionner une Usine");
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
    public void levelLoose(string Message)
    {
        this.Message = Message;
        SceneManager.LoadScene("GAMEOVER_MENU");
    }

    public void quit()
    {
        Application.Quit();
    }

    


}
