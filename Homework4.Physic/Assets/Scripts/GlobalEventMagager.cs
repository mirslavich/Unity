using System;
using UnityEngine;

namespace GlobalEventManager
{
    public class GlobalEventMagager
    { 
        public static Action<GameObject> WeaponInHand;

        public static void SendNameWeapon(GameObject someGameObject)
        {
            if (WeaponInHand != null)
            {
                WeaponInHand.Invoke(someGameObject);
            }
        }
    }
}

    
