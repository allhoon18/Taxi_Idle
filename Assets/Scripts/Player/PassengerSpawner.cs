using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    [SerializeField] GameObject passengerPrefab;

    bool isSpawned;
    GameObject passengerObj;

    public Passenger SpawnPassenger()
    {
        Vector3 spawnPos;
        Destination destination;

        if (!isSpawned)
        {
            destination = DestinationManager.Instance.SetRandomDestination();
            spawnPos = destination.transform.position + Vector3.up;
            passengerObj = Instantiate(passengerPrefab, spawnPos, Quaternion.Euler(new Vector3(0, destination.roadDirAngle, 0)));
            isSpawned = true;
        }
        else
        {
            destination = DestinationManager.Instance.SetRandomDestination();
            passengerObj.transform.position = destination.transform.position + Vector3.up;
            passengerObj.transform.rotation = Quaternion.Euler(new Vector3(0, destination.roadDirAngle, 0));
            passengerObj.SetActive(true);
        }

        Passenger passenger = passengerObj.GetComponent<Passenger>();
        passenger.StartDestination = destination;
        return passenger;
    }
}
