using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]float maxHP = 100;
    float hp;
    private bool isBossSpawner = false;
    
    public bool isDead { get; private set; } = false;
    [SerializeField]private float attackCooldown = 1f;
    [SerializeField]private float attackRange = 1f;
    [SerializeField]private LayerMask enemyLayer; 
    Collider2D[] enemies;
    [SerializeField] int damage = 1;
    private Vector3 nextLoc = Vector3.zero;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField]private Animator animator;
    [SerializeField]private SpriteRenderer spriteRenderer;
    private CinemachineImpulseSource impulseSource;

    #region Audio
    [SerializeField]private AudioClip attackSound;
    [SerializeField]private AudioClip hurtSound;
    #endregion

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Attack());
        StartCoroutine(NextPosition());
        hp= maxHP;
    }
    

    IEnumerator Attack()
    {
        while (!isDead)
        {
            
            enemies = Physics2D.OverlapCircleAll(transform.position, attackRange,enemyLayer);
            bool enemyInRange = enemies.Length > 0;
            if (!enemyInRange)
            {
                yield return null;
                continue;
            }
            var enemyPosition = enemies[0].transform.position;
            Vector3 dir = (enemyPosition - transform.position).normalized;
            if (dir.x < 0)
                spriteRenderer.flipX = true;
            else if (dir.x > 0)
                spriteRenderer.flipX = false;
            animator.SetTrigger("IsAttack");     
            AudioSource.PlayClipAtPoint(attackSound, transform.position);   
            foreach (var enemy in enemies)
            {
                var enemyComponent = enemy.GetComponent<IEnemy>();
                if (enemyComponent != null)
                {
                    enemyComponent.TakeDamage(damage);
                }
            }
            yield return new WaitForSeconds(attackCooldown);
        }
    }

    IEnumerator NextPosition()
    {
        while (!isDead)
        {
            nextLoc = new Vector3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-4f, 4f), 0);
            nextLoc += transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.0001f);
        Vector2 direction = (nextLoc - transform.position).normalized;
        if((nextLoc - transform.position).magnitude < 0.5f)
        {
            direction = Vector2.zero;
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
            if (direction.x < 0)
                spriteRenderer.flipX = true;
            else if (direction.x > 0)
                spriteRenderer.flipX = false;
        }
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        
    }
    public void TakeDamage(int damage)
    {
        impulseSource.GenerateImpulse();
        animator.SetTrigger("IsHurt");
        AudioSource.PlayClipAtPoint(hurtSound, transform.position);
        hp -= damage;
        if (hp <= 0 && !isDead)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        GameManager.instance.Win();
        //animator.SetTrigger("IsDead");
        Destroy(this.gameObject, 1f);
    }

    public float getHP()
    { return hp; }
    public float getMaxHP()
    { return maxHP; }
}

