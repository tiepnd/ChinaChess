using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCModel : MonoBehaviour
{
    public ChessManData checssManData;
    public GameModel gameModel;
    public bool isRedTurn;
    public bool isFirstClick;
    public UiModel uiModel;
    private void Awake()
    {
        isFirstClick = true;
        isRedTurn = true;
    }
}
