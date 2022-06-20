using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;
    [SerializeField] private Transform _player; 

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = _player.transform.position;
        transform.localPosition += _offsetPosition;
        var lookAtPoint = _player.position + _offsetRotation;
        transform.LookAt(lookAtPoint);
    }
}
