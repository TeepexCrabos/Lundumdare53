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

    public GameObject devant;

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
        Debug.DrawLine(this.transform.position, devant.transform.position * 0.01f, Color.red);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(this.transform.position, devant.transform.position, out hit, 0.01f))
        { 
            Debug.Log(hit.collider.gameObject.tag);
            if(hit.collider.gameObject.tag == "camion")
            {
                pasdedestruction = true;
                Carton();
            }
            if(hit.collider.gameObject.tag == "Livraison")
            {
                pasdedestruction = true;
                ColisLivrer(hit.collider.gameObject.name);
            }
        }
        else
        {
            Deplacement();
        }
       
        
    }

    private void Deplacement()
    {
        if (!CurrentTargetSet) RechercheTarget();

        //Debug.Log("Camion Destination Setup");
        if (CurrentTargetSet)
            navMeshAgent.SetDestination(currentTarget);

        Vector3 DistanceToCurrentTarget = transform.position - currentTarget;
        //Debug.Log(DistanceToCurrentTarget.magnitude);

        if (DistanceToCurrentTarget.magnitude <= 1.2f/*RangeForChangeCurrentTarget*/)
        {
            CurrentTargetSet = false;
            //Debug.Log("Camion Destination Attente");
        }
            
    }

    public void setDestination(List<GameObject>destination)
    {
        
        Destination = destination;
    }
    private void RechercheTarget()
    {
        //Debug.Log("Prochaine desination");
        currentTarget = camion.GetNextDestination(i);
       if( i > Destination.Count)
        {
            if (currentTarget == Destination[Destination.Count-1].transform.position)
            {
                ColisLivrer(Destination[Destination.Count-1].name);

            }
            else
            {
                gameManager.levelLoose("vous vous etes perdu ?");
            }
        }
        
        i++;
        CurrentTargetSet = true;
    }
   
    

    private void Carton()
    {
        
        gameManager.levelLoose("aie c'est l'accident");
      
    }

    private void ColisLivrer(string other)
    {
        if(other == Objectif.name)
        {
            LevelManager.BienArrivé++;
            Destroy(this.gameObject);
        }
        else
        {
            gameManager.levelLoose("pas le bon point de livraison");
        }
        
    }
}
