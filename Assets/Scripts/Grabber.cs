using UnityEngine;

public class Grabber : MonoBehaviour
{
    public Product CurrentProduct { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (CurrentProduct != null)
            return;

        Product product = other.GetComponent<Product>();

        if (product == null)
            return;

        Grab(product);
    }

    private void Grab(Product product)
    {
        CurrentProduct = product;
    }

    public void Release()
    {
        CurrentProduct = null;
    }
}
