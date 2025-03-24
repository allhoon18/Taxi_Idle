using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }

    private NavMeshAgent agent;
    private PassengerSpawner passengerSpawner;
    
    
    public IndicatorHandler IndicatorHandler;

    public Destination CurrentDestination;

    public Passenger CurrentPassenger;

    public float PassedTime;

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
        GameManager.Instance.Player = this;
        IndicatorHandler = GameManager.Instance.IndicatorHandler;

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
        stateMachine.Update();
    }

    public void SetPassenger()
    {
        CurrentPassenger = passengerSpawner.SpawnPassenger();
        CurrentPassenger.IntiPassenger();
        agent.destination = CurrentPassenger.PickUpPoint.position;

        PassedTime = 0;
    }

    public void SetDestination()
    {
        CurrentDestination = CurrentPassenger.TargetDestination;
        agent.destination = CurrentDestination.transform.position;
        CurrentPassenger.gameObject.SetActive(false);
    }

    public void UpdateParameter()
    {
        PassedTime += Time.deltaTime;
        CurrentPassenger.ChagePatienceValue(CurrentPassenger.Data.PatienceDecayRate);
        IndicatorHandler.ChangeFillRatio(CurrentPassenger.Patience / CurrentPassenger.MaxPatience);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out Passenger passenger))
            stateMachine.ChangeState(stateMachine.DriveState);
        else if (other.TryGetComponent(out Destination destination))
        {
            if(destination.DestinationName == CurrentDestination.DestinationName)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
                
        }
            
    }
}
