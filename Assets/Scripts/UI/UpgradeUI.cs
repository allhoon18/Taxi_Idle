using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : BaseUI
{
    [SerializeField] private Button speedUpButton;
    [SerializeField] private Button decayDownButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private TextMeshProUGUI speedPrice;
    [SerializeField] private TextMeshProUGUI decayPrice;

    public override void Initialize()
    {
        closeButton.onClick.AddListener(OnCloseUpgradeTab);
        speedUpButton.onClick.AddListener(OnSpeedUp);
        decayDownButton.onClick.AddListener(OnDecayDown);

        Refresh();
    }

    void OnSpeedUp()
    {
        if(GameManager.Instance.Player.Stat.Gold >= GameManager.Instance.Player.Stat.GetUpgradePrice(StatType.Speed))
        {
            GameManager.Instance.Player.Stat.Gold -= GameManager.Instance.Player.Stat.GetUpgradePrice(StatType.Speed);
            GameManager.Instance.Player.Stat.ChangeStat(StatType.Speed, 1);
        }
    }

    void OnDecayDown()
    {
        if (GameManager.Instance.Player.Stat.Gold >= GameManager.Instance.Player.Stat.GetUpgradePrice(StatType.DecayRate))
        {
            GameManager.Instance.Player.Stat.Gold -= GameManager.Instance.Player.Stat.GetUpgradePrice(StatType.DecayRate);
            GameManager.Instance.Player.Stat.ChangeStat(StatType.DecayRate, -0.2f);
        }
    }

    void OnCloseUpgradeTab()
    {
        UIManager.Instance.ClosePopUp(Data.UPGRADE_UI);
    }

    public override void Refresh()
    {
        speedPrice.text = $"Cost : {GameManager.Instance.Player.Stat.GetUpgradePrice(StatType.Speed).ToString()}";
        decayPrice.text = $"Cost : {GameManager.Instance.Player.Stat.GetUpgradePrice(StatType.DecayRate).ToString()}";
    }
}
