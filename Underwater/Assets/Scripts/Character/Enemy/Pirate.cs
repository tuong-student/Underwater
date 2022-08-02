using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    #region Components
    Transform treasureTransform;
    Rigidbody2D rb;
    #endregion

    #region Stats
    float speed = 10f;
    Vector3 dir;
    int health = 1;
    bool isDead;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        treasureTransform = GameObject.FindGameObjectWithTag("Treasure").transform;
        rb = GetComponent<Rigidbody2D>();
        MoveToTheTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Dead();
        }

        if (isDead == true) return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer();
        }
    }

    void MoveToTheTarget()
    {
        if (isDead == true) return;
        dir = (treasureTransform.position - this.transform.position).normalized;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    void HitPlayer()
    {
        // After hit player, enemy will be push away. Then they must find dir and move to treasure again
        if (isDead) return;
        health--;
        Recover();
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(2f);
        MoveToTheTarget();
    }

    void Dead()
    {
        isDead = true;
    }
}
