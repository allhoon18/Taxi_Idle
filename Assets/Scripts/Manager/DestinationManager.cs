using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    private static DestinationManager instance;
    public static DestinationManager Instance { get => instance; }

    [SerializeField] public List<Destination> Destinations;
    [SerializeField] private Material startPointMaterial;
    [SerializeField] private Material endPointMaterial;

    private Destination startPoint;
    private Destination endPoint;

    private void Awake()
    {
        if(Instance == null)
        {
            instance = this;
        }
    }

    private void InactiveAllDestination()
    {
        if (Destinations == null) return;

        foreach(Destination destination in Destinations)
        {
            destination.gameObject.SetActive(false);
        }
    }

    public Destination SetRandomStartPoint()
    {
        startPoint = Destinations[Random.Range(0, Destinations.Count)];
        return startPoint;
    }

    public Destination SetRandomDestination()
    {
        InactiveAllDestination();

        do
        {
            endPoint = Destinations[Random.Range(0, Destinations.Count)];
        }
        while (endPoint == startPoint);

        startPoint.gameObject.SetActive(true);
        startPoint.gameObject.GetComponentInChildren<MeshRenderer>().material = startPointMaterial;

        endPoint.gameObject.SetActive(true);
        endPoint.gameObject.GetComponentInChildren<MeshRenderer>().material = endPointMaterial;

        return endPoint;
    }
}
