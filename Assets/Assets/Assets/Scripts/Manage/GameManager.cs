using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text gameOverTextUI;
    float timer = 0f;
    int itemCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
        GameEvents.PlayerDied.AddListener(GameOver);
        GameEvents.CollectItem.AddListener(CollectItem);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void GameOver()
    {
        string textToShow;
        gameOverUI.SetActive(true);
        int timeAliveInt = (int)timer;
        textToShow = "You've lasted " + timeAliveInt.ToString("0");
        
        if(timeAliveInt <= 1)
        {
            textToShow += " second";
        }
        else
        {
            textToShow += " seconds";
        }

        textToShow += " and you've earned " + itemCounter;

        if (timeAliveInt <= 1)
        {
            textToShow += " point";
        }
        else
        {
            textToShow += " points";
        }
        gameOverTextUI.text = textToShow;
    }
    void CollectItem()
    {
        itemCounter++;
    }
}