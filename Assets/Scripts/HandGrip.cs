using product;
using System;
using System.Collections;
using UnityEngine;

public class HandGrip : MonoBehaviour
{
    [SerializeField] private Transform _handController;
    [Range(_minHandSpeed, _maxHandSpeed)]
    [SerializeField] private float _handSpeed = 0.03f;
    public Product PickedProduct { get; private set; }
    public event Action<Product> Picked;

    private const float _minHandSpeed = 0.02f, _maxHandSpeed = 0.1f;
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
        StartCoroutine(Grab());
    }

    public void Unclench() => PickedProduct = null;

    private IEnumerator Grab()
    {
        while(PickedProduct == null)
        {
            _handController.position = Vector3.Lerp(_handController.position, _targetProduct.transform.position, _handSpeed);
            yield return null;
        }
        StartCoroutine(ReturnHand());
        yield break;
    }

    private IEnumerator ReturnHand()
    {
        while (Vector3.Distance(_handController.transform.position, _startHandPosition) > 0.01f)
        {
            _handController.position = Vector3.Lerp(_handController.position, _startHandPosition, _handSpeed);
            yield return null;
        }
        Picked?.Invoke(PickedProduct);
        yield break;
    }
}