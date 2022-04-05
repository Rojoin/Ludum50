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
    public AudioClip playerMeleeSwap;   //MISSING
    public AudioClip playerPistolAttack;//Listo
    public AudioClip playerPistolNoAmmo;//Listo
    public AudioClip playerPickUpAmmo;  //Listo
    public AudioClip playerPickUpHeal;  //Listo
    public AudioClip playerDash;        //Listo

    public AudioClip enemyMeleeAttack;  //Listo
    public AudioClip enemyRangedAttack; //Listo SUPUESTAMENTE DESAPARECE
    public AudioClip enemySpawn;        //Listo
    public AudioClip enemyGiantDamaged; //Listo
    public AudioClip enemyGiantDeath;   //Listo
    public AudioClip enemySmallDeath;
    public AudioClip enemyGiantVoice;   //??
    public AudioClip enemySmallVoice;   //??

    public AudioClip backgroundStartGame;
    public AudioClip backgroundMidGame;
    public AudioClip backgroundEndGame;
    //public AudioClip background

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayOneShot(backgroundStartGame);
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
        //if(playerHP.GetCurrentLifePoints() < lowHP)
        //{
            //myAudio.PlayOneShot(playerNearDeath);
        //}

    }

    private void OnEnable()
    {
        PlayerHP.OnRequestingPlayerDeath += PlayerDeath;
        BaseEnemy.onRequestingEnemyDeath += EnemyGiantDeath;
        BaseEnemy.onRequestingEnemyDamaged += EnemyDamaged;
        SpawnEnemy.onRequestingEnemySpawn += EnemySpawn;
        customDistanceAttack.DistanceAttack.onRequestingEnemyRangedAttack += EnemyRangedAttack;
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
        PlayerHP.OnRequestingPlayerDeath -= PlayerDeath;
        BaseEnemy.onRequestingEnemyDeath -= EnemyGiantDeath;
        BaseEnemy.onRequestingEnemyDamaged -= EnemyDamaged;
        SpawnEnemy.onRequestingEnemySpawn -= EnemySpawn;
        customDistanceAttack.DistanceAttack.onRequestingEnemyRangedAttack -= EnemyRangedAttack;
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
    public void PlayerDeath()
    {
        if (!isDead)
        {
            StopAllAudio();
            myAudio.PlayOneShot(playerDeath);
            isDead = true;
        }
    }

    public void EnemyGiantDeath()
    {
        myAudio.PlayOneShot(enemyGiantDeath);
    }
    public void EnemyDamaged()
    {
        myAudio.PlayOneShot(enemyGiantDamaged);
    }
    public void EnemySpawn()
    {
        myAudio.PlayOneShot(enemySpawn);
    }
    public void EnemyRangedAttack()
    {
        myAudio.PlayOneShot(enemyRangedAttack);
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
