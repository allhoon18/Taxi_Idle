using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    [SerializeField] GameObject passengerPrefab;
    [SerializeField] private float spawnRange;
    [SerializeField] private Vector3 spawnAreaOffset;
   
    public Passenger SpawnPassenger()
    {
        float spawnDistance = Random.Range(0, spawnRange);
        Vector3 spawnPos = transform.position + (transform.forward * spawnDistance) + spawnAreaOffset;
        GameObject passengerObj = Instantiate(passengerPrefab, spawnPos, Quaternion.identity);
        Passenger passenger = passengerObj.GetComponent<Passenger>();
        return passenger;
    }
}
