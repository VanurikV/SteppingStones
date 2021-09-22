using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerPrefsScript : MonoBehaviour
{

    public Slider SliderPlay;
    public Slider SliderFx;



    private void Start()
    {
        //проверяем если ключа не было то создаем
        if (!PlayerPrefs.HasKey("PlayVolume"))
        {
            PlayerPrefs.SetFloat("PlayVolume", 0.5f);
            SliderPlay.value = 0.5f;
            PlayerPrefs.Save();
        }
        else
        {
            //если ключ был то выставляем значение
            float Vol = PlayerPrefs.GetFloat("PlayVolume");
            SliderPlay.value = Vol;
            
        }


        //проверяем если ключа не было то создаем
        if (!PlayerPrefs.HasKey("FxVolume"))
        {
            PlayerPrefs.SetFloat("FxVolume", 0.5f);
            SliderFx.value = 0.5f;
            PlayerPrefs.Save();
        }
        else
        {
            //если ключ был то выставляем значение
            float fx = PlayerPrefs.GetFloat("FxVolume");
            SliderFx.value = fx;
            
        }

        if (!PlayerPrefs.HasKey("MaxCompleteLevel"))
        {
            PlayerPrefs.SetInt("MaxCompleteLevel", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
            PlayerPrefs.Save();
        }

    }

    /// <summary>Save data onSliderChange </summary>
    public void SavePlay()
    {
        PlayerPrefs.SetFloat("PlayVolume", SliderPlay.value);
        PlayerPrefs.Save();
    }

    /// <summary>Save data onSliderChange </summary>
    public void SaveFx()
    {
        PlayerPrefs.SetFloat("FxVolume", SliderFx.value);
        PlayerPrefs.Save();
    }

}
