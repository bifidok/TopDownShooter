using System.Collections.Generic;
using UnityEngine;

public class BulletPoolController : IBullet
{
    private List<Bullet> _bulletList;
    private BulletPool _pool;

    public BulletPoolController(Bullet bulletPrefab, Transform bulletContainer, int bulletCount)
    {
        _pool = new BulletPool(bulletPrefab, bulletContainer, bulletCount);
        _pool.Init();
        _bulletList = _pool.Pool;
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
