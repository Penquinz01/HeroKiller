using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float enemyCost = 10;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
}
