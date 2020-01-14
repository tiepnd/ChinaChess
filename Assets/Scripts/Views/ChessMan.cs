using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessMan : CCElement

{
    private void OnMouseDown()
    {
    //    if ()&& gameObject.GetComponent<ChessManData>().isSeted==true) return;
        if (app.model.isFirstClick&& gameObject.GetComponent<ChessManData>().isRedChess == app.model.isRedTurn&& gameObject.GetComponent<ChessManData>().isSeted == true)
        {
            if (gameObject.GetComponent<ChessManData>().isSeted)
            {
                app.model.isFirstClick = false;
                app.controller.OnFirstClickChessMan(gameObject);
            }
        }
        else
        {
            if (app.model.isFirstClick == false)
            {
                app.model.isFirstClick = true;
                app.controller.OnSecondClickChessMan(gameObject);
            }
            
        }
    }
}
