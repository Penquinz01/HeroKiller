using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    GameObject card1, card2, card3;
    Text up1, up2, up3;
    Card cd1, cd2, cd3;
    string[] upgrades = {
        "Increase Slime Health by 25%", //0,1
        "Increase Slime Damage by 25%",
        "Increase Ogre Health by 25%",  //2,3
        "Increase Ogre Damage by 25%",
        "Increase Vampire Health by 25%", //3,4
        "Increase Vampire Damage by 25%"
    };
    public bool canReset = false;

    string[] currentUpgrades = new string[3];
    
    void Start()
    {
        card1= transform.GetChild(0).gameObject;
        card2= transform.GetChild(1).gameObject;
        card3= transform.GetChild(2).gameObject;
        cd1 = card1.GetComponent<Card>();
        cd2 = card2.GetComponent<Card>();
        cd3 = card3.GetComponent<Card>();
        up1=card1.transform.GetChild(0).GetComponent<Text>();
        up2=card2.transform.GetChild(0).GetComponent<Text>();
        up3=card3.transform.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        if (canReset)
        { ResetCards(); SetUpgradeCards(); }
    }

    [ContextMenu("Set Upgrade Cards")]
    void SetUpgradeCards()
    {
        int x, y, z;
        x=Random.Range(0, upgrades.Length);
        currentUpgrades[0]=upgrades[x];
        do { y = Random.Range(0, upgrades.Length); } while (y==x);
        currentUpgrades[1]=upgrades[y];
        do { z = Random.Range(0, upgrades.Length); } while (z==x || z==y);
        currentUpgrades[2]=upgrades[z];

        cd1.upgradeID=x; cd2.upgradeID=y; cd3.upgradeID=z;
        up1.text=currentUpgrades[0];
        up2.text=currentUpgrades[1];
        up3.text=currentUpgrades[2];
        canReset = false;
    }

    [ContextMenu("Reset Upgrade Cards")]
    void ResetCards()
    {
        for (int i = 0; i < 3; i++)
        { currentUpgrades[i] = ""; }
        up1.text = "";
        up2.text = "";
        up3.text = "";
        cd1.upgradeID = -1;
        cd2.upgradeID = -1;
        cd2.upgradeID = -1;
    }

}
