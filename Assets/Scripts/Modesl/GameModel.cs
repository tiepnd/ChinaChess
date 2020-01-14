using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameModel", menuName = "CreateGameModel", order = 2)]
public class GameModel:ScriptableObject
{
    public List<GameModelData> gameModelDatas;
}
[System.Serializable]
public class GameModelData
{
    public int i;
    public int j;
    public Sprite sprite;
    public MODECHESS mODECHESS;
    public bool isRedChessData;
}
public enum MODECHESS
{
    Xe,
    Phao,
    Ma,
    Tuong,
    Si,
    Tinh,
    Tot,
    None
}