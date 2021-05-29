using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject DiscriptionPanelStart;
    private int EnterTheGame;
    


    void Start()
    {
        EnterTheGame = PlayerPrefs.GetInt("EnterTheGameName");        
        EnterTheGame++;
        PlayerPrefs.SetInt("EnterTheGameName", EnterTheGame);       
    }

    
    void Update()
    {
        

        if (EnterTheGame < 3)
        {
            DiscriptionPanelStart.SetActive(true);
        }
        else
        {
            DiscriptionPanelStart.SetActive(false);
        }
    }

    

    public void ExitGame()
    {
        Application.Quit();
    }
    public void OkGI()
    {
        EnterTheGame += 3;
    }
}
