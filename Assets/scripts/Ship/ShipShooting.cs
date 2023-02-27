using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;

    [SerializeField] protected float shootingDelay = 1f;

    [SerializeField] protected float shootingTimer = 0f;

    private void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!isShooting) return;

        this.shootingTimer += Time.fixedDeltaTime;
        if (this.shootingTimer < this.shootingDelay) return;
        this.shootingTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
      //  Transform newBullet = Instantiate(this.bulletPrefab , spawnPos , rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if(newBullet == null) return;
        
        newBullet.gameObject.SetActive(true);
    
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.onFiring == 1;
        return isShooting;
    }
}
