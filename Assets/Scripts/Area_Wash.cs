using System.Collections;
using UnityEngine;

public class Area_Wash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DragWithMouse2D DragWithMouse2D;
    //private Love_meter love_Meter;
    //private StateManeger _StateManeger;
    private SpriteRenderer _SR;
    private BoxCollider2D _boxCol2D;

    [SerializeField] private Sprite bath;
    [SerializeField] private float WashTime = 5f;


    void Start()
    {
        _boxCol2D = GetComponent<BoxCollider2D>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (_boxCol2D != null)
        {
            _boxCol2D.isTrigger = false;//トリガーとオフ
            Debug.Log("WashArea入れないよ！！");
        }

        if (other.CompareTag("Nezumi"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayWash)
            {
                StartCoroutine(WashProcess(other.gameObject, _state));
                _state._currentstate = StateManeger.IngameState.Wash;//ステータスをWashに変更
            }
        }
    }

    private IEnumerator WashProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(WashTime);//5秒待つ　NEWって何？

        Transform fukidashi = target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//吹き出しのスプライトをゲット
            if (_SR != null && bath != null)
            {
                _SR.sprite = bath;
                Debug.Log($"{target.name} のスプライトを変更しました");
            }
            else
            {
                Debug.LogWarning("bathが見つかりません");
            }
        }

        state._currentstate = StateManeger.IngameState.StayBath;//5秒後ステータスをStayBathに変更
        _boxCol2D.isTrigger = true;//トリガーをオン
        Debug.Log("WashAreaに入れます！");
    }
    /*void CallmethodLove()
    {
        love_Meter.AddLove(0.2f);//メーターを２増やす。
        Debug.Log("2増えたよ");
    }
    void WashChangeState()//ステータスを変更し、吹き出しイラストも変換する。
    {
        if (bath != null)//バスが指定されているとき
        {
            _SR.sprite = bath;
            Debug.Log("スプライトを変更しました");
        }
        else
        {
            Debug.LogWarning("bathが見つかりません");
        }
        _StateManeger._currentstate = StateManeger.IngameState.StayBath;

    }*/

}
