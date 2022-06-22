using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int _bulletCount;
    [SerializeField] private Bullet _bulletPrefab;
    private IBulletController _bulletController;

    private void Start()
    {
        _bulletController = new BulletPoolController(_bulletPrefab, transform, _bulletCount);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _bulletController.GetAnyBullet(transform.forward);
        }
    }
}
