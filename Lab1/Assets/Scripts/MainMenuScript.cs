using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : CommonMenuButtonsScript
{

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject selectLevel;
    [SerializeField] GameObject options;
    private void Start()
    {
        selectLevel.SetActive(false);
        options.SetActive(false);
        var r = selectLevel.transform.GetChild(0).GetComponentsInChildren<Button>();
        if(PlayerPrefs.GetInt("Level") == 0)
        {
            mainMenu.GetComponentsInChildren<Button>()[1].interactable = false;
        }
    }
    public void OnStart()
    {
        SetLevel(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("Level", 1);
    }

    public void OnOptions()
    {
        if (options.active)
        {
            options.SetActive(false);
            mainMenu.SetActive(true);
            return;
        }
        mainMenu.SetActive(false);
        options.SetActive(true);
       

    }
    public void OnResume()
    {
        Debug.Log(PlayerPrefs.GetInt("Level"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
    public void OnSelectLevel()
    {
        if (selectLevel.active)
        {
            selectLevel.SetActive(false);
            mainMenu.SetActive(true);
            return;
        }
        
        mainMenu.SetActive(false);
        selectLevel.SetActive(true);
        int currentLevel = PlayerPrefs.GetInt("Level");
        var r = selectLevel.transform.GetChild(0).GetComponentsInChildren<Button>();
        TextMeshProUGUI t;
        for(int i = 0; i< r.Length; i++)
        {
            t = r[i].GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log(t.text);
            if(int.Parse(t.text) > currentLevel)
            {
                r[i].interactable = false;
           
            }
        }
        
        
    }
   
    public void SetLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
