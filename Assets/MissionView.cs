using product;
using TMPro;
using UnityEngine;

public class MissionView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    public void UpdateText(ProductType type, int count)
    {
        _text.text = $"Collect {count} {type}s.";
    }
}