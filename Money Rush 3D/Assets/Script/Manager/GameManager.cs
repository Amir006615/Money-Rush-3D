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

    public CameraSpeed Camera, Cplayer;
    public Player Player;
    public Movment cameramove, player;
    public GameUI UI;
    public SoundManager Sound;


    // Start is called before the first frame update
    void Start()
    {
        Sound.AudioSource.enabled = true;

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
                Sound.AudioSource.enabled = false;
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
}
