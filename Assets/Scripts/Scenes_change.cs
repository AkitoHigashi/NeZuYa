using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_change : MonoBehaviour
{
    private string inGameSceneName = "inGameScene"; // ���C���V�[����
    private string cleanSceneName = "CleanUpScene"; // �T�u�V�[�����i��ɏd�˂�j

    // �@ clean �V�[���� Additive ���[�h�Ń��[�h
    public void LoadCleanScene()
    {
        SceneManager.LoadScene(cleanSceneName);
    }
    public void LoadinGameScene()
    {
        SceneManager.LoadScene(inGameSceneName);
    }


}
