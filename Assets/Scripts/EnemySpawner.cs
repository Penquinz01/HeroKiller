using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject hero;
    Vector2 heroPos;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    //enemy type 1
    float nextCool1, nextCool2, nextCool3;
    [SerializeField] GameObject enemy1;
    [SerializeField] int enemyCount1 = 3;
    [SerializeField] float cooldown1 = 3f;
    //enemy type 2
    [SerializeField] GameObject enemy2;
    [SerializeField] int enemyCount2 = 3;
    [SerializeField] float cooldown2 = 3f;
    //enemy type 3
    [SerializeField] GameObject enemy3;
    [SerializeField] int enemyCount3 = 3;
    [SerializeField] float cooldown3 = 3f;


    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroPos = hero.transform.position;
        nextCool1 = 0f;
        nextCool2 = cooldown2;
        nextCool3 = cooldown3;
    }
    void Update()
    {
        heroPos = hero.transform.position;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Time.time >= nextCool1)
            {
                for (int i = 0; i < enemyCount1; i++)
                {
                    spawnEnemy();
                }
                nextCool1 = Time.time + cooldown1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Time.time >= nextCool2)
            {
                for (int i = 0; i < enemyCount2; i++)
                {
                    spawnEnemy();
                }
                nextCool2 = Time.time + cooldown2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Time.time >= nextCool3)
            {
                for (int i = 0; i < enemyCount3; i++)
                {
                    spawnEnemy();
                }
                nextCool3 = Time.time + cooldown3;
            }
        }
    }

    void spawnEnemy()
    {
        int ch = Random.Range(1, 5); // 1:left, 2:top, 3:right, 4:bottom
        switch (ch)
        {
            case 1: Instantiate(enemy1, new Vector2(heroPos.x - xOffset, heroPos.y + Random.Range(-yOffset, yOffset)), Quaternion.identity); break; //left
            case 2: Instantiate(enemy1, new Vector2(heroPos.x + Random.Range(-xOffset, xOffset), heroPos.y + yOffset), Quaternion.identity); break;  //top
            case 3: Instantiate(enemy1, new Vector2(heroPos.x + xOffset, heroPos.y + Random.Range(-yOffset, yOffset)), Quaternion.identity); break; //right
            case 4: Instantiate(enemy1, new Vector2(heroPos.x + Random.Range(-xOffset, xOffset), heroPos.y - yOffset), Quaternion.identity); break; //bottom
        }
    }
}
