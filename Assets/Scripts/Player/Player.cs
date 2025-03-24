using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }

    private NavMeshAgent agent;

    public Transform destination;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            SetDestination();
        }
    }

    void SetDestination()
    {
        Debug.Log("SetDestination");

        if (DestinationManager.Instance.Destinations != null)
        {
            destination = DestinationManager.Instance.SetRandomDestination();
            agent.destination = destination.position;
        }
    }
}
