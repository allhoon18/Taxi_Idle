using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Data
{
    public static readonly string POP_UP_PATH = "UI/PopUp/";
    public static string UPGRADE_UI = "UpgradeUI";
    public static string STAT_UI = "StatUI";
    public static string INGAME_UI = "InGameUI";

    public static string SAVE_PATH = Path.Combine(Application.dataPath + "/Data/Save", "save.json");
}
