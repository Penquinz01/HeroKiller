using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 heroPos;
    [SerializeField] float speed = 5f;
    void Start()
    {
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform.position;
    }

    void Update()
    {
        
    }
}
