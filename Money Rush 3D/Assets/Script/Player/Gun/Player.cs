using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GunController theGun;
    public GameObject player;
    public Movment movment;
    public CameraSpeed CameraSpeed;


    // Update is called once per frame
    void Start()
    {
        // enabled isFiring
        theGun.isFiring = true;
    }

    public void GameOver()
    {
        // turn off game player object
        player.SetActive(false);
        // disablies the movement of the camera
        movment.enabled = false;
        // disablies the forvard of the camera
        CameraSpeed.enabled = false;
    }
}
