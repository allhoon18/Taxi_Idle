using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Player player; 

    public int Gold;
    public float Speed;
    public float SpawnRate;
    public float PatienceDecayRate;
    public float PassedTime;

    private Coroutine decayCoroutine;

    public void Init(Player player)
    {
        this.player = player;
    }

    public void ResetCoroutine()
    {
        if(decayCoroutine != null)
        {
            StopCoroutine(decayCoroutine);
            decayCoroutine = null;
        }
            
    }

    public void UpdateParameter()
    {
        PassedTime += Time.deltaTime;

        if(decayCoroutine == null)
            decayCoroutine = StartCoroutine(DecayPatience());

        player.IndicatorHandler.ChangeFillRatio(player.Controller.CurrentPassenger.Patience / player.Controller.CurrentPassenger.MaxPatience);

        if (player.Controller.CurrentPassenger.Patience == 0)
        {
            player.stateMachine.ChangeState(player.stateMachine.IdleState);
        }
    }

    IEnumerator DecayPatience()
    {
        yield return new WaitForSeconds(1f);
        player.Controller.CurrentPassenger.ChagePatienceValue(PatienceDecayRate);
        decayCoroutine = null;
    }

    public int CalculateGold()
    {
        return Mathf.RoundToInt(PassedTime + player.Controller.CurrentPassenger.Patience);
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }

}
