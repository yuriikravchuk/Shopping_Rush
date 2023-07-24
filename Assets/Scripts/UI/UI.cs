using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _missionView;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private GameObject _levelPassedText;
    [SerializeField] private GameObject _playerInput;

    public event UnityAction PlayButtonClicked
    {
        add => _playButton.onClick.AddListener(value);
        remove => _playButton.onClick.RemoveListener(value);
    }

    public event UnityAction NextLevelButtonClicked
    {
        add => _nextLevelButton.onClick.AddListener(value);
        remove => _nextLevelButton.onClick.RemoveListener(value);
    }

    public void ShowMenuUI() 
        => _playButton.gameObject.SetActive(true);

    public void HideMenuUI()
        => _playButton.gameObject.SetActive(false);

    public void ShowPlayUI()
    {
        _missionView.SetActive(true);
        _playerInput.SetActive(true);
    }

    public void HidePlayUI()
    {
        _missionView.SetActive(false);
        _playerInput.SetActive(false);
    }

    public void ShowFinishUI()
    {
        _nextLevelButton.gameObject.SetActive(true);
        _levelPassedText.gameObject.SetActive(true);
    }

    public void HideFinishUI()
    {
        _nextLevelButton.gameObject.SetActive(false);
        _levelPassedText.gameObject.SetActive(false);
    }
}