using UnityEngine;

namespace _Src.Systems.Object_Pooling.Scripts
{
    public class Projectile : MonoBehaviour
    {
        private const float TimeEnabled = 3;

        private float _timeTrack;

        private void OnEnable()
        {
            _timeTrack = TimeEnabled;
        }

        private void Update()
        {
            _timeTrack -= Time.deltaTime;

            transform.Translate(Vector3.forward * Time.deltaTime * 10);

            if (_timeTrack <= 0)
                SendBack();
        }

        private void SendBack()
        {
            ObjectPool.Instance.ReturnToPool(gameObject);
        }
    }
}