using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public static AudioClip Bullet, Option, Enemy, Wall, Click, Clickicon, music;
    public static AudioSource AudioSrcSound, AudioSrcMusic;
    public Slider Music, Sound;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = Resources.Load<AudioClip>("bullet");
        Option = Resources.Load<AudioClip>("Option");
        Enemy = Resources.Load<AudioClip>("Enemy");
        Wall = Resources.Load<AudioClip>("Wall");
        Click = Resources.Load<AudioClip>("Click");
        Clickicon = Resources.Load<AudioClip>("ClickCoinButten");
        music = Resources.Load<AudioClip>("Music");

        AudioSrcSound = GetComponent<AudioSource>();
        AudioSrcMusic = AudioSource;

    }

    private void Update()
    {
        AudioSrcSound.volume = Sound.value;
        AudioSrcMusic.volume = Music.value;
    }

    public static void playSound(string clip)
    {
            switch (clip)
            {
                case "bullet":
                AudioSrcSound.PlayOneShot(Bullet);
                    break;
                case "Option":
                AudioSrcSound.PlayOneShot(Option);
                    break;
                case "Enemy":
                AudioSrcSound.PlayOneShot(Enemy);
                    break;
                case "Wall":
                AudioSrcSound.PlayOneShot(Wall);
                    break;
                case "Click":
                AudioSrcSound.PlayOneShot(Click);
                    break;
                case "Clickicon":
                AudioSrcSound.PlayOneShot(Clickicon);
                    break;
                
            }

    }

}
