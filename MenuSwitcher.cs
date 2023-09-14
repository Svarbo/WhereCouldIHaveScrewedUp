using Agava.YandexGames;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenu;
    [SerializeField] private Canvas _levelMenu;
    [SerializeField] private Canvas _settings;

    public void EnableLevelMenu()
    {
        _levelMenu.gameObject.SetActive(true);
        _mainMenu.gameObject.SetActive(false);
        _settings.gameObject.SetActive(false);
    }

    public void EnableMainMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        _levelMenu.gameObject.SetActive(false);
        _settings.gameObject.SetActive(false);
    }

    public void EnableSettings()
    {
        _settings.gameObject.SetActive(true);
        _mainMenu.gameObject.SetActive(false);
        _levelMenu.gameObject.SetActive(false);
    }

    public void ShowLeaderboard()
    {
        Leaderboard.GetEntries("Leaderboard1", (result) =>
        {
            Debug.Log($"My rank = {result.userRank}");

            foreach (var entry in result.entries)
            {
                string name = entry.player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";
                Debug.Log(name + " " + entry.score);
            }
        });
    }
}