using System;
using System.Collections;
using UnityEngine;

public class Hero : MonoBehaviour
{
    float hp = 100;
    private bool isBossSpawner = false;
    
    private float attackSpeed = 1f;
    private bool isDead = false;
    [SerializeField]private float attackCooldown = 1f;
    [SerializeField]private float attackRange = 1f;
    [SerializeField]private LayerMask enemyLayer; 
    private float attackTimer = 0f;
    Collider2D[] enemies;
    [SerializeField] int damage = 1;
    private Vector3 nextLoc = Vector3.zero;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        attackTimer = 0f;
        StartCoroutine(Attack());
        StartCoroutine(NextPosition());
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
}

