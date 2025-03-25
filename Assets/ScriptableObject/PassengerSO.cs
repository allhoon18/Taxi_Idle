using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassengerData", menuName = "New Passenger")]
[Serializable]
public class PassengerSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public float InitialPatience { get; private set; }
    [field: SerializeField, Range(0f,1f)] public float PatienceRaiseRate { get; private set; }
}
