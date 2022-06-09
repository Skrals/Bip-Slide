using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Player _playerTemplate;
    [SerializeField] private float _sensitivity;
    [field: SerializeField] public bool StartGame { get; private set; } 
    [SerializeField] private TapPanel _tapPanel;

    private void Start()
    {
        _tapPanel = FindObjectOfType<TapPanel>();
    }

    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            if(!StartGame)
            {
                StartGame = true;
                _tapPanel.gameObject.SetActive(false);
            }

            if (Input.touches[0].phase == TouchPhase.Moved && !_playerTemplate.LostControl && !_playerTemplate.IsFinish)
            {
                Vector2 delta = Input.touches[0].deltaPosition;

                _playerTemplate.transform.position += new Vector3(delta.x, 0, 0) * Time.deltaTime * _sensitivity;
            }
        }
    }
}