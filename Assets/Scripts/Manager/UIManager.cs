using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance != null) return instance;

            instance = FindObjectOfType<UIManager>();

            if (instance == null)
            {
                GameObject obj = new GameObject("UIManager");
                instance = obj.AddComponent<UIManager>();
                DontDestroyOnLoad(obj);
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canvasTransform = GameObject.FindWithTag("UI").transform;
    }

    public void Initialize()
    {
        ShowPopUp<BaseUI>(Data.UPGRADE_UI);
        UISet[Data.STAT_UI] = FindObjectOfType<StatUI>();
        UISet[Data.STAT_UI].Initialize();

        UISet[Data.INGAME_UI] = FindObjectOfType<InGameUI>();
        UISet[Data.INGAME_UI].Initialize();

        ClosePopUp(Data.UPGRADE_UI);
    }

    Transform canvasTransform;
    Dictionary<string,BaseUI> UISet = new Dictionary<string, BaseUI>();

    public T ShowPopUp<T>(string popUpName) where T : BaseUI
    {
        GameObject obj = Resources.Load(Data.POP_UP_PATH + popUpName) as GameObject;

        GameObject popUpUI = Instantiate(obj, canvasTransform);

        T t = popUpUI.GetComponent<T>();

        UISet[popUpName] = t;

        popUpUI.gameObject.SetActive(true);
        t.Initialize();

        return t;
    }

    public void OpenPopUp(string popUpName)
    {
        BaseUI baseUI;

        if (UISet.TryGetValue(popUpName, out baseUI))
        {
            baseUI.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log(baseUI);
        }
    }

    public void ClosePopUp(string popUpName)
    {
        BaseUI baseUI;

        if(UISet.TryGetValue(popUpName, out baseUI))
        {
            baseUI.gameObject.SetActive(false);
        }
    }

    public void DeletePopUp(string popUpName)
    {
        BaseUI baseUI;

        if (UISet.TryGetValue(popUpName, out baseUI))
        {
            Destroy(baseUI.gameObject);
            UISet.Remove(popUpName);
        }
    }

    public BaseUI GetUI(string uiKey)
    {
        BaseUI baseUI;

        if (UISet.TryGetValue(uiKey, out baseUI))
        {
            return baseUI;
        }
        else
            return null;
    }
}
