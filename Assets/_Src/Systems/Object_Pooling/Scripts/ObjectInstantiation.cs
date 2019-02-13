using UnityEngine;

namespace _Src.Systems.Object_Pooling.Scripts
{
    public class ObjectInstantiation : MonoBehaviour
    {
        [SerializeField] private GameObject firePoint;
        [SerializeField]private Projectile proj;

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