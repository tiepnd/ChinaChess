using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// loi phan gameobject.
/// </summary>
public class CCController : CCElement
{
    GameObject firstGO;
    List<GameObject> kills;
    List<GameObject> gos;
    Tween scaleTwen;
    public void OnFirstClickChessMan(GameObject firstGameObject)
    {
        firstGO = firstGameObject;
        DisplayCanGo(firstGO);
    }

    public void OnSecondClickChessMan(GameObject gameObjectSecond)
    {
        CheckKill(gameObjectSecond);
        CheckGo(gameObjectSecond);
        foreach (var item in firstGO.GetComponent<ChessManData>().listCanGo)
        {
            item.transform.GetChild(0).gameObject.SetActive(false);
        }
        foreach (var item in firstGO.GetComponent<ChessManData>().listCanKill)
        {
            item.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnXe(GameObject firstGO)
    {
       GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        bool tempIsRed = chess.isRedChess;
        chess.listCanKill.Clear();
        chess.listCanGo.Clear();
        kills = chess.listCanKill;
        gos = chess.listCanGo;
    
        for (int j=jj+1 ; j < 9; j++)
        {
            if (l[ii, j].GetComponent<ChessManData>().isSeted)
            {
                if (l[ii, j].GetComponent<ChessManData>().isRedChess != tempIsRed)
                    kills.Add(l[ii, j]);
                break;
            }
            gos.Add(l[ii, j]);
        }
        for (int j = jj - 1 ; j >= 0; j--)
        {
            if (l[ii, j].GetComponent<ChessManData>().isSeted)
            {
                if (l[ii, j].GetComponent<ChessManData>().isRedChess != tempIsRed)
                    kills.Add(l[ii, j]);
                break;
            }
            
            gos.Add(l[ii,j]);
        }

        for (int i = ii+1; i < 10; i++)
        {

            if (l[i, jj].GetComponent<ChessManData>().isSeted)
            {
                if (l[i, jj].GetComponent<ChessManData>().isRedChess != tempIsRed)
                    kills.Add(l[i, jj]);
                break;
            }
            gos.Add(l[i,jj]);
        }
        for (int i = ii - 1; i >= 0; i--)
        {

            if (l[i, jj].GetComponent<ChessManData>().isSeted)
            {
                if (l[i, jj].GetComponent<ChessManData>().isRedChess != tempIsRed)
                    kills.Add(l[i, jj]);
                break;
            }

            gos.Add(l[i,jj]);
        }
    }

    private void OnTot(GameObject firstGO)
    {
        GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        bool tempIsRed = chess.isRedChess;
        chess.listCanKill.Clear();
        chess.listCanGo.Clear();
        kills = chess.listCanKill;
        gos = chess.listCanGo;
        if (firstGO.GetComponent<ChessManData>().isRedChess)
        {
            if (ii >= 5)
            {
                if (l[ii - 1, jj].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 1, jj]);
                }
                else
                {
                    if (l[ii - 1, jj].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 1, jj]);
                    }
                }
            }
            else
            {
                if (ii - 1 >= 0)
                {
                    if (l[ii - 1, jj].GetComponent<ChessManData>().isSeted == false)
                    {
                        gos.Add(l[ii - 1, jj]);
                    }
                    else
                    {
                        if (l[ii - 1, jj].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                        {
                            kills.Add(l[ii - 1, jj]);
                        }
                    }

                }
                if (jj - 1 >= 0)
                {
                    if (l[ii, jj - 1].GetComponent<ChessManData>().isSeted == false)
                    {
                        gos.Add(l[ii, jj - 1]);
                    }
                    else
                    {
                        if (l[ii, jj - 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                        {
                            kills.Add(l[ii, jj - 1]);
                        }
                    }

                }
                if (jj + 1 <= 8)
                {
                    if (l[ii, jj + 1].GetComponent<ChessManData>().isSeted == false)
                    {
                        gos.Add(l[ii, jj + 1]);
                    }
                    else
                    {
                        if (l[ii, jj + 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                        {
                            kills.Add(l[ii, jj + 1]);
                        }
                    }

                }
            }
        }
        else
        {
            if (ii <= 4)
            {
                if (l[ii + 1, jj].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 1, jj]);
                }
                else
                {
                    if (l[ii + 1, jj].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 1, jj]);
                    }
                }
            }
            else
            {
                if (ii + 1 <= 9)
                {
                    if (l[ii + 1, jj].GetComponent<ChessManData>().isSeted == false)
                    {
                        gos.Add(l[ii + 1, jj]);
                    }
                    else
                    {
                        if (l[ii + 1, jj].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                        {
                            kills.Add(l[ii + 1, jj]);
                        }
                    }

                }
                if (jj - 1 >= 0)
                {
                    if (l[ii, jj - 1].GetComponent<ChessManData>().isSeted == false)
                    {
                        gos.Add(l[ii, jj - 1]);
                    }
                    else
                    {
                        if (l[ii, jj - 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                        {
                            kills.Add(l[ii, jj - 1]);
                        }
                    }

                }
                if (jj + 1 <= 8)
                {
                    if (l[ii, jj + 1].GetComponent<ChessManData>().isSeted == false)
                    {
                        gos.Add(l[ii, jj + 1]);
                    }
                    else
                    {
                        if (l[ii, jj + 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                        {
                            kills.Add(l[ii, jj + 1]);
                        }
                    }

                }
            }
        }
    }

    private void OnPhao(GameObject firstGO)
    {
        GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        bool tempIsRed = chess.isRedChess;
        chess.listCanKill.Clear();
        chess.listCanGo.Clear();
        kills = chess.listCanKill;
        gos = chess.listCanGo;
        for (int j = jj + 1; j < 9; j++)
        {
            if (l[ii, j].GetComponent<ChessManData>().isSeted)
            {
                    for(int j1 = j + 1; j1 < 9; j1++)
                    {
                        if(l[ii, j1].GetComponent<ChessManData>().isSeted && l[ii, j1].GetComponent<ChessManData>().isRedChess != tempIsRed)
                        {
                            kills.Add(l[ii, j1]);
                            break;
                        }
                        
                    }
                    
                break;
            }
            gos.Add(l[ii, j]);
        }
        for (int j = jj - 1; j >= 0; j--)
        {
            if (l[ii, j].GetComponent<ChessManData>().isSeted)
            {
                    for (int j1 = j -1 ; j1 >=0; j1--)
                    {
                        if (l[ii, j1].GetComponent<ChessManData>().isSeted && l[ii, j1].GetComponent<ChessManData>().isRedChess != tempIsRed)
                        {
                            kills.Add(l[ii, j1]);
                            break;
                        }

                    }
                break;
            }
            gos.Add(l[ii, j]);
        }
        for (int i = ii + 1; i < 10; i++)
        {
            if (l[i, jj].GetComponent<ChessManData>().isSeted)
            {
                    for (int i1 = i + 1; i1 < 10; i1++)
                    {
                        if (l[i1, jj].GetComponent<ChessManData>().isSeted&&l[i1, jj].GetComponent<ChessManData>().isRedChess != tempIsRed)
                        {
                            kills.Add(l[i1, jj]);
                            break;
                        }

                    }
                break;
            }
            gos.Add(l[i, jj]);
        }
        for (int i = ii - 1; i >= 0; i--)
        {
            if (l[i, jj].GetComponent<ChessManData>().isSeted)
            {
                    for (int i1 = i - 1; i1 >= 0; i1--)
                    {
                        if (l[i1, jj].GetComponent<ChessManData>().isSeted && l[i1, jj].GetComponent<ChessManData>().isRedChess != tempIsRed)
                        {
                            kills.Add(l[i1, jj]);
                            break;
                        }
                    }
                break;
            }

            gos.Add(l[i, jj]);
        }
    }

    private void OnMa(GameObject firstGO)
    {
        GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        bool tempIsRed = chess.isRedChess;
        chess.listCanKill.Clear();
        chess.listCanGo.Clear();
        kills = chess.listCanKill;
        gos = chess.listCanGo;
        //     List<GameObject> listNearMas = new List<GameObject>(){ l[ii + 1, jj], l[ii - 1, jj] , l[ii, jj+1] , l[ii, jj-1] };
        if (ii + 1<=9&&l[ii + 1, jj].GetComponent<ChessManData>().isSeted==false)
        {
            if (ii + 2 <= 9 && jj + 1 <= 8)
            {
                ChessManData c = l[ii + 2, jj + 1].GetComponent<ChessManData>();
                if (c.isSeted)
                {
                    if (c.isRedChess != firstGO.GetComponent<ChessManData>().isRedChess) kills.Add(l[ii + 2, jj + 1]);
                }
                else
                {
                    gos.Add(l[ii + 2, jj + 1]);
                }
            }
            if (ii + 2 <= 9 && jj - 1 >= 0)
            {
                if (jj - 1 < 0) return;
                ChessManData c = l[ii + 2, jj - 1].GetComponent<ChessManData>();
                if (c.isSeted)
                {
                    if (c.isRedChess != firstGO.GetComponent<ChessManData>().isRedChess) kills.Add(l[ii + 2, jj - 1]);
                }
                else
                {
                    gos.Add(l[ii + 2, jj - 1]);
                }
            }



        }
        if (ii - 1>=0&&l[ii - 1, jj].GetComponent<ChessManData>().isSeted==false)
        {
            if (ii - 2 >= 0 && jj + 1 <= 8)
            {
                ChessManData c = l[ii - 2, jj + 1].GetComponent<ChessManData>();
                if (c.isSeted)
                {
                    if (c.isRedChess != firstGO.GetComponent<ChessManData>().isRedChess) kills.Add(l[ii - 2, jj + 1]);
                }
                else
                {
                    gos.Add(l[ii - 2, jj + 1]);
                }
            }

            if (ii - 2 >= 0&& jj - 1 >= 0)
            {
                ChessManData c = l[ii - 2, jj - 1].GetComponent<ChessManData>();
                if (c.isSeted)
                {
                    if (c.isRedChess != firstGO.GetComponent<ChessManData>().isRedChess) kills.Add(l[ii - 2, jj - 1]);
                }
                else
                {
                    gos.Add(l[ii - 2, jj - 1]);
                }
            }

        }
        if (jj + 1<=8&&l[ii , jj+1].GetComponent<ChessManData>().isSeted==false)
        {
            if (ii - 1 >= 0 && jj + 2 <= 8)
            {
                ChessManData c = l[ii - 1, jj + 2].GetComponent<ChessManData>();
                if (c.isSeted)
                {
                    if (c.isRedChess != firstGO.GetComponent<ChessManData>().isRedChess) kills.Add(l[ii - 1, jj + 2]);
                }
                else
                {
                    gos.Add(l[ii - 1, jj + 2]);
                }
            }
            if(jj+2<=8 && ii + 1 <= 8)
            {
                ChessManData c = l[ii + 1, jj + 2].GetComponent<ChessManData>();
                if (c.isSeted)
                {
                    if (c.isRedChess != firstGO.GetComponent<ChessManData>().isRedChess) kills.Add(l[ii + 1, jj + 2]);
                }
                else
                {
                    gos.Add(l[ii + 1, jj + 2]);
                }

            }

        }
        if (jj - 1>=0&&l[ii, jj - 1].GetComponent<ChessManData>().isSeted==false)
        {
            if (ii - 1 >= 0 && jj - 2 >= 0)
            {
                ChessManData c = l[ii - 1, jj - 2].GetComponent<ChessManData>();
                if (c.isSeted)
                {
                    if (c.isRedChess != firstGO.GetComponent<ChessManData>().isRedChess) kills.Add(l[ii - 1, jj - 2]);
                }
                else
                {
                    gos.Add(l[ii - 1, jj - 2]);
                }
            }
            if(jj - 2 >=0 && ii + 1 <= 8)
            {
                ChessManData c = l[ii + 1, jj - 2].GetComponent<ChessManData>();
                if (c.isSeted)
                {
                    if (c.isRedChess != firstGO.GetComponent<ChessManData>().isRedChess) kills.Add(l[ii + 1, jj - 2]);
                }
                else
                {
                    gos.Add(l[ii + 1, jj - 2]);
                }
            }

        }
    }

    private void OnTuong(GameObject firstGO)
    {
        GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        bool tempIsRed = chess.isRedChess;
        chess.listCanKill.Clear();
        chess.listCanGo.Clear();
        kills = chess.listCanKill;
        gos = chess.listCanGo;
        if (firstGO.GetComponent<ChessManData>().isRedChess)
        {
            if (ii + 1 <= 9)
            {
                if (l[ii + 1, jj].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 1, jj]);
                }
                else
                {
                    if (l[ii + 1, jj].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 1, jj]);
                    }
                }

            }
            if (ii - 1 >= 7)
            {
                if (l[ii - 1, jj].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 1, jj]);
                }
                else
                {
                    if (l[ii - 1, jj].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 1, jj]);
                    }
                }

            }
            if (jj - 1 >= 3)
            {
                if (l[ii, jj - 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii, jj - 1]);
                }
                else
                {
                    if (l[ii, jj - 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii, jj - 1]);
                    }
                }

            }
            if (jj + 1 <= 5)
            {
                if (l[ii, jj + 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii, jj + 1]);
                }
                else
                {
                    if (l[ii, jj + 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii, jj + 1]);
                    }
                }

            }
        }
        else
        {
            if (ii + 1 <= 2)
            {
                if (l[ii + 1, jj].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 1, jj]);
                }
                else
                {
                    if (l[ii + 1, jj].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 1, jj]);
                    }
                }

            }
            if (ii - 1 >= 0)
            {
                if (l[ii - 1, jj].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 1, jj]);
                }
                else
                {
                    if (l[ii - 1, jj].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 1, jj]);
                    }
                }

            }
            if (jj - 1 >= 3)
            {
                if (l[ii, jj - 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii, jj - 1]);
                }
                else
                {
                    if (l[ii, jj - 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii, jj - 1]);
                    }
                }

            }
            if (jj + 1 <= 5)
            {
                if (l[ii, jj + 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii, jj + 1]);
                }
                else
                {
                    if (l[ii, jj + 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii, jj + 1]);
                    }
                }

            }
        }
    }

    private void OnSi(GameObject firstGO)
    {
        GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        bool tempIsRed = chess.isRedChess;
        chess.listCanKill.Clear();
        chess.listCanGo.Clear();
        kills = chess.listCanKill;
        gos = chess.listCanGo;
        if (chess.isRedChess)
        {
            if (ii + 1 <= 9 && jj + 1 <= 5)
            {
                if (l[ii + 1, jj + 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 1, jj + 1]);
                }
                else
                {
                    if (l[ii + 1, jj + 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 1, jj + 1]);
                    }
                }
            }
            if (ii + 1 <= 9 && jj - 1 >= 3)
            {
                if (l[ii + 1, jj - 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 1, jj - 1]);
                }
                else
                {
                    if (l[ii + 1, jj - 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 1, jj - 1]);
                    }
                }
            }
            if (ii - 1 >= 7 && jj + 1 <= 5)
            {
                if (l[ii - 1, jj + 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 1, jj + 1]);
                }
                else
                {
                    if (l[ii - 1, jj + 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 1, jj + 1]);
                    }
                }
            }
            if (ii - 1 >= 7 && jj - 1 >= 3)
            {
                if (l[ii - 1, jj - 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 1, jj - 1]);
                }
                else
                {
                    if (l[ii - 1, jj - 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 1, jj - 1]);
                    }
                }
            }
        }
        else
        {
            if (ii + 1 <= 2 && jj + 1 <= 5)
            {
                if (l[ii + 1, jj + 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 1, jj + 1]);
                }
                else
                {
                    if (l[ii + 1, jj + 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 1, jj + 1]);
                    }
                }
            }
            if (ii + 1 <= 2 && jj - 1 >= 3)
            {
                if (l[ii + 1, jj - 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 1, jj - 1]);
                }
                else
                {
                    if (l[ii + 1, jj - 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 1, jj - 1]);
                    }
                }
            }
            if (ii - 1 >= 0 && jj + 1 <= 5)
            {
                if (l[ii - 1, jj + 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 1, jj + 1]);
                }
                else
                {
                    if (l[ii - 1, jj + 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 1, jj + 1]);
                    }
                }
            }
            if (ii - 1 >= 0 && jj - 1 >= 3)
            {
                if (l[ii - 1, jj - 1].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 1, jj - 1]);
                }
                else
                {
                    if (l[ii - 1, jj - 1].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 1, jj - 1]);
                    }
                }
            }
        }

    }

    private void OnTinh(GameObject firstGO)
    {
        GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        bool tempIsRed = chess.isRedChess;
        chess.listCanKill.Clear();
        chess.listCanGo.Clear();
        kills = chess.listCanKill;
        gos = chess.listCanGo;
        if (chess.isRedChess)
        {
            if (ii + 2 <= 9 && jj + 2 <= 8)
            {
                if (l[ii + 2, jj + 2].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 2, jj + 2]);
                }
                else
                {
                    if (l[ii + 2, jj + 2].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 2, jj + 2]);
                    }
                }
            }
            if (ii + 2 <= 9 && jj - 2 >= 0)
            {
                if (l[ii + 2, jj - 2].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 2, jj - 2]);
                }
                else
                {
                    if (l[ii + 2, jj - 2].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 2, jj - 2]);
                    }
                }
            }
            if (ii - 2 >= 5 && jj + 2 <= 9)
            {
                if (l[ii - 2, jj + 2].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 2, jj + 2]);
                }
                else
                {
                    if (l[ii - 2, jj + 2].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 2, jj + 2]);
                    }
                }
            }
            if (ii - 2 >= 5 && jj - 2 >= 0)
            {
                if (l[ii - 2, jj - 2].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 2, jj - 2]);
                }
                else
                {
                    if (l[ii - 2, jj - 2].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 2, jj - 2]);
                    }
                }
            }
        }
        else
        {
            if (ii + 2 <= 4 && jj + 2 <= 8)
            {
                if (l[ii + 2, jj + 2].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 2, jj + 2]);
                }
                else
                {
                    if (l[ii + 2, jj + 2].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 2, jj + 2]);
                    }
                }
            }
            if (ii + 2 <= 4 && jj - 2 >= 0)
            {
                if (l[ii + 2, jj - 2].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii + 2, jj - 2]);
                }
                else
                {
                    if (l[ii + 2, jj - 2].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii + 2, jj - 2]);
                    }
                }
            }
            if (ii - 2 >= 0 && jj + 2 <= 8)
            {
                if (l[ii - 2, jj + 2].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 2, jj + 2]);
                }
                else
                {
                    if (l[ii - 2, jj + 2].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 2, jj + 2]);
                    }
                }
            }
            if (ii - 2 >= 0 && jj - 2 >= 0)
            {
                if (l[ii - 2, jj - 2].GetComponent<ChessManData>().isSeted == false)
                {
                    gos.Add(l[ii - 2, jj - 2]);
                }
                else
                {
                    if (l[ii - 2, jj - 2].GetComponent<ChessManData>().isRedChess != firstGO.GetComponent<ChessManData>().isRedChess)
                    {
                        kills.Add(l[ii - 2, jj - 2]);
                    }
                }
            }
        }
    }

    private void DisplayCanGo(GameObject firstGO)
    {
        switch (firstGO.GetComponent<ChessManData>().mODECHESS)
        {
            case MODECHESS.Xe:
                {
                    OnXe(firstGO);
                    break;
                }
            case MODECHESS.Phao:
                {
                    OnPhao(firstGO);
                    break;
                }
            case MODECHESS.Ma:
                {
                    OnMa(firstGO);
                    break;
                }
            case MODECHESS.Tuong:
                {
                    OnTuong(firstGO);
                    break;
                }
            case MODECHESS.Si:
                {
                    OnSi(firstGO);
                    break;
                }
            case MODECHESS.Tinh:
                {
                    OnTinh(firstGO);
                    break;
                }
            case MODECHESS.Tot:
                {
                    OnTot(firstGO);
                    break;
                }
        }
        displayKillAndGo();
    }

    private void displayKillAndGo()
    {
        foreach (var item in gos)
        {
            item.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            item.transform.GetChild(0).gameObject.SetActive(true);
        }
        foreach (var item in kills)
        {
            item.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            item.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void CheckKillKing(GameObject gameObjectSecond)
    {
        switch (gameObjectSecond.GetComponent<ChessManData>().mODECHESS)
        {
            case MODECHESS.Xe:
                {
                    OnXe(gameObjectSecond);
                    break;
                }
            case MODECHESS.Phao:
                {
                    OnPhao(gameObjectSecond);
                    break;
                }
            case MODECHESS.Ma:
                {
                    OnMa(gameObjectSecond);
                    break;
                }
            case MODECHESS.Tuong:
                {
                    OnTuong(gameObjectSecond);
                    break;
                }
            case MODECHESS.Si:
                {
                    OnSi(gameObjectSecond);
                    break;
                }
            case MODECHESS.Tinh:
                {
                    OnTinh(gameObjectSecond);
                    break;
                }
            case MODECHESS.Tot:
                {
                    OnTot(gameObjectSecond);
                    break;
                }
        }
        foreach (var item in kills)
        {
            if (item.GetComponent<ChessManData>().mODECHESS == MODECHESS.Tuong)
            {
                app.model.uiModel.imgChieuTuong.gameObject.SetActive(true);
                scaleTwen = app.model.uiModel.imgChieuTuong.transform.DOScale(new Vector3(0.25f, .25f, .25f), 1);
                scaleTwen.OnComplete(() => { app.model.uiModel.imgChieuTuong.gameObject.SetActive(false); });   
            }
        }
    }

    private void CheckKill(GameObject gameObjectSecond)
    {
        if (firstGO.GetComponent<ChessManData>().listCanKill.Contains(gameObjectSecond))
        {
            gameObjectSecond.GetComponent<SpriteRenderer>().sprite = firstGO.GetComponent<SpriteRenderer>().sprite;
            firstGO.GetComponent<SpriteRenderer>().sprite = null;
            gameObjectSecond.GetComponent<ChessManData>().updateData(firstGO.GetComponent<ChessManData>());
            firstGO.GetComponent<ChessManData>().resetData();
            CheckKillKing(gameObjectSecond);
            app.model.isRedTurn = !app.model.isRedTurn;
            CheckKillKingWhenKill(gameObjectSecond);
        }

    }

    private void CheckKillKingWhenKill(GameObject gameObjectSecond)
    {
        GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        for (int i=ii+1; i <= 9; i++)       
        {
            if (l[i,jj].GetComponent<ChessManData>().mODECHESS == MODECHESS.Phao)
            {
                CheckKillKing( l[i, jj]) ;
                break;
            }
        }
        for (int j = jj + 1; j<= 8; j++)
        {
            if (l[ii, j].GetComponent<ChessManData>().mODECHESS == MODECHESS.Phao)
            {
                CheckKillKing(l[ii, jj]);
                break;
            }
        }
        for (int j = jj - 1; j >=0; j--)
        {
            if (l[ii, j].GetComponent<ChessManData>().mODECHESS == MODECHESS.Phao)
            {
                CheckKillKing(l[ii, j]);
                break;
            }
        }
    }

    private void CheckGo(GameObject gameObjectSecond)
    {
        if (firstGO.GetComponent<ChessManData>().listCanGo.Contains(gameObjectSecond))
        {
            gameObjectSecond.GetComponent<SpriteRenderer>().sprite = firstGO.GetComponent<SpriteRenderer>().sprite;
            firstGO.GetComponent<SpriteRenderer>().sprite = null;
            gameObjectSecond.GetComponent<ChessManData>().updateData(firstGO.GetComponent<ChessManData>());
            firstGO.GetComponent<ChessManData>().resetData();
            CheckKillKing(gameObjectSecond);
            app.model.isRedTurn = !app.model.isRedTurn;
            CheckKillKingWhenGo(firstGO);
            CheckKillKingWhenGo(gameObjectSecond);
        }
    }

    private void CheckKillKingWhenGo(GameObject firstGO)
    {
        GameObject[,] l = app.listChessMans;
        ChessManData chess = firstGO.GetComponent<ChessManData>();
        int ii = chess.i;
        int jj = chess.j;
        for (int i = ii + 1; i <= 9; i++)
        {
            if (l[i, jj].GetComponent<ChessManData>().mODECHESS == MODECHESS.Phao || l[i, jj].GetComponent<ChessManData>().mODECHESS == MODECHESS.Xe)
            {
                CheckKillKing(l[i, jj]);
                break;
            }
        }
        for (int j = jj + 1; j <= 8; j++)
        {
            if (l[ii, j].GetComponent<ChessManData>().mODECHESS == MODECHESS.Phao|| l[ii, j].GetComponent<ChessManData>().mODECHESS == MODECHESS.Xe)
            {
                CheckKillKing(l[ii, j]);
                break;
            }
        }
        for (int j = jj - 1; j >= 0; j--)
        {
            if (l[ii, j].GetComponent<ChessManData>().mODECHESS == MODECHESS.Phao|| l[ii, j].GetComponent<ChessManData>().mODECHESS == MODECHESS.Xe)
            {
                CheckKillKing(l[ii, j]);
                break;
            }
        }
    }

}
