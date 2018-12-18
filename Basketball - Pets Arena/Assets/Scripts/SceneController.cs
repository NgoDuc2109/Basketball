using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour {
    public AudioSource audio;
    public AudioClip beep;

    public int[] price;
    public GameObject Shop;
    public Text money;
    public GameObject notEnoughMoney;
    public static int characterImage;
    void Start()
    {
        
        money.text = PlayerPrefs.GetInt("Coin").ToString();
        PlayerPrefs.SetInt("Dog",0);
        PlayerPrefs.SetInt("Cat", 0);
        Time.timeScale = 1;
    }

    public void Click(int temp)
    {
        if (PlayerPrefs.GetInt("Character" + temp) == 1)
        {
            characterImage = temp;
        }
        else
        {
            if (price[temp] <= PlayerPrefs.GetInt("Coin"))
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - price[temp]);
                money.text = PlayerPrefs.GetInt("Coin").ToString();

                PlayerPrefs.SetInt("Character" + temp, 1);
                characterImage = temp;

            }
            else
            {
                notEnoughMoney.SetActive(true);
            }
        }
        audio.clip = beep;
        audio.Play();
    }



    public void openShop()
    {
        Shop.SetActive(true);
    }

    public void Share()
    {
        ShareRateAds.shareRateAds.Share();
    }
    public void Rate()
    {
        ShareRateAds.shareRateAds.Rate();
    }
}
