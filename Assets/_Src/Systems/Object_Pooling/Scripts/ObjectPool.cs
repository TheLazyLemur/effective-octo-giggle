using System.Collections.Generic;
using UnityEngine;

namespace _Src.Systems.Object_Pooling.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;

        public List<GameObject> pooledObjects;
        public List<ObjectPoolItem> itemsToPool;


        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            pooledObjects = new List<GameObject>();

            foreach (var item in itemsToPool)
            {
                for (var i = 0; i < item.amountToPool; i++)
                {
                    var obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                }
            }
        }

        public GameObject GetPooledObject(string tag)
        {
            foreach (var t in pooledObjects)
            {
                
                if (!t.activeInHierarchy && t.CompareTag(tag))
                {
                    return t;
                }
            }

            foreach (var item in itemsToPool)
            {
                if (!item.objectToPool.CompareTag(tag)) continue;

                if (!item.shouldExpand) continue;
                
                var obj = Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }

            return null;
        }

        public void ReturnToPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }


    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public int amountToPool;
        public bool shouldExpand = true;
    }
}