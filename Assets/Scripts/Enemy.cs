using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    Vector2 heroPos;
    GameObject hero;
    Vector3 dir;
    [SerializeField][Range(0.1f,2f)]private float attackCooldown = 2f;
    [SerializeField][Range(0.5f,2f)] private float attackRange = 1f;
    private float attackTimer = 0;
    private Hero heroScript;
    [SerializeField] float speed = 5f;
    [SerializeField]int health = 3;
    [SerializeField] float knockbackForce = 5;
    private Rigidbody2D rb;
    private bool isKnocking = false;
    [SerializeField] int damage = 1;
    [SerializeField] private float knockbackDuration = 0.3f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool isEnded = false;
    [SerializeField]private float cost;
    void Start()
    {
        GameManager.instance.SpendEnemyCost(cost);
        attackTimer = 0;
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroScript = hero.gameObject.GetComponent<Hero>();
        heroPos = hero.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.0001f);
        if (isEnded)
        {
            return;
        }
        heroPos = hero.transform.position;
        dir = (heroPos - (Vector2)transform.position).normalized;
        if (!isKnocking)
        {
            rb.linearVelocity = dir * speed;   
            animator.SetBool("IsWalking", true);
            if (dir.x < 0)
                spriteRenderer.flipX = true;
            else if (dir.x > 0)
                spriteRenderer.flipX = false;
        }
    }

    public void TakeDamage(int damage)
    {
        KnockBack();
        animator.SetTrigger("IsHurt");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject, 0.5f);
        GameManager.instance.ReplenishEnemyCost(cost);
    }

    private void Update()
    {
        if (isEnded)
        {
            return;
        }
        if (hero == null)
        {
            isEnded = true;
            return;
        }
        if (Mathf.Abs((hero.transform.position - transform.position).magnitude) > 30f)
        {
            Die();
        }

        if (Vector3.Distance(transform.position, hero.transform.position) <= attackRange && Time.time > attackTimer)
        {
            attackTimer = Time.time + attackCooldown;
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger("IsAttack");
        heroScript.TakeDamage(damage);
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
