using UnityEngine;

public class HP : MonoBehaviour
{
    Hero hero;
    float percent;
    RectTransform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void Start()
    {
        hero = Object.FindAnyObjectByType<Hero>();
    }

    void Update()
    {
        percent = hero.getHP() / hero.getMaxHP();
        percent = Mathf.Clamp01(percent);
        float current = rt.localScale.x;
        float target = percent;
        rt.localScale = new Vector3(Mathf.Lerp(current,target, 10f*Time.deltaTime),1f,1f);
    }
}
