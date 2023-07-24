using product;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Product product = other.GetComponent<Product>();

        if (product == null)
            return;

        product.gameObject.SetActive(false);
    }
}