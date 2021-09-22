using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace Stone
{
    sealed partial class InitAllSystem : IEcsInitSystem
    {
        public void LoadLevels()
        {
            for (int i = 0; i < Const.MaxLevel; i++)
            {
                TextAsset text = Resources.Load<TextAsset>("LevelMap/Level" + i.ToString("D2"));
                Parse(text.text, i);
            }
        }

        private void Parse(string text, int level)
        {
            _globalData.AllLevelMap[level] = new Cell[Const.MapSize, Const.MapSize];

            List<string> Allline = text.Replace('\r', ' ').Split('\n').Select(x => x.Trim()).ToList();

            for (int y = 0; y < Const.MapSize; y++)
            {

                List<string> line = Allline[y].Split(',').ToList();

                for (int x = 0; x < Const.MapSize; x++)
                {

                    _globalData.AllLevelMap[level][x, y] = new Cell();

                    switch (line[x])
                    {
                        case "  ":
                            _globalData.AllLevelMap[level][x, y].value = 0;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Empty;
                            break;

                        case "55":
                            _globalData.AllLevelMap[level][x, y].value = 0;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Filled;
                            break;

                        case "99":
                            _globalData.AllLevelMap[level][x, y].value = 0;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Finish;
                            break;

                        #region Digits
                        case "00":
                            _globalData.AllLevelMap[level][x, y].value = 0;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "01":
                            _globalData.AllLevelMap[level][x, y].value = 1;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "02":
                            _globalData.AllLevelMap[level][x, y].value = 2;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "03":
                            _globalData.AllLevelMap[level][x, y].value = 3;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "04":
                            _globalData.AllLevelMap[level][x, y].value = 4;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "05":
                            _globalData.AllLevelMap[level][x, y].value = 5;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "06":
                            _globalData.AllLevelMap[level][x, y].value = 6;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "07":
                            _globalData.AllLevelMap[level][x, y].value = 7;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "08":
                            _globalData.AllLevelMap[level][x, y].value = 8;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                        case "09":
                            _globalData.AllLevelMap[level][x, y].value = 9;
                            _globalData.AllLevelMap[level][x, y].type = CellType.Value;
                            break;
                            #endregion Digits
                    }
                }
            }
        }
    }
}


