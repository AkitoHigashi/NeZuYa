using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_change : MonoBehaviour
{
    private string inGameSceneName = "inGameScene"; // メインシーン名
    private string titleSceneName = "Title"; // サブシーン名

    
    public void LoadTitleScene()
    {
        AudioManager.Instance.PlaySE("PushButton");
        SceneManager.LoadScene(titleSceneName);
    }
    public void LoadinGameScene()
    {
        AudioManager.Instance.PlaySE("PushButton");
        SceneManager.LoadScene(inGameSceneName);
    }


}
