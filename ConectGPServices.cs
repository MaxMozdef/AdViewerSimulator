
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ConectGPServices : MonoBehaviour
{
    //public static PlayGamesPlatform platform;

    //private void Awake()
    //{
    //    if (platform == null)
    //    {

    //        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
    //        PlayGamesPlatform.InitializeInstance(config);
    //        PlayGamesPlatform.DebugLogEnabled = true;
    //        platform = PlayGamesPlatform.Activate();
    //    }

    //    Social.Active.localUser.Authenticate(succsess =>
    //    {
    //        if (succsess)
    //        {
    //            Debug.Log("Log is succsessfully");
    //        }
    //        else
    //        {
    //            Debug.Log("Fail!");
    //        }
    //    });
    //}
    void Start()
    {
        
        Initialize();
        
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
}