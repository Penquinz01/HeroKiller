using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    Image[] keys;
    Color half, full;
    void Start()
    {
        keys = GetComponentsInChildren<Image>(true);
        half = keys[0].color;
        full = keys[0].color;
        half.a = 0.15f;
        full.a = 1f;
        keys[0].color = full;
        keys[1].color = half;
        keys[2].color = half;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            keys[0].color = full;
            keys[1].color = half;
            keys[2].color = half;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            keys[0].color = half;
            keys[1].color = full;
            keys[2].color = half;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            keys[0].color = half;
            keys[1].color = half;
            keys[2].color = full;
        }
    }
}
