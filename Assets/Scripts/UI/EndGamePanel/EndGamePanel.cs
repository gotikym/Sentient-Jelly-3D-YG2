using IJunior.TypedScenes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class EndGamePanel : MonoBehaviour
{
    [SerializeField] private BackgroundMusic _backgroundMusic;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private Animator _animator;
    [SerializeField] protected Timer _timer;

    protected int StoppedTimeScale = 0;
    protected int RunningTimeScale = 1;
    protected int NextSceneIndex = 1;

    public abstract string AnimationName { get; }

    protected abstract void OnEnable();

    protected abstract void OnDisable();

    public void OnRestartButtonClick()
    {
        _backgroundMusic.SetCurrentSamples();
        _panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = RunningTimeScale;
    }

    public void OnMainMenuButtonClick()
    {
        _backgroundMusic.SetCurrentSamples();
        Main.Load();
        Time.timeScale = RunningTimeScale;
    }

    public void OnNextLevelButtonClick()
    {
        _backgroundMusic.SetCurrentSamples();
        _panel.SetActive(false);
        Time.timeScale = RunningTimeScale;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextSceneIndex);
    }

    public void OpenPanel()
    {
        _mainPanel.SetActive(false);
        _panel.SetActive(true);

        _animator.Play(AnimationName);
        _timer.SetInfiniteTime();
    }

    protected void ClosePanel()
    {
        _panel.SetActive(false);
        _timer.SwitchTimerStatus();
    }
}