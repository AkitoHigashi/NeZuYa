using UnityEngine;

public class Clean_Finish : MonoBehaviour
{
    [Header("���C���̃J����")]
    [SerializeField] GameObject _MainCamera;
    [Header("���|�̃J����")]
    [SerializeField] GameObject _CleanCamera;
    [Header("���|�p�[�g�̃X���C�hUI")]
    [SerializeField] GameObject _CleanUI;
    [Header("���|�p�[�g�̊���UI")]
    [SerializeField] GameObject _CleanFinishUI;

    [Header("�`�F���W�̃f�B���C�̎���")]
    [SerializeField] private float delaytime = 3f;
    
    public void GoInGame()
    {
        _MainCamera.SetActive(true);
        _CleanCamera.SetActive(false);
        _CleanUI.SetActive(false);
        _CleanFinishUI.SetActive(false);
    }
}
