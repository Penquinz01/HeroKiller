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
    [SerializeField] int nextUpgradeAt = 15;

    [SerializeField] GameObject upgradeCanvas;
    GameObject upManager;
    //enemy type 1
    [SerializeField] GameObject enemy1;


    //enemy type 2
    [SerializeField] GameObject enemy2;

    //enemy type 3
    [SerializeField] GameObject enemy3;

    private EnemyType currentType;
    [SerializeField] private AudioClip spawnSound;


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
            nextUpgradeAt += 10;
            upgradeCanvas.SetActive(true);
            upManager=upgradeCanvas.transform.GetChild(2).gameObject;
            upManager.GetComponent<UpgradeManager>().canReset = true;
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
        totalSpawned++;
    }
    
}

