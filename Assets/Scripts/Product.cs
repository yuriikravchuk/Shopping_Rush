using UnityEngine;

namespace product
{
    public partial class Product : MonoBehaviour
    {
        [SerializeField] private ProductType _type;
        [SerializeField] private Rigidbody _rigidbody;

        public ProductType Type => _type;

        public void AddForce(Vector3 force) => _rigidbody.AddForce(force);
    }
}