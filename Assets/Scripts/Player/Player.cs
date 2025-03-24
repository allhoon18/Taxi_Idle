using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerController Controller;
    public PlayerStats Stat;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Player = this;
        Controller = GetComponent<PlayerController>();
        Stat = GetComponent<PlayerStats>();

        StartCoroutine(Initialize());
    }

    IEnumerator Initialize()
    {
        yield return new WaitForEndOfFrame();
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out Passenger passenger))
            stateMachine.ChangeState(stateMachine.DriveState);
        else if (other.TryGetComponent(out Destination destination))
        {
            if (destination.DestinationName == Controller.CurrentDestination.DestinationName)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }

        }

    }
}
