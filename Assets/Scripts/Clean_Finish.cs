using UnityEngine;

public class Clean_Finish : MonoBehaviour
{
    [Header("メインのカメラ")]
    [SerializeField] GameObject _MainCamera;
    [Header("清掃のカメラ")]
    [SerializeField] GameObject _CleanCamera;
    [Header("清掃パートのスライドUI")]
    [SerializeField] GameObject _CleanUI;
    [Header("清掃パートの完成UI")]
    [SerializeField] GameObject _CleanFinishUI;

    [Header("チェンジのディレイの時間")]
    [SerializeField] private float delaytime = 3f;
    
    public void GoInGame()
    {
        _MainCamera.SetActive(true);
        _CleanCamera.SetActive(false);
        _CleanUI.SetActive(false);
        _CleanFinishUI.SetActive(false);
    }
}
