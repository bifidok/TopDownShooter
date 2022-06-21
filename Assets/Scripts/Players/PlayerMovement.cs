using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    private Camera _camera;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }
    private void FixedUpdate()
    {

        MovementLogic();
        RotateTowardMouse();

    }

    private void MovementLogic()
    {
        var _moveInputX = Input.GetAxisRaw("Horizontal");
        var _moveInputZ = Input.GetAxisRaw("Vertical"); 
        var _moveDirection = new Vector3(_moveInputX, 0, _moveInputZ).normalized;
        _rigidbody.velocity = _moveDirection * _speed * Time.fixedDeltaTime;
    }

    private void RotateTowardMouse()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            var lookDirection = hit.point;
            lookDirection.y = transform.position.y;
            transform.LookAt(lookDirection);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Bounds bound))
        {
            Debug.Log("Die");
        }
    }

}
