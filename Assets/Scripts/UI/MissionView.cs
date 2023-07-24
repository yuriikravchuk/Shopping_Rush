using product;
using TMPro;
using UnityEngine;

public class MissionView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animation _collectedAnimation;

    public void UpdateText(ProductType type, int count) 
        => _text.text = $"Collect {count} {type}" + (count > 1 ? "s." : ".");

    public void PlayCollectedAnimation() 
        => _collectedAnimation.Play();
}