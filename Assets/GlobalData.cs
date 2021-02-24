using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;
using UnityEngine.UI;


public class Cell
{
    public int value;
    public CellType type;
    
}




public enum CellType
{
    /// <summary>пустая клетка</summary>
    Empty,
    /// <summary>Есть значение</summary>
    Value,
    /// <summary>Заполнена камнем </summary>
    Filled,
    /// <summary>финишная клетка</summary>
    Finish,
}


public class GlobalData
{
    public int CurrentLevel = 0;

    
    public Cell[][,] AllLevelMap;
    public Cell[,] CurrentLevelMap;

    public GameObject StonePrefab;
    public GameObject EptyStonePrefab;
    public GameObject FinishPrefab;

    
    public SoundFxScript SoundFxScript;
    public SoundPlayScript SoundPlayScript;


}

public static class Const
{
    /// <summary>размер клетки поля в пикселях</summary>
    public const int CellSizePx = 100;

    /// <summary>Размер игрового  поля</summary>
    public const int MapSize = 9;

    /// <summary>Максимальное количество уровней</summary>
    public const int MaxLevel = 16;

    /// <summary>Левый верхний угол игрового поля</summary>
    public const float FieldPosX = 0;
    public const float FieldPosY = 0;

    /// <summary>Перевод координат карты в экранные</summary>
    public static Vector2 Map2World(Vector2Int pos)
    {
        Vector2 worldPos=new Vector2(FieldPosX+ pos.x*CellSizePx, FieldPosY - pos.y * CellSizePx);
        return worldPos;
    }

}

public enum Cross
{
    ArrowUp,
    ArrowDown,
    ArrowLeft,
    ArrowRight
}

public enum SoundFx
{
    ButtonClick,
    StoneClick,
    StoneUnrool,
    LevelComplite,
}