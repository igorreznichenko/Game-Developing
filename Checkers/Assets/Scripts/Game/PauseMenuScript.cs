using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] UIManager UIManager;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject  winnerMenu;
    bool IsActive = false;
    void Start()
    {
        IsActive = false;
        Menu.SetActive(IsActive);
        gameObject.SetActive(IsActive);

    }

    public void ChangeState()
    {
        if (winnerMenu.activeSelf)
            return;
        IsActive = !IsActive;
        gameObject.SetActive(IsActive);
        Menu.SetActive(IsActive);
        if (IsActive)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void OnContinue()
    {
        ChangeState();
    }
    public void OnMainMenu()
    {
        if (IsActive)
            Time.timeScale = 1;
        Save();
        UIManager.LoadingScene(0);

    }
    void Save()
    {
        Saver saver = new Saver(GameManager.Instance.GetCells, UIManager.getDeltaTime, GameManager.Instance.CurrentPlayer);
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(saver));
    }
  
}
