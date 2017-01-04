using UnityEngine;
using System.Collections;

public enum soundsGame
{
    kimcuong,
    air,
    time,
    fail,
    win,
    jump,
    audioBG,
    dongho,
    touch,
    stop_dongho,
    stop_audio
}


public class SoundController : MonoBehaviour {

    public AudioClip m_soundKimCuong;
    public AudioClip m_soundAir;
    public AudioClip m_soundTime;
    public AudioClip m_soundFail;
    public AudioClip m_soundWin;
    public AudioClip m_soundJump;
    public AudioClip m_soundDongHo;
    public AudioClip m_soundTouch;
    AudioSource m_audio;

    public static bool Music = true;

    public static SoundController instance;
    // Use this for initialization
    void Start () {
        m_audio = GetComponent<AudioSource>();
        //m_audio.Play();

        if (!Music)
        {
            GameObject.Find("MusicButton").GetComponent<Animator>().SetBool("MuteMusic", true);
            GameObject.Find("MusicButton").GetComponent<Animator>().SetBool("Music", false);
        }

        instance = this;        
    }

    public static void PlaySound(soundsGame currentSound)
    {
        switch (currentSound)
        {
            case soundsGame.kimcuong:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.m_soundKimCuong);
                }
                break;
            case soundsGame.air:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.m_soundAir);
                }
                break;
            case soundsGame.time:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.m_soundTime);
                }
                break;
            case soundsGame.fail:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.m_soundFail);
                }
                break;
            case soundsGame.win:
                {
                  
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.m_soundWin);
                }
                break;
            case soundsGame.dongho:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.m_soundDongHo);
                }
                break;
            case soundsGame.touch:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.m_soundTouch);
                }
                break;
            case soundsGame.stop_audio:
                {
                    instance.GetComponent<AudioSource>().Stop();
                }
                break;
            case soundsGame.jump:
                {

                    instance.GetComponent<AudioSource>().PlayOneShot(instance.m_soundJump);
                }
                break;
        }
    }

    
    // Update is called once per frame
    void Update()
    {  
        if (Music)
            m_audio.mute = false;
        else
            m_audio.mute = true;
        if (!m_audio.isPlaying)
            m_audio.Play();
    }

    public void ClickbtnMusic()
    {
        if (Music)
        {
            Music = false;
            GameObject.Find("MusicButton").GetComponent<Animator>().SetBool("MuteMusic", true);
            GameObject.Find("MusicButton").GetComponent<Animator>().SetBool("Music", false);
        }
        else
        {
            Music = true;
            GameObject.Find("MusicButton").GetComponent<Animator>().SetBool("Music", true);
            GameObject.Find("MusicButton").GetComponent<Animator>().SetBool("MuteMusic", false);
        }
    }
}
