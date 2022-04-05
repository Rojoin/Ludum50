using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceEnemy : Killable {

    [SerializeField] NavMeshAgent pathfinding;
    [SerializeField] float movementSpeed;

    [SerializeField] int health;
    [SerializeField] float attackCooldown;
    float timerAttack = 0f;
    [SerializeField] float attackDistance;

    [SerializeField] float deadTime;
    public Animator animator;
    Transform player;

    public enum EnemyState {
        GoingToPlayer,
        PreparingAttack,
        Dead
    }
    [SerializeField] protected EnemyState actualState;
    public EnemyState lastState;


    [SerializeField] BulletEnemy projectile;
    [SerializeField] Transform projectileSpawn;

    public delegate void EnemyDead(Vector3 position);
    public static event EnemyDead OnEnemyDead;

    void Start() {
        player = FindObjectOfType<StarterAssets.FirstPersonController>().transform;
        pathfinding.destination = player.transform.position;
        pathfinding.speed = movementSpeed;
        pathfinding.updateRotation = false;
    }

    void Update() {
        if (actualState == EnemyState.Dead)
            return;

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        Debug.DrawRay(projectileSpawn.position, ((player.transform.position + new Vector3(0, 1.2f, 0)) - projectileSpawn.position).normalized * attackDistance, Color.red);

        RaycastHit hit;
        Physics.Raycast(projectileSpawn.position, ((player.transform.position + new Vector3(0, 1.2f, 0)) - projectileSpawn.position).normalized, out hit, 1000);

        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance && hit.transform.CompareTag("Player")) {
            pathfinding.isStopped = true;
            actualState = EnemyState.PreparingAttack;
        }
        else {
            actualState = EnemyState.GoingToPlayer;
            if(EnemyState.GoingToPlayer != lastState)changeAnimationState(EnemyState.GoingToPlayer);
            pathfinding.isStopped = false;
            timerAttack = 0f;
            pathfinding.destination = player.transform.position;
        }

        if (actualState == EnemyState.PreparingAttack) {
            timerAttack += Time.deltaTime;
            if (timerAttack >= attackCooldown) {
                timerAttack = 0f;
                if(EnemyState.PreparingAttack != lastState)changeAnimationState(EnemyState.PreparingAttack);
                Attack();
            }
        }
    }

    public override void TakeDamage(int value) {
        if (actualState == EnemyState.Dead)
            return;

        health -= value;
        if (health <= 0f) {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead() {

        pathfinding.isStopped = true;
        actualState = EnemyState.Dead;
    if(EnemyState.Dead != lastState)changeAnimationState(EnemyState.Dead);
        yield return new WaitForSeconds(deadTime);

        OnEnemyDead?.Invoke(transform.position);
        Destroy(this.gameObject);

        yield return null;
    }

    void Attack() {
        BulletEnemy be = Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
        animator.SetTrigger("start");
        be.SetProjectile(((player.transform.position + new Vector3(0, 1.2f, 0)) - projectileSpawn.position).normalized);

    }
    void changeAnimationState(EnemyState value)
    {
        if (animator != null) {
            animator.SetInteger("state", (int)actualState);
            lastState = actualState;
            animator.SetTrigger("start");
    }
    

}
}
