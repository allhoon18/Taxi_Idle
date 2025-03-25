using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUI : BaseUI
{
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI decayText;
    [SerializeField] TextMeshProUGUI GoldText;

    [SerializeField] TextMeshProUGUI addSpeed;
    [SerializeField] TextMeshProUGUI reduceDecay;
    [SerializeField] TextMeshProUGUI addGold;

    public override void Initialize()
    {
        Refresh();

        addSpeed.gameObject.SetActive(false);
        reduceDecay.gameObject.SetActive(false);
        addGold.gameObject.SetActive(false);
    }

    public override void Refresh()
    {
        speedText.text = GameManager.Instance.Player.Stat.Speed.ToString();
        decayText.text = GameManager.Instance.Player.Stat.PatienceDecayRate.ToString();
        GoldText.text = GameManager.Instance.Player.Stat.Gold.ToString();
    }

    public override void ChangeOnStat(StatType type, float value)
    {
        GameObject activeObject = null;

        switch(type)
        {
            case StatType.Speed:
                activeObject = addSpeed.gameObject;
                addSpeed.text = $"+{value}";
                break;
            case StatType.DecayRate:
                activeObject = reduceDecay.gameObject;
                reduceDecay.text = $"-{value}";
                break;
            case StatType.Gold:
                activeObject = addGold.gameObject;
                addGold.text = $"+{value}";
                break;
        }

        activeObject.SetActive(true);

        StartCoroutine(InactiveObject(activeObject));
    }

    IEnumerator InactiveObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }


}
