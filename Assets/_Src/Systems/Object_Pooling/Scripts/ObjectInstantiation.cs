using UnityEngine;

namespace _Src.Systems.Object_Pooling.Scripts
{
    public class ObjectInstantiation : MonoBehaviour
    {
        [SerializeField]private GameObject firePoint = null;
        [SerializeField]private Projectile proj = null;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var bullet = ObjectPool.Instance.GetPooledObject("Bullet");

                bullet.transform.position = firePoint.transform.position;
                bullet.transform.rotation = firePoint.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }
}