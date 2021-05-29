using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Saver
{
    public ChessInfo[] arr;

    public float time;
    public CheckerColor currentPlayer;
    public Saver(){  }
    public Saver(CellBehavior[] cells, float time, CheckerColor currentPlayer)
    {
        arr = new ChessInfo[cells.Length];
        for (int i = 0; i < cells.Length; i++) {
            arr[i] = new ChessInfo(cells[i].checkerColor, cells[i].IsKing, cells[i].x, cells[i].y);
        }

        this.time = time;
        this.currentPlayer = currentPlayer;
    }
}
[Serializable]
public class ChessInfo
{
    public CheckerColor color;
    public bool isKing;
    public int x;
    public int y;
    public ChessInfo(CheckerColor color, bool isKing, int x, int y)
    {
        this.color = color;
        this.isKing = isKing;
        this.x = x;
        this.y = y;
    }
}
