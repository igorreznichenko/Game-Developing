using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject LoadingPanel;
    [SerializeField] GameObject MainMenuUI;
    [SerializeField] GameObject PlayInfoUI;
    [SerializeField] InputField Player1;
    [SerializeField] InputField Player2;
    [SerializeField] Button Continue;
    void Start()
    {
        PlayInfoUI.SetActive(false);
        if (PlayerPrefs.GetString("SavedGame") != "")
            Continue.interactable = true;
        Player1.onEndEdit.AddListener(delegate { ValidateInput(Player1); });
        Player2.onEndEdit.AddListener(delegate { ValidateInput(Player2); });
        if (PlayerPrefs.GetString("Save") == "")
            Continue.interactable = false;
        else
            Continue.interactable = true;
 

    }
    public void ValidateInput(InputField input)
    {
        if(input.text.Length == 0)
        {
            input.placeholder.GetComponent<Text>().text = "This field cant be empty!";
            input.placeholder.color = Color.red;
        }

    }
    public void OnMenuPlay()
    {
        MainMenuUI.SetActive(false);
        PlayInfoUI.SetActive(true);
    }
    public void OnBack()
    {
        MainMenuUI.SetActive(true);
        PlayInfoUI.SetActive(false);
    }
    public void OnPlay()
    {
        string player1 = Player1.text;
        string player2 = Player2.text;
        if (player1 == "" || player2 == "")
            return;
        PlayerPrefs.SetString("Player1", player1);
        PlayerPrefs.SetString("Player2", player2);
        PlayerPrefs.SetString("Save", "");
        LoadingScene(1);

    }
    void LoadingScene(int index)
    {
        StartCoroutine(loadingScene(index));
    }
    IEnumerator loadingScene(int index)
    {
        LoadingPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
    public void test() { }
    public void OnContinue()
    {
        LoadingScene(1);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
