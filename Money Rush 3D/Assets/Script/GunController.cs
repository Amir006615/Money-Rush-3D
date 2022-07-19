using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour
{

    public bool isFiringBombCoin;
    public bool isFiringBigCoin;
    public bool isFiring;
    public bool isFiringDobbel; // to shootDobbel
    public bool isFiringDobbelGun; // to shootDobbelGun

    public GameUI UI;
    public Player player;
    public BigCoin BigCoin;
    public BombCoin BombCoin;
    public BulletController bullet;

    public double timeBetweenShotsButton;
    public float bulletSpeedButton;

    private float bulletSpeed = 70;
    private double timeBetweenShots = 0.2;
    private float shotConuter;

    public Transform firePointBigCoin;
    public Transform firePoint;
    public Transform firePointDobbel1;
    public Transform firePointDobbel2;
    public Transform DobbelGunfirePoint;
    public Transform DobbelGunfirePointDobbel1;
    public Transform DobbelGunfirePointDobbel2;

    public GameObject DobbelGun, BulletFinish2, BulletFinish;

    void Start()
    {
        isFiringDobbelGun = false;
        isFiringDobbel = false;
    }

    // Update is called once per frame
    public void Update()
    {
        // to Shoot
        if (isFiring)
        {
            // number of shots
            shotConuter -= Time.deltaTime;
            if (shotConuter <= 0)
            {
                shotConuter = (float)timeBetweenShots *+ (float)timeBetweenShotsButton;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed + bulletSpeedButton;

                // to ShootGunDabbel
                if (isFiringDobbelGun)
                {
                    BulletController newBulletDobbel = Instantiate(bullet, DobbelGunfirePoint.position, DobbelGunfirePoint.rotation) as BulletController;
                    newBulletDobbel.speed = bulletSpeed + bulletSpeedButton;
                }
            }
        }
        // to shootDobbel
        if (isFiringDobbel)
        {
            shotConuter -= Time.deltaTime;
            if (shotConuter <= 0)
            {
                shotConuter = (float)timeBetweenShots *+ (float) timeBetweenShotsButton;
                BulletController newBullet1 = Instantiate(bullet, firePointDobbel1.position, firePointDobbel1.rotation) as BulletController;
                BulletController newBullet2 = Instantiate(bullet, firePointDobbel2.position, firePointDobbel2.rotation) as BulletController;
                newBullet1.speed = bulletSpeed + bulletSpeedButton;
                newBullet2.speed = bulletSpeed + bulletSpeedButton;

                // to ShootGunDabbel
                if (isFiringDobbelGun)
                {
                    BulletController newBulletDobbel1 = Instantiate(bullet, DobbelGunfirePointDobbel1.position, DobbelGunfirePointDobbel1.rotation) as BulletController;
                    BulletController newBulletDobbel2 = Instantiate(bullet, DobbelGunfirePointDobbel2.position, DobbelGunfirePointDobbel2.rotation) as BulletController;
                    newBulletDobbel1.speed = bulletSpeed + bulletSpeedButton;
                    newBulletDobbel2.speed = bulletSpeed + bulletSpeedButton;
                }
            }
        }
        // to shootBigCoin
        if (isFiringBigCoin)
        {
                BigCoin newBigCoin = Instantiate(BigCoin, firePointBigCoin.position, firePointBigCoin.rotation) as BigCoin;
                newBigCoin.speed = 40;
                isFiringBigCoin = false;
        }
        // to shootBombCoin
        if (isFiringBombCoin)
        {
                shotConuter = 0;
                BombCoin newBombCoin = Instantiate(BombCoin, firePoint.position, firePoint.rotation) as BombCoin;
                newBombCoin.speed = 75;

                if (isFiringDobbelGun)
                {
                    BombCoin newBombCoinDobble = Instantiate(BombCoin, DobbelGunfirePoint.position, DobbelGunfirePoint.rotation) as BombCoin;
                    newBombCoinDobble.speed = 75;
                }
                isFiringBombCoin = false; 
        }

    }

    IEnumerator NextLevel()
    {
        // next Level // Unfinished
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            // start Gameover
            player.GameOver();
            // start GameOverPanel
            UI.GameOverPanel.SetActive(true);
            // Inactive to BigCoinIcon and BombCoinIcon
            UI.BigCoinIcon = false;
            UI.BombCoinIcon = false;
            SoundManager.playSound("Enemy");
        }

        if (target.gameObject.tag == "bulletSpeed")
        {
            // increasing BulletSpeed
            bulletSpeed += 10;
            
        }

        if (target.gameObject.tag == "-bulletSpeed")
        {
            // Reduced BulletSpeed
            bulletSpeed -= 10;

        }

        if (target.gameObject.tag == "BulletFinish2")
        {
            // start BulletFinish2
            BulletFinish.SetActive(false);
            BulletFinish2.SetActive(true);
        }

        if (target.gameObject.tag == "FiringDobbel")
        {
            // start fireDobbel
            isFiring = false;
            isFiringDobbel = true;
        }

        if (target.gameObject.tag == "timeBetweenShots")
        {
            // reduce shooting time
            timeBetweenShots -= 0.1;
        }

        if (target.gameObject.tag == "-timeBetweenShots")
        {
            // Increase shooting time
            timeBetweenShots += 0.1;
        }

        if (target.gameObject.tag == "DobbelGun")
        {
            // Active Dobbelgun
            DobbelGun.SetActive(true);
            gameObject.GetComponent<Animator>().enabled = true;
            isFiringDobbelGun = true;
        }

        if (target.gameObject.name == "Finish")
        {
            // Unfinished
        }

        if (target.gameObject.name == "Wall")
        {
            //play sound Wall
            SoundManager.playSound("Wall");
        }
    }

    public void PlayBigCoin()
    {
        // play isFiringBigCoin
        isFiringBigCoin = true;
    }

    public void PlayBombCoin()
    {
        // Play isFiringBombCoin
        isFiringBombCoin = true;
    }
}
