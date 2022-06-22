using System.Collections.Generic;
using UnityEngine;

public class BulletPoolController : IBulletController
{
    private List<Bullet> _bulletList;
    private BulletPool _pool;

    public BulletPoolController(Bullet bulletPrefab, Transform bulletContainer, int bulletCount)
    {
        _pool = new BulletPool(bulletPrefab, bulletContainer, bulletCount);
        Init();
    }

    private void Init()
    {
        _pool.Init();
        _bulletList = _pool.Pool;

        foreach (var bullet in _bulletList)
        {
            bullet.ShotPlayer += Hit;
        }
    }

    private void Hit(IShooter shooter)
    {
        shooter.GetPoint();
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
