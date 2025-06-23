using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_change : MonoBehaviour
{
    private string inGameSceneName = "inGameScene"; // メインシーン名
    private string cleanSceneName = "CleanUpScene"; // サブシーン名（上に重ねる）

    // ① clean シーンを Additive モードでロード
    public void LoadCleanScene()
    {
        SceneManager.LoadScene(cleanSceneName);
    }
    public void LoadinGameScene()
    {
        SceneManager.LoadScene(inGameSceneName);
    }


}
