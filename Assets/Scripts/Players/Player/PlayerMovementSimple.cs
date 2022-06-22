using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementSimple : MonoBehaviour
{
    [SerializeField] private int _speed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        var _moveInputX = Input.GetAxisRaw("Horizontal");
        var _moveInputZ = Input.GetAxisRaw("Vertical");
        var _moveDirection = new Vector3(_moveInputX, 0, _moveInputZ).normalized;
        _rigidbody.velocity = _moveDirection * _speed * Time.fixedDeltaTime;

        if (Mathf.Abs(_moveInputZ) + Mathf.Abs(_moveInputX) != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }

    }
}
