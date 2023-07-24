using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigitbody;
    [Range(0.001f, _maxSpeed)]
    [SerializeField] private float _speed = 0.007f;
    
    private const float _maxSpeed = 0.02f;
    private Vector3 _previousPosition;

    private void FixedUpdate()
    {
        _previousPosition = _rigitbody.position;
        _rigitbody.position += transform.right * _speed;
        _rigitbody.MovePosition(_previousPosition);
    }
}