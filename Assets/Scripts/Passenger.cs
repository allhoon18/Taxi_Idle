using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public PassengerSO Data;
    public Destination TargetDestination;
    public Transform PickUpPoint;

    [field : Header("Passenger Info")]
    [field : SerializeField] public float Patience { get; private set; }
    private float MaxPatience;

    private void Awake()
    {
        PickUpPoint = transform.GetChild(0);
    }

    void SetTargetDestination()
    {
        TargetDestination = DestinationManager.Instance.SetRandomDestination();
    }

    public void IntiPassenger()
    {
        SetTargetDestination();

        MaxPatience = Data.InitialPatience + CalculateDistance() * Data.PatienceRaiseRate;
        Patience = MaxPatience;
    }

    public float CalculateDistance()
    {
        return (TargetDestination.transform.position - transform.position).magnitude;
    }
}
