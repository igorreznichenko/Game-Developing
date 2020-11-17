using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenuScript : CommonMenuButtonsScript
{
    [SerializeField] GameObject GameOverUI;

    private void Start()
    {
        GameOverUI.SetActive(false);
    }
    public void SetActive()
    {
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }


}
