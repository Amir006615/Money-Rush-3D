using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameUI : MonoBehaviour
{
    public bool BigCoinIcon;
    public bool BombCoinIcon;
    public bool CanPlay;
    public bool SoundSetting;
    public bool btnsSetting;
    public bool btnsShop;

    public GameManager GameManager;

    [Header("PreGame")]
    public Button soundBtn;
    public Sprite soundOnSpr, soundOffSpr;

    public Animator animBigCoin, animBombCoin;

    private float IconConuter;
    private float NumberOfBombs = 0; // Number of Bombcoins
    private float ActivationTime = 30; // bigCoin activation time


    private GameObject hand, restart, BigCoin, BombCoin, levelgun, SettingsBg, ShopBg;
    public GameObject GameOverPanel, allbtns, Shop;

    private void Awake()
    {
        levelgun = GameObject.Find("LevelGun");
        BombCoin = GameObject.Find("BombCoinIcon");
        BigCoin = GameObject.Find("BigCoinIcon");
        hand = GameObject.Find("Hand");
        restart = GameObject.Find("Restart");
        SettingsBg = GameObject.Find("SettingsBg");
        ShopBg = GameObject.Find("ShopBg ");
    }

    void Start()
    {
        SoundSetting = false;
        CanPlay = false;
        BigCoinIcon = true;
        animBigCoin.SetBool("AirplaneIcon", false);
        BombCoin.SetActive(false);
        BigCoin.SetActive(false);
        restart.SetActive(false);
    }

    void Update()
    {
        // Unplug the sound // Unfinished
        if (SoundSetting)
        {
            if (soundBtn.GetComponent<Image>().sprite != soundOnSpr)
                soundBtn.GetComponent<Image>().sprite = soundOnSpr;
            else if ( soundBtn.GetComponent<Image>().sprite != soundOffSpr)
                soundBtn.GetComponent<Image>().sprite = soundOffSpr;
            SoundSetting = false;
        }
        // start moving
        if (CanPlay)
        {
            BigCoinIcon = true;
            BigCoin.SetActive(true);
            BombCoin.SetActive(true);
            hand.SetActive(false);
            restart.SetActive(true);
            levelgun.SetActive(false);
            SettingsBg.SetActive(false);
            ShopBg.SetActive(false);
            allbtns.SetActive(false);
            Shop.SetActive(false);
            BigCoin.GetComponent<Button>().enabled = false;
            CanPlay = false;
        }

        // to start BigCoinIcon
        if (BigCoinIcon)
        {
            IconConuter -= Time.deltaTime;
            if (IconConuter <= 0)
            {
                IconConuter = ActivationTime;
                animBigCoin.SetBool("AirplaneIcon", true);
                BigCoin.GetComponent<Button>().enabled = true;
                BigCoinIcon = false;
            }
        }

        // to start BombCoinIcon
        if (BombCoinIcon)
        {
            if (NumberOfBombs >= 3)
            {
                BombCoin.GetComponent<Button>().enabled = false;
                animBombCoin.SetBool("BombIcon", true);
            }

        }

    }

    // Using bigcoin
    public void UsingBigCoin()
    {
        BigCoinIcon = true;
        animBigCoin.SetBool("AirplaneIcon", false);
        BigCoin.GetComponent<Button>().enabled = false;
        SoundManager.playSound("Clickicon");
    }

    // Using bombcoin
    public void UsingBombCoin()
    {
        BombCoinIcon = true;
        NumberOfBombs += 1;
        SoundManager.playSound("Clickicon");
    }

    // Using settings
    public void Settings()
    {
        btnsSetting = !btnsSetting;
        allbtns.SetActive(btnsSetting);
        SoundManager.playSound("Click");
    }
    public void shop()
    {
        btnsShop = !btnsShop;
        Shop.SetActive(btnsShop);
        SoundManager.playSound("Click");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.playSound("Click");
    }

    // // Unplug the sound
    public void soundstart()
    {
        SoundSetting = true;
        SoundManager.playSound("Click");

    }
}
