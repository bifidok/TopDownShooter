using TMPro;
using UnityEngine;

public class PointHandlerView : MonoBehaviour
{
    private TMP_Text _pointsText;
    private int _playerPoints;
    private int _enemyPoints;

    private void Start()
    {
        _pointsText = GetComponent<TMP_Text>();
        _pointsText.text = $"{_playerPoints} : {_enemyPoints}";
    }

    private void UpdateScore()
    {
        _pointsText.text = $"{_playerPoints} : {_enemyPoints}";
    }

    public void UpdatePlayerPoints(int points)
    {
        _enemyPoints = points;
        UpdateScore();
    }
    public void UpdateEnemyPoints(int points)
    {
        _playerPoints = points;
        UpdateScore();
    }
}
