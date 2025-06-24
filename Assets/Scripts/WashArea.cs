using System.Collections;
using UnityEngine;

public class WashArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DragWithMouse2D DragWithMouse2D;
    private Love_meter love_Meter;
    private StateManeger _StateManeger;
    private SpriteRenderer _SR;
    [SerializeField] private Sprite bath;


    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nezuking") || other.CompareTag("Nezumi"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayWash)
            {
                StartCoroutine(WashProcess(other.gameObject, _state));
                _state._currentstate = StateManeger.IngameState.Wash;//ステータスをWashに変更
            }
        }
        /*StateManeger = other.GetComponent<StateManeger>();//otherのstatemaneを取得
        if (StateManeger._currentstate == StateManeger.IngameState.StayWash && other.CompareTag("Nezumi"))
        //ぶつかったオブジェクトのステータスがStayWashであり、ネズミのタグのオブジェクトだった時
        {
           
            Transform Fukisashi = other.transform.Find("Fukidashi");//otherの子オブジェクトのFukidasiをみつける
            _SR = Fukisashi.GetComponent<SpriteRenderer>();
            love_Meter = other.GetComponentInChildren<Love_meter>();//そのネズミのラブメータースクリプトをげっちゅ
            Invoke(nameof(CallmethodLove),  5f);//5秒遅らせる。
            Invoke(nameof(WashChangeState), 5f);
            StateManeger._currentstate = StateManeger.IngameState.Wash;//ステータスをWashに変更

        }*/

    }
    private IEnumerator WashProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(5f);//5秒待つ　NEWって何？

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

        love_Meter = target.GetComponentInChildren<Love_meter>();//そのネズミのラブメータースクリプトをげっちゅ
        if (love_Meter != null)
        {
            love_Meter.AddLove(0.2f);
            Debug.Log($"{target.name} のラブが2増えたよ！");
        }

        state._currentstate = StateManeger.IngameState.StayBath;//5秒後ステータスをStayBathに変更

    }
    void CallmethodLove()
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

    }

}
