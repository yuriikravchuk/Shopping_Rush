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

    private const float _minHandSpeed = 5f, _maxHandSpeed = 30f, maxPickingDuration = 1f;
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

        PickedProduct = product;
    }

    private void Update()
    {
        if(PickedProduct == null) 
            return;

        PickedProduct.transform.position = transform.position;
    }

    public void PickProduct(Product product)
    {
        _targetProduct = product;
        float startPickingTime = Time.time;
        StartCoroutine(Grab(startPickingTime));
    }

    public void Unclench() => PickedProduct = null;

    private IEnumerator Grab(float startTime)
    {
        while (PickedProduct == null && Time.time < startTime + maxPickingDuration)
        {
            _handController.position = Vector3.Lerp(_handController.position, _targetProduct.transform.position, _handSpeed * Time.deltaTime);
            yield return null;
        }
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