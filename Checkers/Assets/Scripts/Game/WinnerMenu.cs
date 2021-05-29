using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class WinnerMenu : MonoBehaviour
{
    [SerializeField] UIManager UIManager;
    [SerializeField] GameObject Menu;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI WColor;
    [SerializeField] TextMeshProUGUI FTime;
    void Start()
    {
        gameObject.SetActive(false);
        Menu.SetActive(false);
    }
    void SetActive(bool state)
    {
        Menu.SetActive(state);
        gameObject.SetActive(state);
        if (state)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void SetWinner(CheckerColor winner, string name, float time)
    {
        SetActive(true);
        Name.text = name + "is winner!";
        if (winner == CheckerColor.Black)
            WColor.color = Color.black;
        else
            WColor.color = Color.white;
        WColor.text = winner.ToString();
        int ftime = (int)time;
        FTime.text = "Time: " + ftime / 60 + ":" + ftime % 60;
       
    }
    public void OnMainMenu()
    {
        PlayerPrefs.SetString("Player1", "");
        PlayerPrefs.SetString("Player2", "");
        PlayerPrefs.SetString("Save", "");
        SetActive(false);
        UIManager.LoadingScene(0);
    }
    public void OnRestart()
    {
        PlayerPrefs.SetString("Save", "");
        SetActive(false);
        UIManager.LoadingScene(1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
