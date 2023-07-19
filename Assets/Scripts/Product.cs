using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private ProductType _type;
    public enum ProductType {Peach, Apple, Pear}

    public ProductType Type => _type;
}
