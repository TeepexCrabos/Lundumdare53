using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<GameObject> usine = new List<GameObject>();
    [SerializeField] private string Niveau;
    private string lastLevel;
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

   public void setlevel(string level)
    {
        lastLevel = Niveau;
        Niveau = level;
    }
    public void CheckPointSelector(GameObject CheckPoint)
    {

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
                SceneManager.LoadScene("LEVEL2");
                break;
            case "":
                SceneManager.LoadScene("LEVEL3");
                break;
        }
       
    }

    public void quit()
    {
        Application.Quit();
    }

    


}
