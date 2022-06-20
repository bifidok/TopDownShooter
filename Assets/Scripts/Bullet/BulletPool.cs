using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Transform _container;
    private Bullet _prefab;
    private List<Bullet> _pool;
    private int _bulletCount;

    public BulletPool(Bullet prefab, Transform container, int bulletCount)
    {
        _prefab = prefab;
        _container = container;
        _bulletCount = bulletCount;
    }

    public List<Bullet> Init()
    {
        _pool = new List<Bullet>();
        CreatePool(_bulletCount);
        return _pool;
    }

    private void CreatePool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _pool.Add(CreateNewBullet());
        }
    }

    private Bullet CreateNewBullet()
    {
        var bullet = GameObject.Instantiate(_prefab,_container);
        bullet.gameObject.SetActive(false);
        return bullet;
    }
}
