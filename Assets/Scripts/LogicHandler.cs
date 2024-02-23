using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicHandler : MonoBehaviour
{
    public int coinGoalCount = 10;
    public int maxTime = 30;

    public  TMPro.TextMeshProUGUI count;
    public  TMPro.TextMeshProUGUI maxCount;
    public TMPro.TextMeshProUGUI time;

    public GameObject win;
    public GameObject lose;

    [HideInInspector] public int currentCoinCount = 0;

    private int timeLeft;
    private bool gameRunning;

    void Start()
    {
        timeLeft = maxTime;
        gameRunning = true;

        maxCount.text = coinGoalCount.ToString();
        count.text = currentCoinCount.ToString();
        time.text = timeLeft.ToString();

        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        while (gameRunning && timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            if(gameRunning) timeLeft--;
            time.text = timeLeft.ToString();


            // Check if time has run out
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                gameRunning = false;
                LoseGame(); 
            }
        }
    }

    public void AddCoin()
    {
        if(gameRunning)
        {
            currentCoinCount += 1;
            count.text = currentCoinCount.ToString();

            if(coinGoalCount <= currentCoinCount)
            {
                gameRunning = false;
                WinGame();
            }
        }
    }

    private void WinGame()
    {
        win.SetActive(true);
        StopCoroutine(CountdownCoroutine());
    }

    private void LoseGame()
    {
        lose.SetActive(true);
        StopCoroutine(CountdownCoroutine());
    }
}
