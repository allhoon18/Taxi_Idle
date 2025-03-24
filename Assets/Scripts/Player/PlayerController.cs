using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private PassengerSpawner passengerSpawner;

    public IndicatorHandler IndicatorHandler;

    public Destination CurrentDestination;

    public Passenger CurrentPassenger;

    public float PassedTime;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        passengerSpawner = GetComponent<PassengerSpawner>();
        agent.speed = 10f;
        IndicatorHandler = GameManager.Instance.IndicatorHandler;

        
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
}
