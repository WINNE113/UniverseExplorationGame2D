using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : GeneralMonobehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;

        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);

    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
     

       Transform prefabObj = transform.Find("Prefabs");
       foreach (Transform prefab in prefabObj)
        {
               this.prefabs.Add(prefab);
        }
       this.HidePrefebs();

        Debug.Log(transform.name + "Load prefabs" , gameObject);
    }

    protected virtual void HidePrefebs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName , Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);

        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found! " + prefabName);
        }

        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        return newPrefab;
    }

    /// <summary>
    /// if prefab have in list poolObj return it's
    /// else if prefab don't hava in poolObj, create new prefab
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                Debug.Log("Prefab Name is: " + prefab.name);
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }



    /// <summary>
    /// ??a nh?ng viên ??n b? h?y vào pool ?? có th? tái s? d?ng
    /// </summary>
    /// <param name="obj"></param>
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName)
            {
                return prefab;
            }
           
        }
        return null;
    }

}
