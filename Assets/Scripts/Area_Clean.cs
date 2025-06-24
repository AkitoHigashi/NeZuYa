using UnityEngine;

public class Area_Clean : MonoBehaviour
{
    [Header("メインのカメラ")]
    [SerializeField] GameObject _MainCamera;
    [Header("清掃のカメラ")]
    [SerializeField] GameObject _CleanCamera;
    [Header("清掃パートのUI")]
    [SerializeField] GameObject _CleanUI;



    private void Start()
    {
        _CleanCamera.SetActive(false);
        _CleanUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Nezumi"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayClean)
            {
                _MainCamera.SetActive(false);
                _CleanCamera.SetActive(true);
                _CleanUI.SetActive(true);
            }
        }
    }

}
