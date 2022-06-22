using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private const float _minDistanceToSetDestination = 1;
    private NavMeshAgent _navMesh;
    private Transform[] _patrolPoints;
    private Vector3 _nextPatrolPoint;

    public PatrolState(NavMeshAgent navMesh, Transform [] patrolPoints)
    {
        _navMesh = navMesh;
        _patrolPoints = patrolPoints;
    }
    public override void Enter()
    {
        _navMesh.Resume();
        var destionation = GetRandomDestionation();
        _navMesh.SetDestination(destionation);
    }

    public override void Exit()
    {
        _navMesh.Stop();
    }


    private Vector3 GetRandomDestionation()
    {

        _nextPatrolPoint = _patrolPoints[Random.Range(0, _patrolPoints.Length - 1)].position;
        return _nextPatrolPoint;
    }

    public override void Update()
    {
        if(Vector3.Distance(_navMesh.pathEndPosition, _navMesh.transform.position) < _minDistanceToSetDestination)
        {
            var destionation = GetRandomDestionation();
            _navMesh.SetDestination(destionation);
        }
    }
}
