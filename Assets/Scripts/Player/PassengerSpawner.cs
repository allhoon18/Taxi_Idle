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

        if (!isSpawned)
        {
            Destination destination = DestinationManager.Instance.SetRandomDestination();
            spawnPos = destination.transform.position + Vector3.up;
            passengerObj = Instantiate(passengerPrefab, spawnPos, Quaternion.Euler(new Vector3(0, destination.roadDirAngle, 0)));
            isSpawned = true;
        }
        else
        {
            Destination destination = DestinationManager.Instance.SetRandomDestination();
            passengerObj.transform.position = destination.transform.position + Vector3.up;
            passengerObj.transform.rotation = Quaternion.Euler(new Vector3(0, destination.roadDirAngle, 0));
            passengerObj.SetActive(true);
        }

        Passenger passenger = passengerObj.GetComponent<Passenger>();
        return passenger;
    }
}
