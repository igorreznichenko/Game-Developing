using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : CommonMenuButtonsScript
{

    bool isPaused = false;
    [SerializeField]GameObject pauseMenuUI;
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                OnResume();
            else if(isPaused == false && Time.timeScale != 0)
                Pause();          
        }
    }
    public void Pause()
    {
        Debug.Log("Pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void OnResume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

}
