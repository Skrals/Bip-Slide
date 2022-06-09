using UnityEngine;

public abstract class Ground : MonoBehaviour
{
    [SerializeField] private PrizePoint _prizePoint;
    [field: SerializeField] public float DecayParameter { get; private set; }
}
