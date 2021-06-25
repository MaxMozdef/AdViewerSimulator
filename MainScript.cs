using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject DiscriptionPanelStart;
    [SerializeField] private GameObject Shop;
    [SerializeField] private Text GameScoreText;
    int EnterTheGame;    
    int GameScore;
    string gameId = "4186413";
    bool testMode = true;
    string leaderBoard = "CgkI5p7O0JUeEAIQAQ";   

    

    void Start()
    {
        Initialize();
        Shop.SetActive(false);
        GameScore -= 1;
        EnterTheGameCounter();        
        GameScoreCount();
        Advertisement.Initialize(gameId, testMode);           
    }

    void Initialize ()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestServerAuthCode(false).Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        SigninGooglePlay();
    }

    void SigninGooglePlay()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (success) => { });
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
        Social.ReportScore(GameScore, leaderBoard, (bool success) => { });   
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
        PlayGamesPlatform.Instance.SignOut();
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

    public void ShowLeaderBoard ()
    {
        Social.ShowLeaderboardUI();
    }
    
    public void GoToShop()
    {
        Shop.SetActive(true);      

    }

    public void ExitShop ()
    {
        Shop.SetActive(false);
    }
}
