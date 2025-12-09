using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Vector2 heroPos;
    [SerializeField] GameObject enemy;
    [SerializeField] int enemyCount = 3;
    [SerializeField] float cooldown = 3f;
    [SerializeField] float nextCool;
    [SerializeField] float timer;

    void Start()
    {
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform.position;
        nextCool = 0f;
    }
    void Update()
    {
        timer=Time.time;
        heroPos = GameObject.FindGameObjectWithTag("Hero").transform.position;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Time.time >= nextCool)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    int ch = Random.Range(1, 5); // 1:left, 2:top, 3:right, 4:bottom
                    switch (ch)
                    {
                        case 1: Instantiate(enemy, new Vector2(heroPos.x - 7f, heroPos.y + Random.Range(-4f, 4f)), Quaternion.identity); break; //left
                        case 2: Instantiate(enemy, new Vector2(heroPos.x + Random.Range(-7f, 7f), heroPos.y + 4f), Quaternion.identity); break;  //top
                        case 3: Instantiate(enemy, new Vector2(heroPos.x + 7f, heroPos.y + Random.Range(-4f, 4f)), Quaternion.identity); break; //right
                        case 4: Instantiate(enemy, new Vector2(heroPos.x + Random.Range(-7f, 7f), heroPos.y - 4f), Quaternion.identity); break; //bottom
                    }
                }
                nextCool = Time.time + cooldown;
            }
        }
    }
}
