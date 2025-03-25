using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerStatus
{
    Empty,
    OnBoard
}

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private PassengerSpawner passengerSpawner;
    private PlayerStats stat;
    private IndicatorHandler indicatorHandler;

    public Destination CurrentDestination;

    public Passenger CurrentPassenger;

    public float PassedTime;

    public void Init(IndicatorHandler indicatorHandler, PlayerStats stat)
    {
        agent = GetComponent<NavMeshAgent>();
        passengerSpawner = GetComponent<PassengerSpawner>();
        agent.speed = 10f;
        this.indicatorHandler = indicatorHandler;
        this.stat = stat;
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

    public void SetSign(PlayerStatus playerStatus)
    {
        switch(playerStatus)
        {
            case PlayerStatus.Empty:
                indicatorHandler.SetEmpty();
                break;

            case PlayerStatus.OnBoard:
                indicatorHandler.SetOnBoard();
                break;
        }
    }

    public void UpdateParameter()
    {
        PassedTime += Time.deltaTime;
        CurrentPassenger.ChagePatienceValue(stat.PatienceDecayRate);
        indicatorHandler.ChangeFillRatio(CurrentPassenger.Patience / CurrentPassenger.MaxPatience);
    }
}
