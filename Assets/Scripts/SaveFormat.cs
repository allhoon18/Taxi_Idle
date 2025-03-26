using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFormat
{
    public int Gold;
    public float Speed;
    public float BreakRate;
    public float DecayRate;

    public SaveFormat(int gold, float speed, float breakRate, float decayRate)
    {
        Gold = gold;
        Speed = speed;
        BreakRate = breakRate;
        DecayRate = decayRate;
    }
}
