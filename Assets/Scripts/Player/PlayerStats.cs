using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    Speed,
    DecayRate,
    BreakForce,
    Gold
}

public class PlayerStats : MonoBehaviour
{
    private Player player; 

    public int Gold;
    public float Speed;
    public float BreakRate;
    public float PatienceDecayRate;
    public float PassedTime;

    private Coroutine decayCoroutine;

    public void Init(Player player)
    {
        this.player = player;

        SaveFormat save = GameManager.Instance.Load();

        if (save != null)
        {
            Gold = save.Gold;
            Speed = save.Speed;
            BreakRate = save.BreakRate;
            PatienceDecayRate = save.DecayRate;
        }

        UIManager.Instance.GetUI(Data.STAT_UI).Refresh();
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

    public void Pay()
    {
        int payment;

        if (player.Controller.CurrentPassenger.Patience == 0)
        {
            payment = CalculateGold() / 2;
            
        }
        else
        {
            payment = CalculateGold();
        }

        player.IndicatorHandler.SetResultSign(player.Controller.CurrentPassenger.Patience == 0);

        AddGold(payment);
    }

    public int CalculateGold()
    {
        return Mathf.RoundToInt(PassedTime + player.Controller.CurrentPassenger.Patience);
    }

    public void AddGold(int amount)
    {
        Gold += amount;
        UIManager.Instance.GetUI(Data.STAT_UI).Refresh();
        UIManager.Instance.GetUI(Data.STAT_UI).ChangeOnStat(StatType.Gold, amount);

        GameManager.Instance.Save();
    }

    public int GetUpgradePrice(StatType type)
    {
        switch (type)
        {
            case StatType.Speed:
                return 10 + (int)Speed - 10;

            case StatType.DecayRate:
                return 10 + 10 - Mathf.RoundToInt(PatienceDecayRate);

            case StatType.BreakForce:
                return 10 + (int)((1 - BreakRate) * 10);

            default:
                return 0;
        }
    }

    public void ChangeStat(StatType type, float value)
    {
        switch(type)
        {
            case StatType.Speed:
                Speed += value;
                player.Controller.SetSpeed(Speed);
                break;

            case StatType.DecayRate:
                PatienceDecayRate += value;
                break;

            case StatType.BreakForce:
                BreakRate -= value;
                break;
        }

        UIManager.Instance.GetUI(Data.STAT_UI).Refresh();
        UIManager.Instance.GetUI(Data.UPGRADE_UI).Refresh();
        UIManager.Instance.GetUI(Data.STAT_UI).ChangeOnStat(type, value);

        GameManager.Instance.Save();
    }

}
