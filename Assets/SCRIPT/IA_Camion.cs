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

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if(currentTarget == new Vector3(1000, 1000, 1000))
        {
            gameManager.levelLoose();
        }
        i++;
        CurrentTargetSet = true;
    }

    private void OnTriggerEnter(Collider other)
    {

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
        
        gameManager.levelLoose();
        //carton
    }

    private void ColisLivrer(Collider other)
    {
        if(other.gameObject.name == Objectif.name)
        {
            gameManager.ChangerLaScene();
        }
        gameManager.levelLoose();
    }
}
