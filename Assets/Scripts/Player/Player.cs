using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }

    private NavMeshAgent agent;
    private PassengerSpawner passengerSpawner;

    public Transform Destination;

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
        stateMachine.ChangeState(stateMachine.IdleState);
        agent.speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //stateMachine.Update();
    }

    public void SetPassenger()
    {
        CurrentPassenger = passengerSpawner.SpawnPassenger();
        CurrentPassenger.SetTargetDestination();
        agent.destination = CurrentPassenger.PickUpPoint.position;
    }

    public void SetDestination()
    {
        agent.destination = CurrentPassenger.TargetDestination.position;
        Destroy(CurrentPassenger.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out Passenger passenger))
            stateMachine.ChangeState(stateMachine.DriveState);
        else if (other.TryGetComponent(out Destination destination))
            stateMachine.ChangeState(stateMachine.IdleState);
    }
}
