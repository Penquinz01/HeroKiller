using UnityEngine;

public class Card : MonoBehaviour
{
    public int upgradeID;
    GameObject upgradeScreen;

    void Start()
    {
        upgradeScreen= GameObject.FindGameObjectWithTag("UpgradeScreen");
    }
    void Update()
    {
        
    }

    public void OnPointerClick()
    {
        switch (upgradeID)
        {
            case 1:
                Debug.Log("Increase Slime Health by 25%");
                break;
            case 2:
                Debug.Log("Increase Slime Damage by 25%");
                break;
            case 3:
                Debug.Log("Increase Ogre Health by 25%");
                break;
            case 4:
                Debug.Log("Increase Ogre Damage by 25%");
                break;
            case 5:
                Debug.Log("Increase Vampire Health by 25%");
                break;
            case 6:
                Debug.Log("Increase Vampire Damage by 25%");
                break;
        }
        upgradeScreen.SetActive(false);
    }
}
