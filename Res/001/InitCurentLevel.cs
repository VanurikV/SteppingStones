using System;
using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed partial class InitAllSystem : IEcsInitSystem
    {
        public void InitCurrentLevel()
        {
            LoadLevelData();
            CopyLevelData();

            
        }

        private void CopyLevelData()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    _globalData.CurrentLevelMap[x, y].value =
                        _globalData.AllLevelMap[_globalData.CurrentLevel][x, y].value;

                    _globalData.CurrentLevelMap[x, y].type =
                        _globalData.AllLevelMap[_globalData.CurrentLevel][x, y].type;
                }
            }
        }


        /// <summary>Загружаем номер текущего уровня</summary>
        public void LoadLevelData()
        {
            if (PlayerPrefs.HasKey("CurrentLevel"))
            {
                _globalData.CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
            }
            else
            {
                PlayerPrefs.SetInt("CurrentLevel",0);
                PlayerPrefs.Save();
                _globalData.CurrentLevel = 0;
            }
        }

    }
}