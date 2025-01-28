using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeStart;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _nameLevelText;
    [SerializeField] private Animator _animator;

    private float _currentTime;

    private const string AnimationName = "Timer";
    private const int LevelNumberAdjustment = 1;
    private const float CriticalTime = 10;
    private const float InfiniteTime = 88888888;

    private bool _isPlaying = true;
    private bool _panelIsAcive = false;

    public float TimeStart => _timeStart;
    public float CurrentTime => _currentTime;
    public bool IsPlaying => _isPlaying;
    public bool PanelIsActive => _panelIsAcive;

    public event Action TimeIsUp;

    private void Start()
    {
        _currentTime = _timeStart;
        _timerText.text = _currentTime.ToString();
        _nameLevelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex - LevelNumberAdjustment);
    }

    private void FixedUpdate()
    {
        if (_isPlaying)
            SubtractTime();
    }

    public void SwitchTimerStatus()
    {
        _isPlaying = !_isPlaying;
    }

    public void SwitchPanelStatus()
    {
        _panelIsAcive = !_panelIsAcive;
    }    

    public void SetInfiniteTime()
    {
        _currentTime = InfiniteTime;
    }

    private void SubtractTime()
    {
        _currentTime -= Time.deltaTime;
        _timerText.text = Mathf.Round(_currentTime).ToString();

        if (_currentTime <= CriticalTime)
            _animator.Play(AnimationName);
        else
            _animator.StopPlayback();

        if (_currentTime <= 0)
            TimeIsUp?.Invoke();
    }
}