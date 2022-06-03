using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Ground[] _groundsTemplates;
    [SerializeField] private int _groundsAmount;

    private void Start()
    {
        GenerateLevel(_groundsTemplates,_groundsAmount);
    }

    private void GenerateLevel(Ground[] groundsArray, int amount )
    {

    }

    private void GroundSpawn(Ground ground)
    {
        
    }
}
