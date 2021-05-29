using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int height = 8, width = 8;

    [SerializeField] GameObject gameField;
    [SerializeField] Sprite BlackFigure;
    [SerializeField] Sprite WhiteFigure;
    [SerializeField] UIManager UIManager;

    public static GameManager Instance;
    public bool IsSelected;
    CellBehavior[] Cells;
    List<CellBehavior> directionCells;
    public CellBehavior[] GetCells => Cells;
    string player1, player2;
    CellBehavior currentCell;
    CheckerColor currentPlayer;
    public CheckerColor CurrentPlayer => currentPlayer;
    bool waitForBeat;
    public bool WaitForBeat => waitForBeat;
    CheckerColor oponentColor => currentPlayer == CheckerColor.Black ? CheckerColor.White : CheckerColor.Black;
    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        Cells = gameField.GetComponentsInChildren<CellBehavior>();
        LoadGame();
        IsSelected = false;
        currentCell = null;
        directionCells = new List<CellBehavior>();
    }
    void SetFigures()
    {
        int it = 0;
        int d;
        for (int i = 0; i < height; i++)
        {
            d = (i + 1) % 2;
            for (int j = d; j < width; j += 2)
            {
                if (i < 2)
                {
                    Cells[it].SetFigure(CheckerColor.White, WhiteFigure);
                }
                else
                    if (i > 5)
                    Cells[it].SetFigure(CheckerColor.Black, BlackFigure);
                Cells[it].x = j;
                Cells[it].y = i;
                it++;
            }
        }
        currentPlayer = CheckerColor.Black;
    }
    void SetFigures(Saver s)
    {
        ChessInfo[] info = s.arr;
        for (int i = 0; i < info.Length; i++)
        {
            Cells[i].x = info[i].x;
            Cells[i].y = info[i].y;
            if (info[i].color != CheckerColor.None)
                Cells[i].SetFigure(info[i].color, info[i].color == CheckerColor.Black ? BlackFigure : WhiteFigure, info[i].isKing);   
        }
        currentPlayer = s.currentPlayer;

    }
    void ClearDirections()
    {
        foreach (var item in directionCells)
        {
            item.SetActive(false);
        }
        directionCells.Clear();
    }
    public void Select(CellBehavior selectedCell)
    {
        if (selectedCell.checkerColor == currentPlayer)
        {
            if (currentCell != null)
            {
                currentCell.SetActive(false);
            }
            ClearDirections();
            currentCell = selectedCell;
            currentCell.SetActive(true);
            SelectMoveDirection();
            IsSelected = true;
        }
    }
    void ChangePlayer() 
    {
        UnSelect();
        currentPlayer = currentPlayer == CheckerColor.Black ? CheckerColor.White : CheckerColor.Black;
        ClearDirections();
    }

    public void OnSkip()
    {
        if (currentCell != null)
            currentCell.SetActive(false);
        ChangePlayer();
    }
    void UnSelect()
    {
        IsSelected = false;
        waitForBeat = false;
        currentCell = null;
    }
    public void CheckOnKing(CellBehavior cell)
    {
        if (cell.y == 0 && cell.checkerColor == CheckerColor.Black)
            cell.SetKing();//Set king
        else
            if (cell.y == 7 && cell.checkerColor == CheckerColor.White)
            cell.SetKing();
    }
    bool CanBeat(CellBehavior currentCell, CellBehavior targetCell, CheckerColor oponentColor)
    {
        int vx, vy;
        vx = (targetCell.x - currentCell.x) / Mathf.Abs(targetCell.x - currentCell.x);
        vy = (targetCell.y - currentCell.y) / Mathf.Abs(targetCell.y - currentCell.y);
        int x = currentCell.x + vx;
        int y = currentCell.y + vy;
        CellBehavior c;
        while (x != targetCell.x && y != targetCell.y)
        {
        
            c = Cells.FirstOrDefault(ob => ob.x == x && ob.y == y);
            if (c.checkerColor == currentCell.checkerColor)
                return false;
            if (c.checkerColor == oponentColor)
            {
                x = x + vx;
                y = y + vy;
                c = Cells.FirstOrDefault(ob => ob.x == x && ob.y == y);
                if (c.checkerColor == CheckerColor.None)
                    return true;
            }
            x = x + vx;
            y = y + vy;
           
        }
        return false;
    }
   public bool TryToBeat(CellBehavior targetCell)
    {
        bool res = false;
        int vx, vy;
        vx = (targetCell.x - currentCell.x) / Mathf.Abs(targetCell.x - currentCell.x);
        vy = (targetCell.y - currentCell.y) / Mathf.Abs(targetCell.y - currentCell.y);
        int x = currentCell.x + vx;
        int y = currentCell.y + vy;
        while(x != targetCell.x && y != targetCell.y)
        {
            CellBehavior c =  Cells.FirstOrDefault(ob => ob.x == x && ob.y == y);
            if (c.checkerColor == oponentColor)
            {
                c.UnSetFigure();
                UIManager.ReduceCount(oponentColor);
                return true;
            }
            x = x + vx;
            y = y + vy;
        }
        return res;
    }
    bool IsChessBlocked(CellBehavior Chess)
    {
        
        if (!Chess.IsKing)
        {
            int vy = Chess.checkerColor == CheckerColor.Black ? -1 : 1;
                CellBehavior cell1 = Cells.FirstOrDefault(o => o.x == Chess.x + 1 && o.y == Chess.y + vy);
                CellBehavior cell2 = Cells.FirstOrDefault(o => o.x == Chess.x - 1 && o.y == Chess.y +vy);
            if (!CanBeat(Chess,GetOponentColor(Chess.checkerColor)) 
                && !CanChessMove(Chess, cell1) && !CanChessMove(Chess, cell2))
                    return true;
                return false;
        }
        else
        {
            CellBehavior cell1 = Cells.FirstOrDefault(o => o.x == Chess.x + 1 && o.y == Chess.y + 1);
            CellBehavior cell2 = Cells.FirstOrDefault(o => o.x == Chess.x - 1 && o.y == Chess.y + 1);
            CellBehavior cell3 = Cells.FirstOrDefault(o => o.x == Chess.x + 1 && o.y == Chess.y -1);
            CellBehavior cell4 = Cells.FirstOrDefault(o => o.x == Chess.x - 1 && o.y == Chess.y -1);
            if (!CanBeat(Chess, Chess.checkerColor == CheckerColor.Black ? CheckerColor.White : CheckerColor.Black) 
                && !CanChessMove(Chess, cell1) && !CanChessMove(Chess, cell2) &&
                !CanChessMove(Chess, cell3) && !CanChessMove(Chess, cell4))
                return true;
            return false;
        }
    }

    bool CanChessMove(CellBehavior currentCell, CellBehavior targetCell)
    {
        bool wfb = currentCell.checkerColor == currentPlayer && waitForBeat ? true : false;
        if (currentCell == null || targetCell == null)
            return false;
        if (currentCell.IsKing)
        {
            if (targetCell == null)
                return false;
            if (Mathf.Abs(targetCell.x - currentCell.x) != Mathf.Abs(targetCell.y - currentCell.y))
                return false;
            int vx, vy;
            vx = (targetCell.x - currentCell.x) / Mathf.Abs(targetCell.x - currentCell.x);
            vy = (targetCell.y - currentCell.y) / Mathf.Abs(targetCell.y - currentCell.y);
            int x = currentCell.x + vx;
            int y = currentCell.y + vy;

            if (targetCell.checkerColor != CheckerColor.None)
                return false;

            while (x != targetCell.x && y != targetCell.y)
            {
                CellBehavior cell = Cells.FirstOrDefault(ob => ob.x == x && ob.y == y);
                if (cell.checkerColor == currentPlayer)
                    return false;
                else
                    if (cell.checkerColor == oponentColor)
                {
                    x += vx;
                    y += vy;
                    while (x != targetCell.x && y != targetCell.y)
                    {
                        cell = Cells.FirstOrDefault(ob => ob.x == x && ob.y == y);
                        if (cell.checkerColor != CheckerColor.None)
                            return false;
                        x += vx;
                        y += vy;
                    }
                    return true;
                }
                x += vx;
                y += vy;
            }
            if (waitForBeat)
                return false;
            else
            return true;
        }
        else
        {
            int my = currentCell.checkerColor == CheckerColor.Black ? -1 : 1;
            if (Mathf.Abs(targetCell.x - currentCell.x) == 2 && Mathf.Abs(targetCell.y - currentCell.y) == 2)
            {
                if (CanBeat(currentCell, targetCell, GetOponentColor(currentCell.checkerColor)))
                {
                    return true;
                }
            }          
            if (Mathf.Abs(targetCell.x - currentCell.x) == 1 && targetCell.y - currentCell.y == my && targetCell.checkerColor == CheckerColor.None && !wfb)
                return true;
            return false;
                


        }
    }
    CheckerColor GetOponentColor(CheckerColor color)
    {
        return color == CheckerColor.Black ? CheckerColor.White : CheckerColor.Black;
    }
    bool checkBeat(int vx, int vy, CheckerColor oponent, CellBehavior currentCell)
    {
        if (!currentCell.IsKing)
        {
            CellBehavior cell = Cells.FirstOrDefault(x => x.x == currentCell.x + (2*vx) && x.y == currentCell.y + (2*vy));
            if (cell != null)
            {
                CellBehavior bcell = Cells.FirstOrDefault(x => x.x == currentCell.x + (1*vx) && x.y == currentCell.y + (1*vy));
                if (bcell.checkerColor == oponent && cell.checkerColor == CheckerColor.None)
                    return true;
            }
        }
        else
        {
            int x = currentCell.x + (1*vx);
            int y = currentCell.y + (1*vy);
            CellBehavior c = Cells.FirstOrDefault(o => o.x == x && o.y == y);
            while (c!= null)
            {

                if (c.checkerColor == oponent)
                {
                    x += (1 * vx);
                    y += (1 * vy);
                    c = Cells.FirstOrDefault(o => o.x == x && o.y == y);
                    if (c != null && c.checkerColor == CheckerColor.None)
                        return true;
                    else
                        return false;
                }
                else
                    if (c.checkerColor == currentPlayer)
                    return false;
                x += (1*vx);
                y += (1*vy);
                c = Cells.FirstOrDefault(o => o.x == x && o.y == y);
            }
        }
        return false;
    }
    void SetDirection(int vx, int vy)
    {
        CellBehavior cell;
        if (currentCell.IsKing) 
        {
            cell = Cells.FirstOrDefault(o => o.x == currentCell.x + vx && o.y == currentCell.y + vy);
            while (cell != null)
            {
                if (CanChessMove(currentCell, cell))
                {
                    cell.SetActive(true);
                    directionCells.Add(cell);
                }
                cell = Cells.FirstOrDefault(o => o.x == cell.x + vx && o.y == cell.y + vy);
            }
        }
        else
        {
            int x;
            int y;
            x = currentCell.x + 1 * vx;
            y = currentCell.y + 1 * vy;

            cell = Cells.FirstOrDefault(o => o.x == x && o.y == y);
            if (cell != null && CanChessMove(currentCell,cell))
            {
                cell.SetActive(true);
                directionCells.Add(cell);
                
            }
            else
                if (checkBeat(vx, vy, oponentColor, currentCell))
            {
                x = currentCell.x + 2 * vx;
                y = currentCell.y + 2 * vy;
                cell = Cells.FirstOrDefault(o => o.x == x && o.y == y);
                cell.SetActive(true);
                directionCells.Add(cell);
            }

            if (checkBeat(vx, -vy, oponentColor, currentCell))
            {
                x = currentCell.x + 2*vx;
                y = currentCell.y + 2 * -vy;
                cell = Cells.FirstOrDefault(o => o.x == x && o.y == y);
                cell.SetActive(true);
                directionCells.Add(cell);
            }

        }
    }
    void SelectMoveDirection()
    {
        ClearDirections();
        if (currentCell.IsKing)
        {
            SetDirection(1, 1);
            SetDirection(1, -1);
            SetDirection(-1, 1);
            SetDirection(-1, -1);
        }
        else
        {

            int vy = currentPlayer == CheckerColor.Black ? -1 : 1;
            SetDirection(1, vy);
            SetDirection(-1, vy);
        }

    }
    bool CanBeat(CellBehavior cell, CheckerColor oponentColor)
    {
        if (cell == null)
            return false;
        
        if (checkBeat(1, 1, oponentColor, cell) ||
            checkBeat(1, -1, oponentColor, cell) ||
            checkBeat(-1, 1, oponentColor, cell) ||
            checkBeat(-1, -1, oponentColor, cell))
            return true;
        return false;
    
    }
    void CheckBlocking()
    {
        CellBehavior[] blackCells = Cells.Where(x => x.checkerColor == CheckerColor.Black).ToArray();
        CellBehavior[] whiteCells = Cells.Where(x => x.checkerColor == CheckerColor.White).ToArray();
        int i = 0;
        while(i < blackCells.Length && IsChessBlocked(blackCells[i]))
        {
            i++;
        }
        if (i == blackCells.Length)
        {
            UIManager.SetWinner(CheckerColor.White);
            return;
        }
        i = 0;
        while (i < whiteCells.Length && IsChessBlocked(whiteCells[i]))
        {
            i++;
        }
        if(i == whiteCells.Length)
        {
            UIManager.SetWinner(CheckerColor.Black);
            return;
        }
    }
    public void Move(CellBehavior cell)
    {
        if (move(cell))
        {
           CheckBlocking();
        };

    }
    void MovePosition(CellBehavior towardCell)
    {
        towardCell.SetFigure(currentCell);
        currentCell.UnSetFigure();
        CheckOnKing(towardCell);
    }
    bool move(CellBehavior cell)
    {
            if (CanChessMove(currentCell, cell))
            {
                MovePosition(cell);
                if (TryToBeat(cell))
                {                  
                    if (CanBeat(cell, oponentColor))
                    {                  
                    waitForBeat = true;
                    Select(cell);
                    return true;
                    }                   
                }
                ChangePlayer();
                return true;
            }
        return false; 
    }
    void LoadGame()
    {
       
        player1 = PlayerPrefs.GetString("Player1");
        player2 = PlayerPrefs.GetString("Player2");
        if (PlayerPrefs.GetString("Save") == "")
        {
            SetFigures();
        }
        else
        {
            
            Saver saver = JsonUtility.FromJson<Saver>(PlayerPrefs.GetString("Save"));
            SetFigures(saver);
        }
        UIManager.LoadUI();
    }
}
