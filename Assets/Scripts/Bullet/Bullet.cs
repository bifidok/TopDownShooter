using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _force;
    [SerializeField] private float _lifeTime;
    private Transform _container;
    private Rigidbody _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _container = transform.parent;
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
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
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
    }

}
