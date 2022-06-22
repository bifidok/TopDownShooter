using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [Header("View parameters")]
    [SerializeField] [Range(0, 360)] private int ViewAngle;
    [SerializeField] [Range(0, 100)] private int DetectionTargetDistance;
    [SerializeField] [Range(0, 10)] private int MinDistanceToDetectTarget;

    [Header("Shoot parameters")]
    [SerializeField] private int _bulletCount;
    [SerializeField] private Bullet _bulletPrefab;

    [Header("Other")]
    [SerializeField] private int _speed;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform[] _patrolPoints;
    private NavMeshAgent _navMesh;
    private StateMachine _stateMachine;
    private State _currentState;
    private IBulletController _bulletPool;

    private void Start()
    {
        Init();
        _bulletPool = new BulletPoolController(_bulletPrefab, transform, _bulletCount);
    }

    private void Init()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _stateMachine = new StateMachine();
        _navMesh.speed = _speed;
        _stateMachine.Init(new PatrolState(_navMesh, _patrolPoints));
        _currentState = _stateMachine.CurrentState;
    }
    private void Update()
    {

        if(IsTargetInView() && _currentState.ToString() == nameof(PatrolState))
        {
            var nextState = new AttackState(_navMesh, _target, transform, _bulletPool);
            _stateMachine.ChangeState(nextState);
            _currentState = nextState;
            return;
        }

        if(!IsTargetInView() && _currentState.ToString() == nameof(AttackState))
        {
            var nextState = new PatrolState(_navMesh, _patrolPoints);
            _stateMachine.ChangeState(nextState);
            _currentState = nextState;
            return;
        }
        _currentState.Update();

    }
    private bool IsTargetInView()
    {
        var targetInViewAngle = Vector3.Angle(transform.forward, _target.position - transform.position);
        var distanceToTarget = Vector3.Distance(transform.position, _target.position);
        if (Physics.Raycast(transform.position, _target.position - transform.position, out RaycastHit hit, DetectionTargetDistance))
        {
            if(targetInViewAngle <  ViewAngle / 2f && distanceToTarget < DetectionTargetDistance)
            {
                return true;
            }
        }

        if (distanceToTarget < MinDistanceToDetectTarget) return true;

        return false;
    }
}
