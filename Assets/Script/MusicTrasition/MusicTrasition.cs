using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrasition : MonoBehaviour
{
    public PlayerHP playerHP;
    public int lowHP = 30;
    private static MusicTrasition instance;
    private bool isDead;

    private AudioSource[] allAudioSources;
    public AudioSource myAudio;

    public AudioClip playerDamaged;
    public AudioClip playerNearDeath;
    public AudioClip playerDeath;
    public AudioClip playerMeleeHit1;
    public AudioClip playerMeleeHit2;
    public AudioClip playerMeleeAttack;
    public AudioClip playerMeleeSwap;
    public AudioClip playerPistolAttack;
    public AudioClip playerPistolNoAmmo;
    public AudioClip playerPickUpAmmo;
    public AudioClip playerPickUpHeal;

    public AudioClip enemyMeleeAttack;
    public AudioClip enemyRangedAttack;
    public AudioClip enemySpawn;
    public AudioClip enemyDeath;
    public AudioClip enemyGiantVoice;
    public AudioClip enemySmallVoice;

    public AudioClip backgroundMidGame;
    public AudioClip backgroundEndGame;
    //public AudioClip background

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayDelayed(10.0f);

    }
    private void Update()
    {
        LowHP();
    }

    void awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void LowHP()
    {
        if(playerHP.GetCurrentLifePoints() < lowHP)
        {
            myAudio.PlayOneShot(playerNearDeath);

            if (playerHP.GetCurrentLifePoints()<=0 != isDead)
            {
                StopAllAudio();
                myAudio.PlayOneShot(playerDeath);
                isDead = true;
            }
        }

    }

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
}
