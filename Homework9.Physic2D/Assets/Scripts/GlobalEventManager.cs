using UnityEngine.Events;

namespace DefaultNamespace
{
    public class GlobalEventManager
    {
        public static UnityEvent<bool> OnFruitTaked=new UnityEvent<bool>();
        public static UnityEvent<int> OnDamage = new UnityEvent<int>();
        public static UnityEvent<bool> OnDead = new UnityEvent<bool>();

        public static void SendLivesAdded()
        {
            OnFruitTaked.Invoke(true);
        }

        public static void GetDamage(int demage)
        {
            OnDamage.Invoke(demage);
        }

        public static void SendDead(bool isDead)
        {
            OnDead.Invoke(isDead);
        }

    }
}