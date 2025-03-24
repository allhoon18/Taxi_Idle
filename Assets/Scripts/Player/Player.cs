using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }

    private NavMeshAgent agent;
    private PassengerSpawner passengerSpawner;

    public Destination CurrentDestination;

    public Passenger CurrentPassenger;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        passengerSpawner = GetComponent<PassengerSpawner>();
        agent.speed = 10f;

        StartCoroutine(Initialize());
    }

    IEnumerator Initialize()
    {
        yield return new WaitForEndOfFrame();
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        //stateMachine.Update();
    }

    public void SetPassenger()
    {
        CurrentPassenger = passengerSpawner.SpawnPassenger();
        CurrentPassenger.IntiPassenger();
        agent.destination = CurrentPassenger.PickUpPoint.position;
    }

    public void SetDestination()
    {
        CurrentDestination = CurrentPassenger.TargetDestination;
        agent.destination = CurrentDestination.transform.position;
        CurrentPassenger.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out Passenger passenger))
            stateMachine.ChangeState(stateMachine.DriveState);
        else if (other.TryGetComponent(out Destination destination))
        {
            if(destination.DestinationName == CurrentDestination.DestinationName)
            {
                Debug.Log("도착");
                stateMachine.ChangeState(stateMachine.IdleState);
            }
                
        }
            
    }
}
