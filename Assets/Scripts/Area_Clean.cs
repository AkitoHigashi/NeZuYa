using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Area_Clean : MonoBehaviour
{
    [Header("メインのカメラ")]
    [SerializeField] GameObject _MainCamera;
    [Header("清掃のカメラ")]
    [SerializeField] GameObject _CleanCamera;
    [Header("清掃パートのUI")]
    [SerializeField] GameObject _CleanUI;

    [Header("チェンジのディレイの時間")]
    [SerializeField] private float delaytime = 3f;
    [Header("退店時の吹き出し")]
    [SerializeField] private Sprite retun;

    private SpriteRenderer _SR;
    private Love_meter love_Meter;



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
                Invoke(nameof(GoClean), delaytime);
                StartCoroutine(CleanProcess(other.gameObject,_state));
            }
        }
    }

    private IEnumerator CleanProcess(GameObject target,StateManeger state)
    {
        yield return new WaitForSeconds(delaytime);

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
                Debug.LogWarning("bathが見つかりません");
            }
        }

        love_Meter = target.GetComponentInChildren<Love_meter>();//そのネズミのラブメータースクリプトをげっちゅ
        if (love_Meter != null)
        {
            love_Meter.AddLove(0.2f);
            Debug.Log($"{target.name} のラブが2増えたよ！");
        }
        state._currentstate = StateManeger.IngameState.Return;//5秒後ステータスをStayBathに変更


    }
    void GoClean()
    {
        _MainCamera.SetActive(false);
        _CleanCamera.SetActive(true);
        _CleanUI.SetActive(true);
    }

}
