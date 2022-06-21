using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    public List<Bullet> Pool { get; private set; }
    private Transform _container;
    private Bullet _prefab;
    private int _bulletCount;

    public BulletPool(Bullet prefab, Transform container, int bulletCount)
    {
        _prefab = prefab;
        _container = container;
        _bulletCount = bulletCount;
    }

    public void Init()
    {
        Pool = new List<Bullet>();
        CreatePool(_bulletCount);
    }

    private void CreatePool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Pool.Add(CreateNewBullet());
        }
    }

    private Bullet CreateNewBullet()
    {
        var bullet = GameObject.Instantiate(_prefab,_container);
        bullet.gameObject.SetActive(false);
        return bullet;
    }
}
