using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigitbody;
    [SerializeField] private float _speed = 0.005f;
    [SerializeField] private float _maxSpeed = 0.04f;

    private Vector3 _previousPosition;

    private void OnValidate()
    {
        _speed = Mathf.Clamp(_speed, 0, _maxSpeed);
    }

    private void FixedUpdate()
    {
        _previousPosition = _rigitbody.position;
        _rigitbody.position += transform.right * _speed;
        _rigitbody.MovePosition(_previousPosition);
    }
}
