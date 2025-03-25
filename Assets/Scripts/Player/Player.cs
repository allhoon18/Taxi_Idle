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
        yield return new WaitUntil(InitializeCondition);

        Controller.Init(GameManager.Instance.IndicatorHandler, Stat);

        stateMachine.ChangeState(stateMachine.IdleState);
    }

    bool InitializeCondition()
    {
        if (GameManager.Instance.IndicatorHandler == null) return false;

        else if (GameManager.Instance.Player == null) return false;

        return true;
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
            if (Controller.CurrentDestination == null) return;
            if (destination.DestinationName == Controller.CurrentDestination.DestinationName)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }

        }

    }
}
