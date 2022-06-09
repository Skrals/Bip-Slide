using System;
using UnityEngine;

public class PrizeCollector : MonoBehaviour
{
    [field: SerializeField] public int Coins { get; private set; }
    [SerializeField] private Player _player;

    private void OnEnable() => _player._collision += PickPrize;

    private void OnDisable() => _player._collision -= PickPrize;

    private void PickPrize(Collider collider)
    {
        try
        {
            var prize = collider.GetComponentInChildren<Prize>();

            Coins += prize.Reward;

            Destroy(prize.gameObject);
        }
        catch (NullReferenceException exception)
        { 
            Debug.LogError(exception.Message);
        }
    }
}
