using product;
using UnityEngine;

public class ProductReleaser : MonoBehaviour
{
    [SerializeField] private HandGrip _handGrip;
    [SerializeField] private int _throwForce;

    public void PlaceInCart() // called in animation
        => _handGrip.Unclench();

    public void ThrowOut() // called in animation
    {
        Product product = _handGrip.PickedProduct;
        _handGrip.Unclench();
        product.AddForce(_handGrip.transform.up * _throwForce);
    }
}