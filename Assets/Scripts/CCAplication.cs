using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCAplication : MonoBehaviour
{
    public CCModel model;
    public CCView view;
    public CCController controller;
    public GameObject [,] listChessMans;
    public GameObject instanceChessMan;
    public GameModel model1;
    public GameObject chessMans;
    void Start()
    {
        listChessMans = new GameObject[10, 9];
        initBoard();
    }

    private void initBoard()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                GameObject g = Instantiate(instanceChessMan, new Vector3(-4+j, 4.5f-i), Quaternion.identity);
                g.transform.SetParent(chessMans.transform);
                g.name = "ChessMan" + i +"," + j;
                listChessMans[i,j] = g;
                listChessMans[i, j].AddComponent<ChessManData>();
                listChessMans[i, j].GetComponent<ChessMan>().app = gameObject.GetComponent<CCAplication>();
                ChessManData chess = listChessMans[i,j].GetComponent<ChessManData>();
                chess.i = i;
                chess.j = j;
                chess.mODECHESS = MODECHESS.None;
            }
        }
        foreach (var item in model1.gameModelDatas)
        {
            listChessMans[item.i,item.j].GetComponent<SpriteRenderer>().sprite = item.sprite;

            listChessMans[item.i,item.j].GetComponent<ChessManData>().isSeted = true;

            listChessMans[item.i, item.j].GetComponent<ChessManData>().mODECHESS = item.mODECHESS;

            listChessMans[item.i, item.j].GetComponent<ChessManData>().isRedChess = item.isRedChessData;
        }
    }
}
