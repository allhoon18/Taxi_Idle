using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorHandler : MonoBehaviour
{
    [SerializeField] private GameObject EmptySign;
    [SerializeField] private GameObject OnBoardSign;

    [SerializeField] private GameObject ParameterSet;
    [SerializeField] private Image Parameter;

    private void Start()
    {
        GameManager.Instance.IndicatorHandler = this;
    }

    public void SetEmpty()
    {
        EmptySign.SetActive(true);
        OnBoardSign.SetActive(false);
        ParameterSet.SetActive(false);
    }

    public void SetOnBoard()
    {
        EmptySign.SetActive(false);
        OnBoardSign.SetActive(true);
        ParameterSet.SetActive(true);

    }

    public void ChangeFillRatio(float ratio)
    {
        Parameter.fillAmount = ratio;
    }
}
