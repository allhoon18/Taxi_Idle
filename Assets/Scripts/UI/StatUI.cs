using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUI : BaseUI
{
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI decayText;
    [SerializeField] TextMeshProUGUI GoldText;

    public override void Initialize()
    {
        Refresh();
    }

    public override void Refresh()
    {
        speedText.text = GameManager.Instance.Player.Stat.Speed.ToString();
        decayText.text = GameManager.Instance.Player.Stat.PatienceDecayRate.ToString();
        GoldText.text = GameManager.Instance.Player.Stat.Gold.ToString();
    }
}
