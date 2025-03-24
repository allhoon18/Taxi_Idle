using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    private static DestinationManager instance;
    public static DestinationManager Instance { get => instance; }

    [SerializeField] public List<Destination> Destinations; 

    private void Awake()
    {
        if(Instance == null)
        {
            instance = this;
        }
    }

    public Destination SetRandomDestination()
    {
        if (Destinations.Count == 0) return null;

        return Destinations[Random.Range(0, Destinations.Count)];
    }
}
