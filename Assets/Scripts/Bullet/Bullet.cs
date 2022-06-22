using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Action<IDamageable, int> ShotPlayer;
    [SerializeField] private int _damage;
    [SerializeField] private int _force;
    [SerializeField] private float _lifeTime;
    private Transform _container;
    private Rigidbody _rigidbody;
    private float _stayActiveTimer;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _container = transform.parent;
        _stayActiveTimer = _lifeTime;
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            _stayActiveTimer -= Time.deltaTime;
            if (_stayActiveTimer <= 0)
            { 
                DeactivateBullet();
                _stayActiveTimer = _lifeTime;
            }
        }
    }
    private void ActivateBullet()
    {
        gameObject.SetActive(true);
        transform.SetParent(null);
        transform.position = _container.position;
    }

    private void DeactivateBullet()
    {
        gameObject.SetActive(false);
        transform.SetParent(_container);
        _rigidbody.velocity = Vector3.zero;
    }

    public void Shoot(Vector3 direction)
    {
        ActivateBullet();
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Bounds bound))
        {
            DeactivateBullet();
        }

        if(other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            ShotPlayer(damageable, _damage);
        }
    }

}
