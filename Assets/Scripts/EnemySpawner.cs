using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public enum EnemyType
{
    Slime,
    Ogre,
    Vampire
}
public class EnemySpawner : MonoBehaviour
{
    private Camera mainCam;
    MainControls mainControls;
    private Vector2 mousePos;
    GameObject hero;
    Vector2 heroPos;
    int totalSpawned = 0;
    int nextUpgradeAt = 5;
    GameObject upgradeCanvas;
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
    [SerializeField] private float cooldown3 = 3f;

    private EnemyType currentType;
    [SerializeField]private AudioClip spawnSound;


    private void Awake()
    {
        mainCam = Camera.main;
        mainControls = new MainControls();
        mainControls.Main.Enable();
        mainControls.Main.SpawnClick.started += OnMouseClick;
        mainControls.Main.Spawn.performed += context =>mousePos = context.ReadValue<Vector2>() ;
    }

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
       // upgradeCanvas = GameObject.FindGameObjectWithTag("UpgradeCanvas");
        heroPos = hero.transform.position;
        nextCool1 = 0f;
        nextCool2 = cooldown2;
        nextCool3 = cooldown3;
    }
    void Update()
    {
        if (hero != null) heroPos = hero.transform.position;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentType = EnemyType.Slime;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentType = EnemyType.Ogre;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentType = EnemyType.Vampire;
        }
        if (totalSpawned >= nextUpgradeAt)
        {
            totalSpawned = 0;
            nextUpgradeAt += 5;
            //upgradeCanvas.SetActive(true);
        } 
    }

    void OnMouseClick(InputAction.CallbackContext cxt)
    {
        if (!GameManager.instance.CanSpawnEnemy())
        {
            return;
        }

        if (GameManager.instance.isPaused)
        {
            return;
        }
        Vector2 position = mainCam.ScreenToWorldPoint(mousePos);
        GameObject enemyToSpawn = null;
        switch (currentType)
        {
            case EnemyType.Slime:
                enemyToSpawn = enemy1;
                break;
            case EnemyType.Ogre:
                enemyToSpawn = enemy2;
                break;
            case EnemyType.Vampire:
                enemyToSpawn = enemy3;
                break;
            default:
                break;
        }
        Instantiate(enemyToSpawn,position,Quaternion.identity);
        AudioSource.PlayClipAtPoint(spawnSound, position);
    }

    void spawnEnemy(GameObject en)
    {
        
        totalSpawned++;
        int ch = Random.Range(1, 5); // 1:left, 2:top, 3:right, 4:bottom
        switch (ch)
        {
            case 1: Instantiate(en, new Vector2(heroPos.x - xOffset, heroPos.y + Random.Range(-yOffset, yOffset)), Quaternion.identity); break; //left
            case 2: Instantiate(en, new Vector2(heroPos.x + Random.Range(-xOffset, xOffset), heroPos.y + yOffset), Quaternion.identity); break; //top
            case 3: Instantiate(en, new Vector2(heroPos.x + xOffset, heroPos.y + Random.Range(-yOffset, yOffset)), Quaternion.identity); break; //right
            case 4: Instantiate(en, new Vector2(heroPos.x + Random.Range(-xOffset, xOffset), heroPos.y - yOffset), Quaternion.identity); break; //bottom
        }
    }

    
}

