using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_change : MonoBehaviour
{
    private string inGameSceneName = "inGameScene"; // ���C���V�[����
    private string titleSceneName = "Title"; // �T�u�V�[����

    
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
