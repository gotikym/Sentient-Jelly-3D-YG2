using Agava.WebUtility;
using UnityEngine;

public class TestFocus : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundCangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundCangeWeb;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundCangeWeb(bool isBackground)
    {
        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    private void MuteAudio(bool value)
    {
        _audioSource.volume = value ? 0 : 1;
    }

    private void PauseGame(bool value)
    {
        if (_timer == null)
            Time.timeScale = value ? 0 : 1;
        else if (_timer.PanelIsActive == false)
            _timer.SwitchTimerStatus();
    }
}