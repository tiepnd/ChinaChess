using System.Collections.Generic;
using UnityEngine;

public class ChessManData:MonoBehaviour
{
    public bool isSeted;
    public bool isRedChess;
    public List<GameObject> listCanKill;
    public List<GameObject> listCanGo;
    public int i;
    public int j;
    public MODECHESS mODECHESS;
    private void Start()
    {
        listCanKill = new List<GameObject>();
        listCanGo = new List<GameObject>();
    }

    public void resetData()
    {
        isSeted = false;
        isRedChess = false;
        mODECHESS = MODECHESS.None;
    }
    public void updateData(ChessManData chessFirst)
    {
        isSeted = true;
        isRedChess = chessFirst.isRedChess;
        mODECHESS = chessFirst.mODECHESS;
    }
}