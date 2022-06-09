using UnityEngine;

public abstract class Ground : MonoBehaviour
{
    [SerializeField] private PrizePoint _prizePoint;
    [field: SerializeField] public float DecayParameter { get; private set; }
    [field: SerializeField] public int BonusCoins { get; private set; }
    [field: SerializeField] public bool Collected { get; set; }
}