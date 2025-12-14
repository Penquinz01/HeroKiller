using UnityEngine;

public class CP : MonoBehaviour
{
    GameManager gm;
    float percent;
    RectTransform rt;

    private void Awake()
    {
        rt=GetComponent<RectTransform>();
    }

    void Start()
    {
        gm= Object.FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        float current = rt.localScale.x;
        float target;
        if (gm.getEnemyCost()<=0f)
        {
            rt.localScale = new Vector3(Mathf.Lerp(current,0f,10f*Time.deltaTime),1f,1f);
            return;
        }
        percent = gm.getEnemyCost() / gm.getMaxEnemyCost();
        target = percent;
        rt.localScale = new Vector3(Mathf.Lerp(current, target, 10f * Time.deltaTime), 1f, 1f);
    }
}
