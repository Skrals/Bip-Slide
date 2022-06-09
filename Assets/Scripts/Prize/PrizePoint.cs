using UnityEngine;

public class PrizePoint : MonoBehaviour
{
    [SerializeField] private Prize[] _prizes;

    private void Start()
    {
        System.Random random = new System.Random();
        var prize = Instantiate(_prizes[random.Next(_prizes.Length)], transform.position, Quaternion.identity);
        prize.transform.parent = transform;
    }
}
