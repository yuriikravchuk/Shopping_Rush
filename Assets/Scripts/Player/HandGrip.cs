using product;
using System;
using System.Collections;
using UnityEngine;

public class HandGrip : MonoBehaviour
{
    [SerializeField] private Transform _handController;
    [Range(_minHandSpeed, _maxHandSpeed)]
    [SerializeField] private float _handSpeed = 10f;
    public Product PickedProduct { get; private set; }
    public event Action<Product> Picked;

    private const float _minHandSpeed = 5f, _maxHandSpeed = 30f, maxPickingDuration = 0.6f;
    private Vector3 _startHandPosition;
    private Product _targetProduct;

    private void Awake() 
        => _startHandPosition = _handController.position;

    private void OnTriggerEnter(Collider other)
    {
        if (PickedProduct != null)
            return;

        Product product = other.GetComponent<Product>();

        if (product == null || product != _targetProduct)
            return;

        Clench(product);
    }

    public void PickProduct(Product product)
    {
        if (_targetProduct != null || PickedProduct != null)
            return;

        _targetProduct = product;
        float startPickingTime = Time.time;
        StartCoroutine(MoveHandToProduct(startPickingTime));
    }

    public void Unclench()
    {
        PickedProduct.transform.SetParent(null);
        PickedProduct.Rigidbody.constraints = RigidbodyConstraints.None;
        PickedProduct = null;
    }

    private void Clench(Product product)
    {
        PickedProduct = product;
        PickedProduct.transform.position = transform.position;
        PickedProduct.transform.SetParent(transform);
        PickedProduct.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        PickedProduct.Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
    }

    private IEnumerator MoveHandToProduct(float startTime)
    {
        while (PickedProduct == null && Time.time < startTime + maxPickingDuration)
        {
            _handController.position = Vector3.Lerp(_handController.position, _targetProduct.transform.position, _handSpeed * Time.deltaTime);
            yield return null;
        }

        _targetProduct = null;
        StartCoroutine(ReturnHand());
        yield break;
    }

    private IEnumerator ReturnHand()
    {
        while (Vector3.Distance(_handController.transform.position, _startHandPosition) > 0.01f)
        {
            _handController.position = Vector3.Lerp(_handController.position, _startHandPosition, _handSpeed * Time.deltaTime);
            yield return null;
        }
        Picked?.Invoke(PickedProduct);
        yield break;
    }
}