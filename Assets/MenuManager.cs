using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public string level = "WIN_MENU";
    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gamemanager.Setlevel(level);
    }

    public void nextBButtonClic()
    {
        gamemanager.Suite();
    }

    public void BMenu()
    {
        gamemanager.ChangerLaScene();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
