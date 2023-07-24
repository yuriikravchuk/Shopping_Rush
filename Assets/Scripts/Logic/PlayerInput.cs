using System;
using UnityEngine;
using product;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Camera _camera;

    public event Action<Product> ProductSelected;

    private Ray _ray;
    private RaycastHit _hit;

    public void OnPointerClick(PointerEventData eventData)
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, 1000f))
        {
            Product product = _hit.collider.GetComponent<Product>();

            if (product == null)
                return;

            Debug.Log(product.Type);
            ProductSelected?.Invoke(product);
        }
    }
}