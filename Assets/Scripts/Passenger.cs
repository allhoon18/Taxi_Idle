using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[Serializable]
public class Passenger : MonoBehaviour
{
    public PassengerSO Data;
    public Destination StartDestination;
    public Destination TargetDestination;

    [field : Header("Passenger Info")]
    [field : SerializeField] public float Patience { get; private set; }
    [field: SerializeField] public float MaxPatience;

    public void IntiPassenger()
    {
        TargetDestination = DestinationManager.Instance.SetRandomDestination();

        MaxPatience = Data.InitialPatience + CalculateDistance() * Data.PatienceRaiseRate;
        Patience = MaxPatience;
    }

    public float CalculateDistance()
    {
        return (TargetDestination.transform.position - StartDestination.transform.position).magnitude;
    }

    public void ChagePatienceValue(float amount)
    {
        Patience = Mathf.Max(0, Patience - amount);
    }
}
