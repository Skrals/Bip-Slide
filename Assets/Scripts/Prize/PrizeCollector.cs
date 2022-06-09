using UnityEngine;

public class PrizeCollector : MonoBehaviour
{
    [field: SerializeField] public int Coins { get; private set; }
    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PrizePoint prizePoint))
        {
            if (!prizePoint.Collected)
            {
                Coins += prizePoint.GetComponentInChildren<Prize>().Reward;
                Destroy(prizePoint.gameObject);
                prizePoint.Collected = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            if(!ground.Collected)
            {
                Coins += ground.BonusCoins;
                ground.Collected = true;
            }
        }
    }
}
