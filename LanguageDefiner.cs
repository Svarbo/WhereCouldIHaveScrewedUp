using UnityEngine;
using Agava.YandexGames;

public class LanguageDefiner : MonoBehaviour
{
    private void Start()
    {
        bool languageWasChanged = UnityEngine.PlayerPrefs.GetInt("LanguageWasChanged") == 1;

        if (languageWasChanged != true)
            DefineLanguage();
    }

    private void DefineLanguage()
    {
        string languageDesignation = YandexGamesSdk.Environment.i18n.lang;

        if (languageDesignation == "ru" || languageDesignation == "be" || languageDesignation == "kk" || languageDesignation == "uk" || languageDesignation == "uz")
        {
            UnityEngine.PlayerPrefs.SetInt("LanguageIndex", 0);
        }
        else if (languageDesignation == "tr")
        {
            UnityEngine.PlayerPrefs.SetInt("LanguageIndex", 2);
        }
        else
        {
            UnityEngine.PlayerPrefs.SetInt("LanguageIndex", 1);
        }

        UnityEngine.PlayerPrefs.Save();
    }
}
