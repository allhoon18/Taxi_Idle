using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    public static DestinationManager Instance;

    [SerializeField] public List<Transform> Destinations; 

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Transform SetRandomDestination()
    {
        if (Destinations.Count == 0) return null;

        return Destinations[Random.Range(0, Destinations.Count)];
    }
}
