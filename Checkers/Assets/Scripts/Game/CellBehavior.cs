using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CellBehavior : MonoBehaviour, IPointerClickHandler
{
    public CheckerColor checkerColor = CheckerColor.None;
    [SerializeField] Image checkerImage;
    [SerializeField] Image crownImage;
    public Image CheckerImage => checkerImage;
    GameManager gameManager;
    public int x, y;
    bool isKing;
    Image currentImage;
    Color defColor;
    public bool IsKing => isKing;
    void Start()
    {
        gameManager = GameManager.Instance;
        currentImage = GetComponent<Image>();
        defColor = currentImage.color;
    }


    public void SetActive(bool state)
    {
        if (state)
            currentImage.color = Color.yellow;
        else
            currentImage.color = defColor;
    }
    public void SetFigure(CheckerColor color, Sprite checker, bool isKing = false)
    {
        if (color == CheckerColor.None)
            return;
        else
            if(color == CheckerColor.White || color == CheckerColor.Black)
        {
            if (isKing)
                SetKing();
            checkerImage.sprite = checker;
            CheckerImage.color = Color.white;
            checkerColor = color;  
        }
    }
    public void SetFigure(CellBehavior cell)
    {
        isKing = cell.isKing;
        if (isKing)
            crownImage.color = Color.white;
        checkerImage.sprite = cell.checkerImage.sprite;
        checkerImage.color = Color.white;
        checkerColor = cell.checkerColor;
        
    }
    public void SetKing()
    {
        crownImage.color = Color.white;
        isKing = true;
    }
    public void UnSetFigure()
    {
        checkerColor = CheckerColor.None;
        checkerImage.sprite = null;
        crownImage.color = Color.clear;
        SetActive(false);
        checkerImage.color = Color.clear;
        if (isKing == true)
            isKing = false;
    }
    void OnClick()
    {
        if (gameManager.IsSelected)
        {
            if (checkerColor == CheckerColor.None)
                gameManager.Move(this);
            else
            {
                if (checkerColor == gameManager.CurrentPlayer && !gameManager.WaitForBeat)
                    gameManager.Select(this);
            }
        }
        else
        {
            if (checkerColor == gameManager.CurrentPlayer)
                gameManager.Select(this);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnClick();
        }
    }
}
public enum CheckerColor
{
    None,
    Black,
    White
}