using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    System.Random _random = new System.Random();

    [Header("Ground settings")]
    [SerializeField] private int _groundsAmount;
    [SerializeField] private Ground[] _groundsTemplates;

    [Header("Start and Finish templates")]
    [SerializeField] private Finish _finishTemplate;
    [SerializeField] private StartGround _startTemplate;

    [Header("Bonus settings")]
    [SerializeField] private Bonus bonusTemplate;
    [SerializeField] private BonusPoint[] _bonusPoints;
    [SerializeField] private Vector2 _randomStep;
    [SerializeField] private int _bonusSpawnStep;

    private void Start()
    {
        _bonusPoints = GetComponentsInChildren<BonusPoint>();
        GenerateLevel(_groundsTemplates, _groundsAmount);
    }

    private void GenerateLevel(Ground[] groundsArray, int amount)
    {
        GroundSpawn(_startTemplate);

        for (int i = 0; i <= amount; i++)
        {
            if (_bonusSpawnStep == 0)
            {
                BonusSpawn(bonusTemplate);
                _bonusSpawnStep = _random.Next((int)_randomStep.x, (int)_randomStep.y);
            }

            GroundSpawn(groundsArray[_random.Next(groundsArray.Length)]);
            _bonusSpawnStep--;
        }

        GroundSpawn(_finishTemplate);
    }

    private void GroundSpawn(Ground ground)
    {
        var current = Instantiate(ground, transform.position, Quaternion.identity);
        transform.position += new Vector3(0, 0, current.transform.localScale.z);
    }

    private void BonusSpawn(Bonus bonus)
    {
        var point = _bonusPoints[_random.Next(_bonusPoints.Length)];
        Instantiate(bonus, new Vector3(point.gameObject.transform.position.x, 0.5f, point.gameObject.transform.position.z), Quaternion.identity);
    }
}
