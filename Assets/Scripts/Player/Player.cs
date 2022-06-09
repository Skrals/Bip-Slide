using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedDecay;
    [field: SerializeField] public bool IsFinish { get; private set; }
    [field: SerializeField] public bool LostControl { get; private set; }

    public event UnityAction<Collider> _collision;

    private Rigidbody _rigidbody;
    //private Animator _animator;

    private void Start()
    {
        //_animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (IsFinish)
        {
            return;
        }

        if (_speed <= 0 && !LostControl)
        {
            LostControl = true;
        }

        if (LostControl)
        {
            return;
        }

        transform.position += Vector3.forward * _speed * Time.fixedDeltaTime;
        //_animator.SetFloat("RunSpeed", _speed);
        SpeedDecay();
    }

    private void SpeedDecay()
    {
        if (_speed > 0)
        {
            _speed -= _speedDecay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            _speedDecay = ground.DecayParameter;
            _collision?.Invoke(other);
        }

        if (other.gameObject.TryGetComponent(out Finish finish))
        {
            Finish();
        }

        if (other.gameObject.TryGetComponent(out Bonus bonus))
        {
            _rigidbody.AddForce(new Vector3(0, 0, bonus.Acceleration), ForceMode.Impulse);
            _speed += bonus.Acceleration / 2;
        }
    }

    private void Finish()
    {
        IsFinish = true;
        Debug.Log($"Finish");
    }
}
