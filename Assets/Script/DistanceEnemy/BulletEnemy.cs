using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] PlayerHP player;
    [SerializeField] Vector3 direction;

    bool hitted = false;

    void Start() {
        player = FindObjectOfType<PlayerHP>();
    }

    private void OnEnable() {
        hitted = false;
    }

    void Update() {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetProjectile(Vector3 dir) {
        direction = dir;
        transform.LookAt(transform.position + direction);
    }

    private void OnTriggerEnter(Collider other) {
        if (hitted)
            return;

        if (other.CompareTag("Player")) {
            player.TakeDamage(damage);
            hitted = true;
            gameObject.SetActive(false);
        }
    }
}
