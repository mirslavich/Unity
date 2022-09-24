using GlobalEventManager;
using TMPro;
using UnityEngine;

public class Field : MonoBehaviour
{
    void Start()
    {
        GlobalEventMagager.WeaponInHand += GetWeaponInHand;
    }

    void GetWeaponInHand(GameObject someGameObject)
    {
        GetComponent<TextMeshProUGUI>().text = someGameObject.name;
    }

    
}
