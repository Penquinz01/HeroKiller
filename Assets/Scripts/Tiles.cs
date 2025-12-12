using UnityEngine;

public class Tiles : MonoBehaviour
{
    public GameObject tilePrefab;
    void Start()
    {
        for (int i = -100; i <= 100; i++)
        {
            for (int j = -100; j <= 100; j++)
            {
                if ((i + j) % 2 == 0)
                    Instantiate(tilePrefab, new Vector3(i, j, 0), Quaternion.identity, transform);
            }
        }
    }
}
