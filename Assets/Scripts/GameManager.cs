using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Canvas PauseCanvas;
    private float enemyCost = 10;
    private MainControls mainControls;
    [SerializeField] private Canvas canvas; 
    public bool isPaused { get; private set; } = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        mainControls = new MainControls();
        mainControls.Main.Enable();
        mainControls.Main.Pause.started += ctx => PauseUnpause();
        PauseCanvas.enabled = false;
    }

    public bool CanSpawnEnemy()
    {
        return enemyCost > 0;
    }
    public void SpendEnemyCost(float cost)
    {
        enemyCost -= cost;
        if (enemyCost < 0)
        {
            enemyCost = 0;
        }
    }
    public void ReplenishEnemyCost(float amount)
    {
        enemyCost += amount;
        if (enemyCost > 10)
        {
            enemyCost = 10;
        }
    }

    private void PauseUnpause()
    {
        PauseCanvas.enabled = !PauseCanvas.enabled;
        isPaused = PauseCanvas.enabled;
        if (PauseCanvas.enabled)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Continue()
    {
        PauseUnpause();
    }

    public void Restart()
    {
        Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Win()
    {
        canvas.enabled = true;
    }
}
