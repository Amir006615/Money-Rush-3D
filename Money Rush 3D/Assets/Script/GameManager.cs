using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public bool CanMove;
    public bool g;

    public GunController Gun1, Gun2;
    public BulletController Bullet;
    public CameraSpeed Camera, Cplayer;
    public Player Player;
    public Movment cameramove, player;
    public GameUI UI;

    // Start is called before the first frame update
    void Start()
    {
        //not moving
        CanMove = false;
        g = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IgnoreUI())
        {
            if (g)
            {
                CanMove = true;
                UI.CanPlay = true;
                g = false;
            }
        }
        
        // start moving
        if (CanMove)
        {
             player.enabled = true;
             cameramove.enabled = true;
             Camera.enabled = true;
             Cplayer.enabled = true;
             Player.enabled = true;
            CanMove = false;
        }
    }
    public bool IgnoreUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if (raycastResultList[i].gameObject.GetComponent<Ignore>() != null)
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }

        return raycastResultList.Count > 0;
    }

    public void DamegeGun()
    {
        // Increased damage
        Bullet.Damage += 0.2;
        SoundManager.playSound("Click");
    }
    public void bulletSpeedGun()
    {
        // Increased bulletspeed
        Gun1.bulletSpeedButton += 10;
        Gun2.bulletSpeedButton += 10;
        SoundManager.playSound("Click");
    }
    public void timeBetweenShotsGun()
    {
        // Decrease timebetweenshots
        Gun1.timeBetweenShotsButton -= 0.02;
        Gun2.timeBetweenShotsButton -= 0.02;
        SoundManager.playSound("Click");
    }
}
