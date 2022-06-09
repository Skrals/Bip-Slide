using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _playerTemplate;
    [SerializeField] private float _sensitivity;

    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Moved && !_playerTemplate.LostControl && !_playerTemplate.IsFinish)
            {
                Vector2 delta = Input.touches[0].deltaPosition;

                _playerTemplate.transform.position += new Vector3(delta.x, 0, 0) * Time.deltaTime * _sensitivity;
            }
        }
    }
}



