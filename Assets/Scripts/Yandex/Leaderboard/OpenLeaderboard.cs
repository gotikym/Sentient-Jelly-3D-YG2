using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpenLeaderboard : MonoBehaviour
{
    [SerializeField] private YandexLeaderboard _yandexLeaderboard;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private GameObject _nonAuthorizationMessage;

    private const float MessageDisplayTime = 3;

    public void TryOpenLeaderboard()
    {
        /*PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();

            _yandexLeaderboard.Fill();
        }

        if (PlayerAccount.IsAuthorized == false)
        {
            StartCoroutine(ShowMessage());
            return;
        }*/

        _leaderboardPanel.SetActive(true);
        _mainPanel.SetActive(false);
    }

    private IEnumerator ShowMessage()
    {
        _nonAuthorizationMessage.SetActive(true);
        yield return new WaitForSeconds(MessageDisplayTime);
        _nonAuthorizationMessage.SetActive(false);
    }
}