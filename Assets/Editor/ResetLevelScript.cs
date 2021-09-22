using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ResetLevelScript 
{
    [MenuItem("My Tools/ResetLevel")]
    public static void ResetLevel()
    {
        //PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("CurrentLevel", 0);
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("MaxCompleteLevel", 0);
        PlayerPrefs.Save();
     
    }
}
