using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public Button[] LevelButtons;

    public Sprite[] RuneOff;

    public Sprite[] RuneOn;

    public Sprite Lock;

    
    void Start()
    {
        int MaxLevel = PlayerPrefs.GetInt("MaxCompleteLevel");

        for (int i = 0; i <= MaxLevel-1; i++)
        {
            LevelButtons[i].image.sprite = RuneOn[i];
        }
        
        LevelButtons[MaxLevel].image.sprite = RuneOff[MaxLevel];

        for (int i = MaxLevel+1; i <16 ; i++)
        {
            LevelButtons[i].image.sprite = Lock;
            LevelButtons[i].interactable = false;
        }
    }

    public void OnButtonLevelClick(int level)
    {
       
        PlayerPrefs.SetInt("CurrentLevel", level);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void OnContinueClick()
    {
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("MaxCompleteLevel"));
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    
}
