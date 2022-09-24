using UnityEngine;

namespace BoomBoom
{
    public class Boom : MonoBehaviour
    {
        void Start()
        {
            Invoke(nameof(DoBoom),3f);
        }

        private void DoBoom()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 25.0f);
        
            foreach(var iter in hitColliders)
            {
                var rigidBody = iter.GetComponent<Rigidbody>();
            
                if(rigidBody != null)
                {
                    rigidBody.AddExplosionForce(8500.0f, transform.position, 30.0f, 15.0f);
                }
            }
            Destroy(this.gameObject);
        }
    }
}

