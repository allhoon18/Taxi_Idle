using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public Transform TargetDestination;
    public Transform PickUpPoint;

    private void Awake()
    {
        PickUpPoint = transform.GetChild(0);
    }

    public void SetTargetDestination()
    {
        TargetDestination = DestinationManager.Instance.SetRandomDestination();
    }
}
