using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Button speedUpButton;
    [SerializeField] private Button decayDownButton;
    [SerializeField] private Button closeButton;

    private void Start()
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
        gameObject.SetActive(false);
    }
}
