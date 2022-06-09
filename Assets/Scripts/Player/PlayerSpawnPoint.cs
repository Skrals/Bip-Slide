using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private Player _playerTemplate;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_playerTemplate,transform.position,Quaternion.identity);
    }
}
