using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Destination : MonoBehaviour
{
    [field : SerializeField] public string DestinationName { get; private set; }
    public float roadDirAngle;

    void Start()
    {
        DestinationManager.Instance.Destinations.Add(this);
    }
}
