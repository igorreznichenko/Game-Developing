using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
public class WinnerMenuScript : CommonMenuButtonsScript
{

    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject player;
    [SerializeField] Text Score;
    private void Start()
    {
        GameOverUI.SetActive(false);
        
    }
    public void SetActive()
    {
        Time.timeScale = 0f;
        Score.text = "Score: "+player.GetComponent<PlayerBehavior>().Score.ToString();
        GameOverUI.SetActive(true);
    }
    public void nextlevel()
    {
        
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        if (level > SceneManager.sceneCountInBuildSettings - 1)
            level = 0;
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
    }

}
