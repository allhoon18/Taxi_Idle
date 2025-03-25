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

    [SerializeField] private GameObject SuccessSign;
    [SerializeField] private GameObject FailSign;

    private void Start()
    {
        GameManager.Instance.IndicatorHandler = this;
        FailSign.SetActive(false);
        SuccessSign.SetActive(false);
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

    public void SetResultSign(bool isFail)
    {
        if(isFail)
        {
            FailSign.SetActive(true);
            SuccessSign.SetActive(false);
        }
        else
        {
            FailSign.SetActive(true);
            SuccessSign.SetActive(false);
        }

        StartCoroutine(HideSign());
    }

    IEnumerator HideSign()
    {
        yield return new WaitForSeconds(2f);
        FailSign.SetActive(false);
        SuccessSign.SetActive(false);
    }
}
