using Unity.VisualScripting;
using UnityEngine;

public class WashArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DragWithMouse2D DragWithMouse2D;
    private Love_meter love_Meter;
    private StateManeger StateManeger;
    private SpriteRenderer _SR;
    [SerializeField] private Sprite bath;


    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StateManeger = other.GetComponent<StateManeger>();//otherのstatemaneを取得
        if (StateManeger._currentstate == StateManeger.IngameState.StayWash && other.CompareTag("Nezumi"))
        //ぶつかったオブジェクトのステータスがStayWashであり、ネズミのタグのオブジェクトだった時
        {
            Transform Fukisashi = other.transform.Find("Fukidasi");//otherの子オブジェクトのFukidasiをみつける
            _SR = Fukisashi.GetComponent<SpriteRenderer>();//吹き出しのスプライトをゲット
            love_Meter = other.GetComponentInChildren<Love_meter>();//そのネズミのラブメータースクリプトをげっちゅ
            Invoke(nameof(CallmethodLove), 5f);//5秒遅らせる。
            Invoke(nameof(WashChangeState), 5f);

        }

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
            StateManeger._currentstate = StateManeger.IngameState.StayBath;

    }

}
