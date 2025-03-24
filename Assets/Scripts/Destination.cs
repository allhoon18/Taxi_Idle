using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    [field : SerializeField] public string DestinationName { get; private set; }

    void Start()
    {
        DestinationManager.Instance.Destinations.Add(this.transform);
    }
}
