using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour {
    public Text scoreDog ,scoreCat;
    public GameObject[] playerImage;
    public Animator anim1, anim2;
    public GameObject GameOver, WinGame;
    public Text myMoney;
    void Awake()
    {
        playerImage[SceneController.characterImage].SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Time.timeScale = 1;
    }
    void Update()
    {
        scoreDog.text = PlayerPrefs.GetInt("Dog").ToString();
        scoreCat.text = PlayerPrefs.GetInt("Cat").ToString();
        myMoney.text = PlayerPrefs.GetInt("Coin").ToString();
        if (GameOver.activeInHierarchy==true)
        {
            anim1.Play("GameOver");
        }
        else if (WinGame.activeInHierarchy==true)
        {
            anim2.Play("WinGame");
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Exit.scoreBullDog = 0;
        PlayerPrefs.SetInt("Dog", Exit.scoreBullDog);
        Exit.scoreMeoMeo = 0;       
        PlayerPrefs.SetInt("Cat",Exit.scoreMeoMeo);
    }

    public void WatchVideo()
    {
        ShareRateAds.shareRateAds.ShowBasedVideo();
    }
}
