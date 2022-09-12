using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    #region Components
    Transform treasureTransform;
    Rigidbody2D rb;
    [SerializeField] GameObject healthCubePref;
    [SerializeField] GameObject healthZone;
    #endregion

    #region Stats
    float speed = 30f;
    Vector3 dir;
    int health = 3;
    bool isDead;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        healthCubePref.SetActive(false);
        isDead = false;
        treasureTransform = GameObject.FindGameObjectWithTag("Treasure").transform;
        rb = GetComponent<Rigidbody2D>();
        MoveToTheTarget();
        SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.health <= 0)
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
            RemoveHealth(1);
        }

        if (collision.gameObject.CompareTag("Treasure"))
        {
            //GameManager.InsGameManager.isReachTreasure = true;
            //Destroy(collision.gameObject);
        }
    }

    void SetHealth(int healAmount)
    {
        for(int i = 0; i < healAmount; i++)
        {
            Instantiate(healthCubePref, healthCubePref.transform.parent);
        }
    }

    void RemoveHealth(int healAmount)
    {
        for(int i = 0; i < healAmount; i++)
        {
            Destroy(healthZone.transform.GetChild(0).gameObject);
            this.health -= 1;
        }
    }

    void MoveToTheTarget()
    {
        if (isDead == true) return;
        rb.velocity = Vector3.zero;
        dir = (treasureTransform.position - this.transform.position).normalized;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    void HitPlayer()
    {
        // After hit player, enemy will be push away. Then they must find dir and move to treasure again
        if (isDead) return;
        health--;
        StartCoroutine(Recover());
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        MoveToTheTarget();
    }

    void Dead()
    {
        isDead = true;
        NOOD.NoodyCustomCode.FadeDown(GetComponent<SpriteRenderer>(), 1);
    }
}
