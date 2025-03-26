using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public enum PassengerType
{
    Slow,
    Normal,
    Hasty
}

public class PassengerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] passengerPrefabs;

    Dictionary<PassengerType, GameObject> passengerData = new Dictionary<PassengerType, GameObject>();

    const int slowPassengerRate = 20;
    const int normalPassengerRate = 50;

    public PassengerType GetRandomPassengerType(int keyValue1, int keyValue2)
    {
        PassengerType spawnPassengerType;

        int randomNum = Random.Range(0, 100);

        if(randomNum < keyValue1)
        {
            spawnPassengerType = PassengerType.Slow;
        }
        else if(randomNum > keyValue1 && randomNum < keyValue2)
        {
            spawnPassengerType = PassengerType.Normal;
        }
        else
        {
            spawnPassengerType = PassengerType.Hasty;
        }

        return spawnPassengerType;
    }

    public Passenger SpawnPassenger()
    {
        Vector3 spawnPos;
        Destination destination = DestinationManager.Instance.SetRandomStartPoint();
        PassengerType spawnPassengerType = GetRandomPassengerType(slowPassengerRate, normalPassengerRate);

        GameObject passengerObj;

        if (passengerData.TryGetValue(spawnPassengerType, out passengerObj))
        {
            passengerObj.transform.position = destination.transform.position + Vector3.up;
            passengerObj.transform.rotation = Quaternion.Euler(new Vector3(0, destination.roadDirAngle, 0));
            passengerObj.SetActive(true);
        }
        else
        {
            spawnPos = destination.transform.position + Vector3.up;
            passengerObj = Instantiate(passengerPrefabs[((int)spawnPassengerType)], spawnPos, Quaternion.Euler(new Vector3(0, destination.roadDirAngle, 0)));
            passengerData[spawnPassengerType] = passengerObj;
        }

        Passenger passenger = passengerObj.GetComponent<Passenger>();
        passenger.StartDestination = destination;
        return passenger;
    }
}
