using System.Collections;
using UnityEngine;

public class Area_Clean : MonoBehaviour
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
    [Header("退店時の吹き出し")]
    [SerializeField] private Sprite retun;

    private SpriteRenderer _SR;
    private Love_meter love_Meter;
    private Collider2D _boxCol2D;
    [SerializeField] private Clean_Finish _clean_Finish;



    private void Start()
    {
        _boxCol2D = GetComponent<Collider2D>();
        _CleanCamera.SetActive(false);
        _CleanUI.SetActive(false);
        _CleanFinishUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nezumi") || other.CompareTag("Nezuking") || other.CompareTag("Women"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayClean)
            {
                if (_boxCol2D != null)
                {
                    _boxCol2D.isTrigger = false;//トリガーとオフ
                    Debug.Log("CleanArea入れないよ！！");
                }
                _clean_Finish.SetTarget(other.gameObject);
                Invoke(nameof(GoClean), delaytime);

            }

        }
    }

    private IEnumerator CleanProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(0f);

        Transform fukidashi = target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//吹き出しのスプライトをゲット
            if (_SR != null && retun != null)
            {
                _SR.sprite = retun;
                Debug.Log($"{target.name} のスプライトを変更しました");
            }
            else
            {
                Debug.LogWarning("retunが見つかりません");
            }
        }

        love_Meter = target.GetComponentInChildren<Love_meter>();//そのネズミのラブメータースクリプトをげっちゅ
        if (love_Meter != null)
        {
            love_Meter.AddLove(0.2f);
            Debug.Log($"{target.name} のラブが2増えたよ！");
        }
        state._currentstate = StateManeger.IngameState.Return;//5秒後ステータスをStayBathに変更
        _boxCol2D.isTrigger = true;

    }
    public void EndCleaning(GameObject target)
    {
        StateManeger state = target.GetComponent<StateManeger>();
        if (state != null)
        {
            StartCoroutine(CleanProcess(target, state));
        }
    }
    void GoClean()
    {
        _MainCamera.SetActive(false);
        _CleanCamera.SetActive(true);
        _CleanUI.SetActive(true);
        _CleanFinishUI.SetActive(true);
        _boxCol2D.isTrigger = true;//トリガーをオン
        Debug.Log("BathAreaに入れます！");
    }

}
