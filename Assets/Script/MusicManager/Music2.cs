using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music2 : MonoBehaviour
{
    public AudioSource playerDamaged;
    public AudioSource playerNearDeath;
    public AudioSource playerDeath;
    public AudioSource playerMeleeHit1;
    public AudioSource playerMeleeHit2;
    public AudioSource playerMeleeAttack;
    public AudioSource playerMeleeSwap;
    public AudioSource playerPistolAttack;
    public AudioSource playerPistolNoAmmo;
    public AudioSource playerPickUpAmmo;
    public AudioSource playerPickUpHeal;
    public AudioSource enemyMeleeAttack;
    public AudioSource enemyRangedAttack;
    public AudioSource enemySpawn;
    public AudioSource enemyGiantDamaged;
    public AudioSource enemyGiantDeath;
    public AudioSource enemySmallDeath;
    public AudioSource enemyGiantVoice;
    public AudioSource enemySmallVoice;
    public void PlayDamage()
    {
        playerDamaged.Play();
    }
}
