using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Camion : MonoBehaviour
{
    private Camion_Class camion;
    [SerializeField] List<GameObject> Destination;
    private Vector3 currentTarget;
    private NavMeshAgent navMeshAgent;

    [SerializeField] bool CurrentTargetSet;
    public float RangeForChangeCurrentTarget;

    [SerializeField] bool Collision;

    [SerializeField] float VitesseCamion;

    private Usine_Script Usine;

    private int i = 0;

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Usine = this.transform.GetComponentInParent<Usine_Script>();
        this.GetComponent<MeshRenderer>().material = Usine.Material;
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
        Carton();
    }

    private void Deplacement()
    {
        if (!CurrentTargetSet) RechercheTarget();

        if (CurrentTargetSet)
            navMeshAgent.SetDestination(currentTarget);

        Vector3 DistanceToCurrentTarget = transform.position - currentTarget;

        if (DistanceToCurrentTarget.magnitude < RangeForChangeCurrentTarget)
            CurrentTargetSet = false;
    }

    public void setDestination(List<GameObject>destination)
    {
        Destination = destination;
    }
    private void RechercheTarget()
    {
        currentTarget = camion.GetNextDestination(i);
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
                ColisLivrer();
                break;
        }

    }
    private void Carton()
    {
        //carton
    }

    private void ColisLivrer()
    {
        
    }
}
