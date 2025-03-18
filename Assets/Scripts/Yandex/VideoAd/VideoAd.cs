using UnityEngine;

public class VideoAd : MonoBehaviour
{
    [SerializeField] private Victory _victory;
    [SerializeField] private GameObject _WinPanel;
    [SerializeField] private GameObject _WinPanelAfterVideoAd;

    public void Show()
    {
        //Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardCallback, OnCloseCallback);
    }

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnRewardCallback() => _victory.RewardForVideoAd();

    private void OnCloseCallback()
    {
        _WinPanel.SetActive(false);
        _WinPanelAfterVideoAd.SetActive(true);
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}