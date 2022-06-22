using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    private const float _stopChaseDistance = 4f;
    private const float _continuouslyChaseDistance = 1f; // Agent stops for a second if reaches pathEndPosition while chase
    private const float _attackDistance = 15f;
    private const float _shootDelay = 1f;
    private NavMeshAgent _navMesh;
    private Transform _target;
    private Transform _transform;
    private IBulletController _bulletPool;
    private float _timer;
    public AttackState(NavMeshAgent navMesh, Transform target, Transform transform, IBulletController bulletPool)
    {
        _navMesh = navMesh;
        _target = target;
        _transform = transform;
        _bulletPool = bulletPool;
    }
    public override void Enter()
    {
        _navMesh.Resume();
        _navMesh.SetDestination(_target.position);
        Chase();
    }

    public override void Exit()
    {
        _navMesh.Stop();
    }

    private void Chase()
    {
        _transform.LookAt(_target);

        if (Vector3.Distance(_navMesh.transform.position, _navMesh.pathEndPosition) < _continuouslyChaseDistance)
        {
            _navMesh.SetDestination(_target.position);
        }
    }
    private void Attack()
    {
        if(Physics.Raycast(_transform.position, _transform.forward, out RaycastHit hit, _attackDistance/2))
        {
            if(Vector3.Distance(hit.point, _target.position) < _stopChaseDistance)
            {
                _bulletPool.GetAnyBullet(_transform.forward);
                _timer = _shootDelay;
            }
        }
    }

    public override void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            Attack();
        }

        if(Vector3.Distance(_navMesh.transform.position, _target.position) <= _stopChaseDistance)
        {
            if(_navMesh.isStopped == false) _navMesh.Stop();
            _transform.LookAt(new Vector3(_target.position.x, _transform.position.y, _target.position.z));
            return;
        }

        if (_navMesh.isStopped == true)
        {
            _navMesh.Resume();
            _navMesh.SetDestination(_target.position);
        }
        Chase();

    }
}
