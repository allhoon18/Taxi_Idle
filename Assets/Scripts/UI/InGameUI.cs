using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : BaseUI
{
    [SerializeField] private Button upgradeButton;

    public override void Initialize()
    {
        upgradeButton.onClick.AddListener(OnShowUpgradeUI);
    }

    public override void Refresh()
    {
        
    }

    void OnShowUpgradeUI()
    {
        UIManager.Instance.GetUI(Data.UPGRADE_UI).Refresh();
        UIManager.Instance.OpenPopUp(Data.UPGRADE_UI);
    }

}
