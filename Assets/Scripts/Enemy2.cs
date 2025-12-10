using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    Vector2 heroPos;
    GameObject hero;
    Vector3 dir;
    [SerializeField] float speed = 5f;
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroPos = hero.transform.position;
    }

    void Update()
    {
        heroPos = hero.transform.position;
        dir = (heroPos - (Vector2)transform.position).normalized;
        transform.position = transform.position+(dir * speed * Time.deltaTime);
    }
}
