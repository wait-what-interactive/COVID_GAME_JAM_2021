using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class CloudPool
{
    List<GameObject> _objectsPool;

    GameObject _prefab;

    public CloudPool(int startSize, GameObject prefab)
    {
        _prefab = prefab;

        _objectsPool = new List<GameObject>();

        for (int i = 0; i < startSize; ++i)
            AddObject(InstantiateNewObject());
    }

    GameObject InstantiateNewObject()
    {
        GameObject gameObject = GameObject.Instantiate(_prefab);

        gameObject.GetComponent<NuclearCloud>().SetAction(AddObject);

        return gameObject;
    }

    public void AddObject(GameObject gameObject)
    {
        gameObject.SetActive(false);

        _objectsPool.Add(gameObject);
    }

    public GameObject GetObject()
    {
        if (_objectsPool.Count == 0)
        {
            return InstantiateNewObject();
        }
        GameObject gameObject;

        gameObject = _objectsPool[0];
        gameObject.SetActive(true);

        _objectsPool.RemoveAt(0);

        return gameObject;
    }
}