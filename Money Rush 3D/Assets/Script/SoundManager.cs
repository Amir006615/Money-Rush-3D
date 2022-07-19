using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Bullet, Option, Enemy, Wall, Click, Clickicon;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = Resources.Load<AudioClip>("bullet");
        Option = Resources.Load<AudioClip>("Option");
        Enemy = Resources.Load<AudioClip>("Enemy");
        Wall = Resources.Load<AudioClip>("Wall");
        Click = Resources.Load<AudioClip>("Click");
        Clickicon = Resources.Load<AudioClip>("ClickCoinButten");

        audioSrc = GetComponent<AudioSource>();

    }
    public static void playSound(string clip)
    {
            switch (clip)
            {
                case "bullet":
                    audioSrc.PlayOneShot(Bullet);
                    break;
                case "Option":
                    audioSrc.PlayOneShot(Option);
                    break;
                case "Enemy":
                    audioSrc.PlayOneShot(Enemy);
                    break;
                case "Wall":
                    audioSrc.PlayOneShot(Wall);
                    break;
                case "Click":
                    audioSrc.PlayOneShot(Click);
                    break;
                case "Clickicon":
                    audioSrc.PlayOneShot(Clickicon);
                    break;
            }

    }

}
