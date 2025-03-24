using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    [SerializeField] GameObject passengerPrefab;
    [SerializeField] private float spawnMaxRange;
    [SerializeField] private float spawnMinRange;
    [SerializeField] private Vector3 spawnAreaOffset;

    bool isSpawned;
    GameObject passengerObj;


    public Passenger SpawnPassenger()
    {
        float spawnDistance = Random.Range(spawnMinRange, spawnMaxRange);
        Vector3 spawnPos = transform.position + (transform.forward * spawnDistance) + spawnAreaOffset;
        if(!isSpawned)
        {
            passengerObj = Instantiate(passengerPrefab, spawnPos, Quaternion.identity);
            isSpawned = true;
        }
        else
        {
            passengerObj.transform.position = spawnPos;
            passengerObj.SetActive(true);
        }

        Passenger passenger = passengerObj.GetComponent<Passenger>();
        return passenger;
    }

}
