using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Camion : MonoBehaviour
{
    [SerializeField] GameObject[] Destination;
    private Vector3 currentTarget;
    private NavMeshAgent navMeshAgent;

    [SerializeField] bool CurrentTargetSet;
    public float RangeForChangeCurrentTarget;

    [SerializeField] bool Collision;

    private int i = 0;

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
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

    private void RechercheTarget()
    {
        currentTarget = Destination[i].transform.position;
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
