using UnityEngine;
public class EnemyPoints : MonoBehaviour, IShooter
{
    [SerializeField] private PointHandlerView _pointsView;
    private int _points;

    public void GetPoint()
    {
        _points++;
        _pointsView.UpdateEnemyPoints(_points);
    }

}
