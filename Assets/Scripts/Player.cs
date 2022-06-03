using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedDecay;
    [SerializeField] private bool _finish;

    [field: SerializeField] public bool LostControl { get; private set; }

    private void FixedUpdate()
    {
        if (_finish)
        {
            return;
        }

        if(_speed<=0 && !LostControl)
        {
            LostControl = true;
        }
        
        if(LostControl)
        {
            return;
        }

        transform.position += Vector3.forward * _speed * Time.fixedDeltaTime;
        SpeedDecay();
    }

    private void SpeedDecay ()
    {
        if (_speed > 0)
        {
            _speed -= _speedDecay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Ground ground))
        {
            _speedDecay = ground.DecayParameter;
        }

        if (other.gameObject.TryGetComponent(out Finish finish))
        {
            Finish();
        }
    }

    private void Finish()
    {
        _finish = true;
        Debug.Log($"Finish");
    }
}
