using System.Collections;
using UnityEngine;

public class Area_Bath : MonoBehaviour
{
    [Header("変更する際はDWM2DのInvoke時間も変更して")]
    [SerializeField] private float BathTime = 5f;
    [Header("清掃要求の吹き出し")]
    [SerializeField] private Sprite clean;

    private DragWithMouse2D DragWithMouse2D;
    private StateManeger StateManeger;
    private SpriteRenderer _SR;
    private Collider2D _boxCol2D;


    void Start()
    {
        _boxCol2D = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_boxCol2D != null)
        {
            _boxCol2D.isTrigger = false;//トリガーとオフ
            Debug.Log("BathArea入れないよ！！");
        }

        if (other.CompareTag("Nezumi"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayBath)
            {
                StartCoroutine(BathProcess(other.gameObject, _state));
                _state._currentstate = StateManeger.IngameState.Bath;//ステータスをbathに変更
            }
        }

    }
    private IEnumerator BathProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(BathTime);//指定秒数待つ　NEWって何？
        Transform fukidashi = target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//吹き出しのスプライトをゲット
            if (_SR != null && clean != null)
            {
                _SR.sprite = clean;
                Debug.Log($"{target.name} のスプライトを変更しました");
            }
            else
            {
                Debug.LogWarning("bathが見つかりません");
            }
        }
        state._currentstate = StateManeger.IngameState.StayClean;//5秒後ステータスをStayCleanに変更
        _boxCol2D.isTrigger = true;//トリガーをオン
        Debug.Log("BathAreaに入れます！");


    }
}
