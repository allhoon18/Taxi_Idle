using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : BaseUI
{
    [SerializeField] private Button speedUpButton;
    [SerializeField] private Button decayDownButton;
    [SerializeField] private Button closeButton;

    public override void Initialize()
    {
        closeButton.onClick.AddListener(OnCloseUpgradeTab);
        speedUpButton.onClick.AddListener(OnSpeedUp);
        decayDownButton.onClick.AddListener(OnDecayDown);
    }

    void OnSpeedUp()
    {
        if(GameManager.Instance.Player.Stat.Gold >= 10)
        {
            GameManager.Instance.Player.Stat.Gold -= 10;
            GameManager.Instance.Player.Stat.Speed += 1;
        }
    }

    void OnDecayDown()
    {
        if (GameManager.Instance.Player.Stat.Gold >= 10)
        {
            GameManager.Instance.Player.Stat.Gold -= 10;
            GameManager.Instance.Player.Stat.PatienceDecayRate -= 1;
        }
    }

    void OnCloseUpgradeTab()
    {
        UIManager.Instance.ClosePopUp(Data.UPGRADE_UI);
    }

    public override void Refresh()
    {
        
    }
}
