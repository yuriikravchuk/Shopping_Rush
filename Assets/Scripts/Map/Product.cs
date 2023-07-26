using UnityEngine;

namespace product
{
    public partial class Product : MonoBehaviour
    {
        [SerializeField] private ProductType _type;
        [SerializeField] private Rigidbody _rigidbody;

        public ProductType Type => _type;

        public Rigidbody Rigidbody => _rigidbody;
    }
}