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
    Empty,
    Value,
    Filled,
    Finish,
}


public class GlobalData
{
    public int CurrentLevel = 0;

    
    public Cell[][,] AllLevelMap;
    public Cell[,] CurrentLevelMap;

    public GameObject StonePrefab;
    
    public GameObject FinishPrefab;

    
    public SoundFxScript SoundFxScript;
    public SoundPlayScript SoundPlayScript;


}

public static class Const
{
    
    public const int CellSizePx = 100;

    
    public const int MapSize = 9;

    
    public const int MaxLevel = 16;

    
    public const float FieldPosX = 0;
    public const float FieldPosY = 0;

    
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
    LevelComplete,
}