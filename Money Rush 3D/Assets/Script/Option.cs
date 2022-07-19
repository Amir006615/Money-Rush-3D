using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public GameObject Theoppositeoption;

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "GUN")
        {
            // to deactivate gameObject
            gameObject.SetActive(false);
            SoundManager.playSound("Option");
            // to deactivate GameObject
            Theoppositeoption.SetActive(false);
        }
    }
}
