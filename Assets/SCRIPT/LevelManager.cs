using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> UsineDansLeNiveau = new List<GameObject>();
    private GameManager GameManager;
    public GameObject HUD;
    [SerializeField] private string Niveau;
    public int BienArrivé;
    public GameObject UsineSelect;
    private bool UsineSel = false;
    public GameObject lastSelection;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.Setlevel(Niveau);
        GameManager.SetUsine(UsineDansLeNiveau);
        HUD = GameObject.Find("---------------HUD---------------------");
        GameManager.HUD = HUD;
    }
    private void FixedUpdate()
    {
        if (BienArrivé == UsineDansLeNiveau.Count)
        {
            GameManager.ChangerLaScene();
        }
    }

    public void Play()
    {
        bool valider = false;
        for (int i = 0; i < UsineDansLeNiveau.Count; i++)
        {
            if (UsineDansLeNiveau[i].GetComponent<Usine_Script>().CheckPointSelectionner[0] != null)
            {
                valider = true;
            }
            else
            {
                valider = false;
            }

        }
        if (valider == true)
        {
            for (int i = 0; i < UsineDansLeNiveau.Count; i++)
            {
                UsineDansLeNiveau[i].GetComponent<SpawnCamion_Script>().LancerCamion();
            }
            HUD.SetActive(false);
        }

    }



    public void UsineSelector(GameObject Usine)
    {
        Debug.Log("UsineSelector");
        if (UsineSelect == null)
        {
            Debug.Log("Usine Select");
            Usine.GetComponent<Usine_Script>().IsSelect();
            UsineSelect = Usine;
            lastSelection = UsineSelect;
        }
        else if (Usine.name == UsineSelect.name)
        {
            Debug.Log("deselect usine");
            Usine.GetComponent<Usine_Script>().IsSelect();
            UsineSelect = null;
            lastSelection = null;
        }
        else if (Usine.name != UsineSelect.name)
        {
            Debug.Log("Change usine");
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
        Debug.Log("CheckPointSelector");
        if (UsineSelect != null)
        {
            Debug.Log("CheckPoint select");
            if (UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count > 0)
            {
                Debug.Log("pointselectsupp0");
                foreach (GameObject PointSelect in UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner)
                {
                    if (PointSelect.name == CheckPoint.name)
                    {


                        suppr = true;
                    }
                }
                if (suppr == true)
                {
                    for (int i = 0; i < UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count; i++)
                    {
                        if (UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner[i].name == CheckPoint.name)
                        {
                            j = i;
                            count = UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count;
                        }
                    }
                    Debug.Log("Bob");
                    while (count > j)
                    {
                        UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.RemoveAt(j);
                        Debug.Log("Point Suprimer");
                        //Debug.Log(count);
                        //Debug.Log(j);
                        count--;
                    }

                    lastSelection = UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner[UsineSelect.GetComponent<Usine_Script>().CheckPointSelectionner.Count - 1];


                }

                if (suppr == false)
                {
                    effectuer = CheckPoint.GetComponent<checkpoint_Script>().Select(UsineSelect, lastSelection);
                    if (effectuer)
                    {
                        lastSelection = CheckPoint;
                    }
                    Debug.Log("Point Enregistrer");
                }

            }
            else
            {
                Debug.Log("TestEnregistrement");
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
            Debug.Log("Selectionner une Usine");
        }



    }
}
