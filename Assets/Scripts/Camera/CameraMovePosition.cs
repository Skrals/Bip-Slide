using UnityEngine;

public class CameraMovePosition : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraPoint _start;
    [SerializeField] private CameraPoint _end;
    [SerializeField] private float _step;
    [SerializeField] private float _progress;

    [SerializeField] private PlayerControl _control;

    private void Start()
    {
        transform.position = _start.gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if(!_control.StartGame)
        {
            return;
        }

        CameraMove();
    }

    private void CameraMove()
    {
        transform.LookAt(_player.transform);
        transform.position = Vector3.Lerp(_start.transform.position, _end.transform.position, _progress);

        _progress += _step;
    }
}
