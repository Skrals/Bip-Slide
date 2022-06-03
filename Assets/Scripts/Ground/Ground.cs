using UnityEngine;

public abstract class Ground : MonoBehaviour
{
   [field: SerializeField] public float DecayParameter { get; private set; }
}
