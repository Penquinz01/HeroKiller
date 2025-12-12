using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    Vector2 heroPos;
    GameObject hero;
    Vector3 dir;
    [SerializeField] float speed = 5f;
    [SerializeField]int health = 3;
    [SerializeField] float knockbackForce = 5;
    private Rigidbody2D rb;
    private bool isKnocking = false;
    [SerializeField] private float knockbackDuration = 0.3f;
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroPos = hero.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        heroPos = hero.transform.position;
        dir = (heroPos - (Vector2)transform.position).normalized;
        if (!isKnocking)
        {
            rb.linearVelocity = dir * speed;
        }
    }

    public void TakeDamage(int damage)
    {
        KnockBack();
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Mathf.Abs((hero.transform.position - transform.position).magnitude) > 30f)
        {
            Die();
        }
    }

    public void KnockBack()
    {
        rb.linearVelocity = Vector2.zero;
        Vector2 knockbackDir = (Vector2)(transform.position - hero.transform.position).normalized;
        rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(KnockBacking());
    }

    IEnumerator KnockBacking()
    {
        isKnocking = true;
        yield return new WaitForSecondsRealtime(knockbackDuration);
        isKnocking = false;
    }
}
