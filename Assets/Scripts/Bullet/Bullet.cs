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

    public void Shoot(Vector3 direction)
    {
        gameObject.SetActive(true);
        transform.parent = null;
        transform.position = _container.position;
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
    }

}
