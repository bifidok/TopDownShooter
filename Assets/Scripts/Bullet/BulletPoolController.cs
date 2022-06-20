using System.Collections.Generic;
using UnityEngine;

public class BulletPoolController : IBullet
{
    private List<Bullet> _bulletList;

    public BulletPoolController(Bullet bulletPrefab, Transform bulletContainer, int bulletCount)
    {
        BulletPool pool = new BulletPool(bulletPrefab, bulletContainer, bulletCount);
        _bulletList = pool.Init();
    }

    public void GetAnyBullet(Vector3 bulletMoveDirection)
    {
        foreach (var bullet in _bulletList)
        {
            if(!bullet.gameObject.activeInHierarchy)
            {
                bullet.Shoot(bulletMoveDirection);
                return;
            }
        }
    }
}
