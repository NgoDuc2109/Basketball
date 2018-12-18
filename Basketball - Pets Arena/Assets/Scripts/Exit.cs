using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    public PhysicsMaterial2D ballBall;
    public GameObject gameOver;
    public GameObject win;

    public AudioSource audioBackground;
    public AudioSource audio;
    public AudioClip cheering;

    public GameObject ScreenTouch;

    Animator anim;
    public static int scoreBullDog = 0, scoreMeoMeo = 0;

    private bool checkQC = false;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
    }
    
    void Update()
    {
        if (checkQC ==true)
        {
            ShareRateAds.shareRateAds.ShowIn();
            checkQC = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.tag == "Ball" && BallDropped.PlayerIndex ==1)
            {


                other.tag = "Untagged";
                win.gameObject.SetActive(true);
                Time.timeScale = 0.7f;
                scoreBullDog++;
                PlayerPrefs.SetInt("Dog", scoreBullDog);
                audio.clip = cheering;
                audio.Play();
                audioBackground.clip = null;
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin")+5);
                anim.Play("UpRo");
                BallDropped.PlayerIndex = 0;
                ScreenTouch.SetActive(false);
                checkQC = true;
                return;
            }
            else if (other.tag == "Ball" && BallDropped.EnemyIndex == 1)
            {
                other.tag = "Untagged";
                gameOver.SetActive(true);
                Time.timeScale = 0.7f;
                scoreMeoMeo++;
                PlayerPrefs.SetInt("Cat", scoreMeoMeo);
                audio.clip = cheering;
                audio.Play();
                audioBackground.clip = null;
                anim.Play("UpRo");
                BallDropped.EnemyIndex = 0;
                ScreenTouch.SetActive(false);
                checkQC = true;
                if (PlayerPrefs.GetInt("Coin")-3 >0)
                {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 3);
                }
                else
                {
                    
                    PlayerPrefs.SetInt("Coin", 0);
                }

                return;


            }


        }
        catch (Exception ex)
        {

        }
    }


}
