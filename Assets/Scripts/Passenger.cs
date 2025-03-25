using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[Serializable]
public class Passenger : MonoBehaviour
{
    public PassengerSO Data;
    public Destination TargetDestination;
    public Transform PickUpPoint;

    [field : Header("Passenger Info")]
    [field : SerializeField] public float Patience { get; private set; }
    [field: SerializeField] public float MaxPatience;

    private void Awake()
    {
        PickUpPoint = transform.GetChild(0);
    }

    void SetTargetDestination()
    {
        do
        {
            TargetDestination = DestinationManager.Instance.SetRandomDestination();
        }
        while (transform.position == TargetDestination.transform.position);
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

    public void ChagePatienceValue(float amount)
    {
        Patience = Mathf.Max(0, Patience - amount);
    }
}
