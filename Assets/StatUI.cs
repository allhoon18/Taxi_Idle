using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI decayText;
    [SerializeField] TextMeshProUGUI GoldText;

    private void Update()
    {
        speedText.text = GameManager.Instance.Player.Stat.Speed.ToString();
        decayText.text = GameManager.Instance.Player.Stat.PatienceDecayRate.ToString();
        GoldText.text = GameManager.Instance.Player.Stat.Gold.ToString();
    }
}
