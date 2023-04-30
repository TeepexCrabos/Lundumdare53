using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private List<GameObject> usine = new List<GameObject>();
    [SerializeField] private string Niveau;
    [SerializeField] private string lastLevel;
    [SerializeField] private string Message;
    public GameObject HUD;
    // Start is called before the first frame update
    
   
    public void SetUsine(List<GameObject>UsineDansleNiveau)
    {
        usine = UsineDansleNiveau;
        
    }


    

   public void Setlevel(string level)
    {
        lastLevel = Niveau;
        Niveau = level;
    }

    
   
    public void ChangerLaScene()
    {
        switch (Niveau)
        {
            case "START_MENU":
                SceneManager.LoadScene("LEVEL1");
                break;
            case "GAMEOVER":
                SceneManager.LoadScene("START_MENU");
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
                SceneManager.LoadScene("WIN_MENU");
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
