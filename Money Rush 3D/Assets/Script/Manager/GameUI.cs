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
    public bool btns;

    public GameManager GameManager;

    public Animator animBigCoin, animBombCoin;

    private float IconConuter;
    private float NumberOfBombs = 0; // Number of Bombcoins
    private float ActivationTime = 30; // bigCoin activation time

    [SerializeField] Text CoinsText;

    private GameObject hand, restart, BigCoin, BombCoin, levelgun, IconShop;
    public GameObject GameOverPanel, ShopBtns;

    public GunController GunGame, GunPrifabs;
    public BulletController Bullet;


    private void Awake()
    {
        levelgun = GameObject.Find("LevelGun");
        BombCoin = GameObject.Find("BombCoinIcon");
        BigCoin = GameObject.Find("BigCoinIcon");
        hand = GameObject.Find("Hand");
        restart = GameObject.Find("Restart");
        IconShop = GameObject.Find("IconShop");
    }

    void Start()
    {
        CanPlay = false;
        BigCoinIcon = true;
        animBigCoin.SetBool("AirplaneIcon", false);
        BombCoin.SetActive(false);
        BigCoin.SetActive(false);
        restart.SetActive(false);
    }

    void Update()
    {
        // start moving
        if (CanPlay)
        {
            BigCoinIcon = true;
            BigCoin.SetActive(true);
            BombCoin.SetActive(true);
            hand.SetActive(false);
            restart.SetActive(true);
            levelgun.SetActive(false);
            IconShop.SetActive(false);
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

        SetCoinsUI();
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

    public void Shop()
    {
        btns = !btns;
        ShopBtns.SetActive(btns);
        SoundManager.playSound("Click");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.playSound("Click");
    }

    public void DamegeGun()
    {
        // Increased damage
        Bullet.Damage += 10;
        SoundManager.playSound("Click");
    }
    public void bulletSpeedGun()
    {
        // Increased bulletspeed

        SoundManager.playSound("Click");
    }
    public void timeBetweenShotsGun()
    {
        // Decrease timebetweenshots
        GunGame.timeBetweenShotsBtn -= 0.5;
        GunPrifabs.timeBetweenShotsBtn -= 0.5;
        SoundManager.playSound("Click");
    }

    public void SetCoinsUI()
    {
        CoinsText.text = Game.Instance.Coins.ToString();
        GunPrifabs = GunGame;
    }

}
