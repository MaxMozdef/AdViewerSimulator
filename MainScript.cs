using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.Purchasing;


public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject DiscriptionPanelStart;
    [SerializeField] private GameObject Shop;    
    [SerializeField] private GameObject MainUI;    
    [SerializeField] private Text GameScoreText;
    int EnterTheGame;    
    int GameScore;
    string gameId = "4186413";
    bool testMode = true;
    string leaderBoard = "CgkI5p7O0JUeEAIQAQ";

    string plus100Points = "com.carpet.adviewersimulator.buyonehundredpointsb";
    string plus333Points = "com.carpet.adviewersimulator.buythreehundredthirtythreepointsb";
    string plus999Points = "com.carpet.adviewersimulator.buyninehundredandninetynineb";
    string plus2kPoints = "com.carpet.adviewersimulator.buytwokb";
    string plusGift = "com.carpet.adviewersimulator.freemoney";

    private void Awake()
    {
        Initialize();
        Advertisement.Initialize(gameId, testMode);
        leaderBoardScore();
    }

    void Start()
    {
        
        Shop.SetActive(false);        
        EnterTheGameCounter();        
        GameScoreCount();        
    }

    void Initialize()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .RequestEmail()
            .RequestServerAuthCode(false)
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        SigninGooglePlay();
    }

    void SigninGooglePlay()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (result) => { });
    }

    public void leaderBoardScore()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(GameScore, leaderBoard, (bool success) => { });
        }
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

    public void OnPurcheseComplite(Product product)
    {
        if (product.definition.id == plus100Points)
        {
            GameScore = PlayerPrefs.GetInt("GameScore");
            GameScore += 100;
            PlayerPrefs.SetInt("GameScore", GameScore);
            Debug.Log("buy 100 points");
        }

        if (product.definition.id == plus333Points)
        {
            GameScore = PlayerPrefs.GetInt("GameScore");
            GameScore += 333;
            PlayerPrefs.SetInt("GameScore", GameScore);
            Debug.Log("buy 333 points");
        }
        
        if (product.definition.id == plus999Points)
        {
            GameScore = PlayerPrefs.GetInt("GameScore");
            GameScore += 999;
            PlayerPrefs.SetInt("GameScore", GameScore);
            Debug.Log("buy 999 points");
        }
        
        if (product.definition.id == plus2kPoints)
        {
            GameScore = PlayerPrefs.GetInt("GameScore");
            GameScore += 1999;
            PlayerPrefs.SetInt("GameScore", GameScore);
            Debug.Log("buy 2k points");
        }
        
        if (product.definition.id == plusGift)
        {
            Debug.Log("Thanks =)");
        }
    }

    public void OnPurcheseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log(reason);
    }

    public void ExitGame()
    {
        Application.Quit();
        
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
        MainUI.SetActive(false);
    }

    public void ExitShop ()
    {
        Shop.SetActive(false);
        MainUI.SetActive(true);
    }    
}
