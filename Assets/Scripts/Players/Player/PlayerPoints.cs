using UnityEngine;

public class PlayerPoints : MonoBehaviour, IShooter
{
    [SerializeField] private PointHandlerView _pointsView;
    private int _points;

    public void GetPoint()
    {
        _points++;
        _pointsView.UpdatePlayerPoints(_points);
    }
}
