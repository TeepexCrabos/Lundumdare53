using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Camion : MonoBehaviour
{
    public GameObject Objectif;
    public bool ObjAttend=false;
    private Camion_Class camion;
    [SerializeField] List<GameObject> Destination;
    public Vector3 currentTarget;
    private NavMeshAgent navMeshAgent;

    [SerializeField] bool CurrentTargetSet;
    public float RangeForChangeCurrentTarget;

    [SerializeField] bool Collision;

    [SerializeField] float VitesseCamion;

    private Usine_Script Usine;

    private int i = 0;

    private GameManager gameManager;

    private LevelManager LevelManager;

    public bool pasdedestruction = false;

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        Usine = this.transform.GetComponentInParent<Usine_Script>();
        Objectif = Usine.Objectif;
        //this.GetComponent<MeshRenderer>().material = Usine.Material;
        setDestination(Usine.CheckPointSelectionner);
        camion = new Camion_Class(VitesseCamion, Destination);
        CurrentTargetSet = false;
        Collision = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Collision == false)
        {
            Deplacement();
        }
        else
        {
            Carton();
        }
        
    }

    private void Deplacement()
    {
        if (!CurrentTargetSet) RechercheTarget();

        Debug.Log("Camion Destination Setup");
        if (CurrentTargetSet)
            navMeshAgent.SetDestination(currentTarget);

        Vector3 DistanceToCurrentTarget = transform.position - currentTarget;

        if (DistanceToCurrentTarget.magnitude <= 1f/*RangeForChangeCurrentTarget*/)
        {
            CurrentTargetSet = false;
            Debug.Log("Camion Destination Attente");
        }
            
    }

    public void setDestination(List<GameObject>destination)
    {
        
        Destination = destination;
    }
    private void RechercheTarget()
    {
        Debug.Log("Prochaine desination");
        currentTarget = camion.GetNextDestination(i);
       
        if (currentTarget == new Vector3(1000, 1000, 1000))
        {
            StartCoroutine(wait1Second());
            
        }
        i++;
        CurrentTargetSet = true;
    }
    IEnumerator wait1Second()
    {
        yield return new WaitForSecondsRealtime(2f);
        if(pasdedestruction == false)
        {
            Debug.Log("lol");
            gameManager.levelLoose("vous vous etes perdu ?");
        }
    }
    private void OnColliderEnter(Collision other)
    {
        Debug.Log("collision");
        pasdedestruction = true;
        switch (other.gameObject.tag)
        {
            case "Vehicule":
                Carton();
                break;
            case "Livraision":
                ColisLivrer(other);
                break;
             
        }

    }
    private void Carton()
    {
        
        gameManager.levelLoose("aie c'est l'accident");
      
    }

    private void ColisLivrer(Collision other)
    {
        if(other.gameObject.name == Objectif.name)
        {
            LevelManager.BienArrivé++;
            Destroy(this);
        }
        else
        {
            gameManager.levelLoose("pas le bon pint de livraison");
        }
        
    }
}
