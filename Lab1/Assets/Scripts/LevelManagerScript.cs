using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] GameOverMenuScript gameOver;
    [SerializeField] WinnerMenuScript winnerMenu;
    [SerializeField] Text Score;
    [SerializeField] Slider Health;
    [SerializeField] Text SpeedBonus;
    [SerializeField] Text HealthAmount;
    public bool isSpeedBonusActive = false;

    public int SetHealthAmount { set { HealthAmount.text = value.ToString(); } }
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "Score: " + 0;
        SpeedBonus.text = "";
    }

    // Update is called once per frame
   
   
    public void SetActiveSpeedBonus(bool isActive)
    {
        if(isActive)
        SpeedBonus.text  = "Active speed bonus";
        else
            SpeedBonus.text = "";

    }
    
    public void SetActiveGameOverMenu()
    {
        gameOver.SetActive();
    }
    public void SetActiveWinnerMenu()
    {
        winnerMenu.SetActive();
    }
    public void SetScore(int score)
    {
        Score.text = "Score: " + score;
    }
    public void ChangeHealth(int health)
    {
        Health.value = 100 - health;
    }
  
    public void ChangeSpeedBonus(float BonusTime)
    {
        if (BonusTime <= 0)
        {
            SpeedBonus.text = "";
            return;
        }
        SpeedBonus.text = BonusTime.ToString();
    }

   
}
