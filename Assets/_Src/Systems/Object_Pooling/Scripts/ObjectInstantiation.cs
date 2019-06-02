using UnityEngine;

namespace Assets._Src.Systems.Object_Pooling.Scripts
{
    public class ObjectInstantiation : MonoBehaviour
    {
        [SerializeField]private GameObject firePoint = null;

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