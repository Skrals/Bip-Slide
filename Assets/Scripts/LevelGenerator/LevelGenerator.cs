using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Ground[] _groundsTemplates;
    [SerializeField] private Finish _finishTemplate;
    [SerializeField] private StartGround _startTemplate;
    [SerializeField] private int _groundsAmount;

    private void Start()
    {
        GenerateLevel(_groundsTemplates, _groundsAmount);
    }

    private void GenerateLevel(Ground[] groundsArray, int amount)
    {
        System.Random random = new System.Random();
        GroundSpawn(_startTemplate);

        for (int i = 0; i <= amount; i++)
        {
            GroundSpawn(groundsArray[random.Next(groundsArray.Length)]);
        }

        GroundSpawn(_finishTemplate);
    }

    private void GroundSpawn(Ground ground)
    {
        var current = Instantiate(ground, transform.position, Quaternion.identity);
        transform.position += new Vector3(0, 0, current.transform.localScale.z);
    }
}
