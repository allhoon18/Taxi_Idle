using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public abstract void Initialize();
    public abstract void Refresh();
    public virtual void ChangeOnStat(StatType type, float value)
    {

    }
}
