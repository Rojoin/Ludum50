using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public PlayerHP playerHP;
    public int lowHP = 30;
    private static MusicManager instance;
    private bool isDead;

    private AudioSource[] allAudioSources;
    public AudioSource myAudio;

    public AudioClip playerDamaged;     //Listo
    public AudioClip playerNearDeath;   //Listo
    public AudioClip playerDeath;       //Listo
    public AudioClip[] playerMeleeHits; //Listo
    public AudioClip playerMeleeAttack; //Listo
    public AudioClip playerMeleeSwap;   //falta
    public AudioClip playerPistolAttack;//Listo
    public AudioClip playerPistolNoAmmo;//Listo
    public AudioClip playerPickUpAmmo;  //Listo
    public AudioClip playerPickUpHeal;  //Listo
    public AudioClip playerDash;        //Listo

    public AudioClip enemyMeleeAttack;  
    public AudioClip enemyRangedAttack;
    public AudioClip enemySpawn;
    public AudioClip enemyGiantDamaged;
    public AudioClip enemyGiantDeath;
    public AudioClip enemySmallDeath;
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

    private void OnEnable()
    {
        MeleEnemyAttack.OnRequestingEnemyMeleeAttack += EnemyMeleeAttack;
        ammoOrb.OnRequestingPickUpAmmo += PlayerPickUpAmmo;
        MeleeWeapon.OnRequestingMeleeHit += PlayerMeleeHit;
        MeleeWeapon.OnRequestingMeleeAttack += PlayerMeleeAttack;
        GunRaycast.OnRequestingNoAmmo += PlayerPistolNoAmmo;
        DashController.OnRequestingDash += PlayerDash;
        PlayerHP.OnRequestingPlayerDamaged += PlayerDamaged;
        PlayerHP.OnRequestingPlayerHeal += PlayerPickUpHeal;
        GunRaycast.OnRequestingPistolAttack += PlayerPistolAttack;
    }
    private void OnDisable()
    {
        MeleEnemyAttack.OnRequestingEnemyMeleeAttack -= EnemyMeleeAttack;
        ammoOrb.OnRequestingPickUpAmmo -= PlayerPickUpAmmo;
        MeleeWeapon.OnRequestingMeleeHit -= PlayerMeleeHit;
        MeleeWeapon.OnRequestingMeleeAttack -= PlayerMeleeAttack;
        GunRaycast.OnRequestingNoAmmo -= PlayerPistolNoAmmo;
        DashController.OnRequestingDash -= PlayerDash;
        PlayerHP.OnRequestingPlayerDamaged -= PlayerDamaged;
        PlayerHP.OnRequestingPlayerHeal -= PlayerPickUpHeal;
        GunRaycast.OnRequestingPistolAttack -= PlayerPistolAttack;
    }
    public void EnemyMeleeAttack()
    {
        myAudio.PlayOneShot(enemyMeleeAttack);
    }
    public void PlayerPickUpAmmo()
    {
        myAudio.PlayOneShot(playerPickUpAmmo);
    }
    public void PlayerMeleeHit()
    {
        var ran = Random.Range(0, 1);
        myAudio.PlayOneShot(playerMeleeHits[ran]);
    }
    public void PlayerMeleeAttack()
    {
        myAudio.PlayOneShot(playerMeleeAttack);
    }
    public void PlayerPistolNoAmmo()
    {
        myAudio.PlayOneShot(playerPistolNoAmmo);
    }
    public void PlayerPistolAttack()
    {
        myAudio.PlayOneShot(playerPistolAttack);
    }
    public void PlayerPickUpHeal()
    {
        myAudio.PlayOneShot(playerPickUpHeal);
    }
    public void PlayerDash()
    {
        myAudio.PlayOneShot(playerDash);
    }
    public void PlayerDamaged()
    {
        myAudio.PlayOneShot(playerDamaged);
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
