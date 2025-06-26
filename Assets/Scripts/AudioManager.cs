using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _seSource;
    [SerializeField] private AudioClip appearSE;
    [SerializeField] private AudioClip PushButtonSE;
    [SerializeField] private AudioClip BrushSE;
    [SerializeField] private AudioClip ShowerSE;
    [SerializeField] private AudioClip SoapSE;
    [SerializeField] private AudioClip TowelSE;
    [SerializeField] private AudioClip HandcuffsSE;
    [SerializeField] private AudioClip WashSE;
    [SerializeField] private AudioClip BathSE;
    [SerializeField] private AudioClip CleanSE;
    [SerializeField] private AudioClip CatchSE;
    ////音再生

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンまたいでも残す
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySE(string seName)
    {
        switch (seName)
        {
            case "Appear":
                _seSource.PlayOneShot(appearSE, 0.05f);
                break;

            case "PushButton":
                _seSource.PlayOneShot(PushButtonSE);
                break;
            case "Brush":
                _seSource.PlayOneShot(BrushSE, 0.1f);
                break;
            case "Towel":
                _seSource.PlayOneShot(TowelSE, 0.01f);
                break;
            case "Soap":
                _seSource.PlayOneShot(SoapSE, 1f);
                break;
            case "Shower":
                _seSource.PlayOneShot(ShowerSE, 0.1f);
                break;
            case "Handcuffs":
                _seSource.PlayOneShot(HandcuffsSE, 1f);
                break;
            case "Wash":
                _seSource.PlayOneShot(WashSE, 0.3f);
                break;
            case "Bath":
                _seSource.PlayOneShot(BathSE, 0.05f);
                break;
            case "Clean":
                _seSource.PlayOneShot(CleanSE, 0.1f);
                break;
            case "Catch":
                _seSource.PlayOneShot(CatchSE, 0.05f);
                break;
                // 他のSEもここに追加可能
        }
    }
}
