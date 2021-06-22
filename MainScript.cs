using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject DiscriptionPanelStart;
    [SerializeField] private Text GameScoreText;
    int EnterTheGame;    
    int GameScore;
    string gameId = "123456";
    bool testMode = true;   


    void Start()
    {
        GameScore -= 1;
        EnterTheGameCounter();        
        GameScoreCount();
        Advertisement.Initialize(gameId, testMode);
    }

    
    void Update()
    {
        
        GameScoreText.text = GameScore + "";
        
        if (EnterTheGame < 3)
        {
            DiscriptionPanelStart.SetActive(true);
        }
        else
        {
            DiscriptionPanelStart.SetActive(false);
        }
    }

    private void GameScoreCount()
    {
        GameScore = PlayerPrefs.GetInt("GameScore");
        GameScore++;        
        PlayerPrefs.SetInt("GameScore", GameScore);     
   
    }

    private void EnterTheGameCounter()
    {
        EnterTheGame = PlayerPrefs.GetInt("EnterTheGameName");
        EnterTheGame++;
        PlayerPrefs.SetInt("EnterTheGameName", EnterTheGame);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit)");
    }
    public void OkGI()
    {
        EnterTheGame += 3;
    }

    public void WatchAds()
    {
        GameScoreCount();
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("все пропало");
        }
    }
    
}
