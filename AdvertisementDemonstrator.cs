using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class AdvertisementDemonstrator : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        PlayerAccount.AuthorizedInBackground += OnAuthorizedInBackground;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        if (PlayerAccount.IsAuthorized == false)
            PlayerAccount.StartAuthorizationPolling(1500);
    }

    private void OnDestroy()
    {
        PlayerAccount.AuthorizedInBackground -= OnAuthorizedInBackground;
    }

    private void OnAuthorizedInBackground()
    {
        Debug.Log($"{nameof(OnAuthorizedInBackground)} {PlayerAccount.IsAuthorized}");
    }

    public void TryShow()
    {
        int attemptCount = UnityEngine.PlayerPrefs.GetInt("AttemptCount");
        attemptCount++;
        UnityEngine.PlayerPrefs.SetInt("AttemptCount", attemptCount);

        if (attemptCount % 3 == 0)
            VideoAd.Show();
    }
}
