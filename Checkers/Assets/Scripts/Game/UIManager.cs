using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject LoadingPanel;
    [SerializeField] TextMeshProUGUI p1Name;
    [SerializeField] TextMeshProUGUI p2Name;
    [SerializeField] TextMeshProUGUI p1CCount;
    [SerializeField] TextMeshProUGUI p2CCount;
    int b = 8, w = 8;
    [SerializeField] TextMeshProUGUI timePanel;
    [SerializeField] PauseMenuScript pauseMenu;
    [SerializeField] WinnerMenu winnerMenu;
    public float getDeltaTime=> Time.time - initTime;
    float initTime;
    void Start()
    {
       
    }

    public void ReduceCount(CheckerColor checker)
    {
        if(checker == CheckerColor.Black)
        {
            b--;
            p1CCount.text = "Count: "+b.ToString();
        }
        else
            if(checker == CheckerColor.White)
        {
            w--;
            p2CCount.text = "Count: "+w.ToString();
        }
        if (b == 0)
            winnerMenu.SetWinner(CheckerColor.White, PlayerPrefs.GetString("Player2"), getDeltaTime);
        else
            if (w == 0)
            winnerMenu.SetWinner(CheckerColor.Black, PlayerPrefs.GetString("Player1"), getDeltaTime);

    }
    public void SetWinner(CheckerColor color)
    {
        if(color == CheckerColor.Black)
        {
            winnerMenu.SetWinner(CheckerColor.Black, PlayerPrefs.GetString("Player1"), getDeltaTime);

        }
        else
            if(color  == CheckerColor.White)
        {
            winnerMenu.SetWinner(CheckerColor.White, PlayerPrefs.GetString("Player2"), getDeltaTime);

        }
    }
    public void LoadUI()
    {
        if (PlayerPrefs.GetString("Save") != "")
        {
            Saver s = JsonUtility.FromJson<Saver>(PlayerPrefs.GetString("Save"));
            int c1 = s.arr.Count(x => x.color == CheckerColor.Black);
            int c2 = s.arr.Count(x => x.color == CheckerColor.White);
            b = c1;
            w = c2;
            p1CCount.text = "Count: " + c1.ToString();
            p2CCount.text = "Count: " + c2.ToString();
            initTime = Time.time - s.time;
        }
        else
        {
            p1Name.text = PlayerPrefs.GetString("Player1");
            p2Name.text = PlayerPrefs.GetString("Player2");
            p1CCount.text = "Count: " + b;
            p2CCount.text = "Count: " + w;
            initTime = Time.time;
        }
    }
    public void LoadingScene(int index)
    {
        StartCoroutine(loadingScene(index));
    }
    private IEnumerator loadingScene(int index)
    {
        LoadingPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseMenu.ChangeState();
    }
    private void FixedUpdate()
    {
        float time = Time.time - initTime;
        int second = (int)time % 60;
        int minute = (int)time / 60;
        timePanel.text = string.Format("{0:00}:{1:00}",  minute,second);
    }


}
