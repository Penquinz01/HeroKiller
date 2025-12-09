using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 heroPos;
    Vector3 dir;
    [SerializeField] float speed = 5f;
    void Start()
    {
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform.position;
    }

    void Update()
    {
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform.position;
        dir = (heroPos - (Vector2)transform.position).normalized;
        transform.position = transform.position+(dir * speed * Time.deltaTime);
    }
}
