using UnityEngine;

public class StateManeger : MonoBehaviour
{
    public IngameState _currentstate = IngameState.StayWash;//初期ステータス
    private Animator _anim = null;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public enum IngameState
    {
        StayWash,
        Wash,
        StayBath,
        Bath,
        StayClean,
        Return
    }
    void Update()
    {
        if (_anim != null)
        {
            if (_currentstate == IngameState.Wash)
            {
                _anim.SetBool("inShower", true);
            }
            else if (_currentstate == IngameState.StayBath)
            {
                _anim.SetBool("inShower",false);
            }
        }
        else
        {
            Debug.LogWarning("アニメーションコンポーネントが取得されていません");
        }
    }





}
