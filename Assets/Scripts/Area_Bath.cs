using UnityEngine;
using UnityEngine.XR;

public class Area_Bath : MonoBehaviour
{
    private DragWithMouse2D DragWithMouse2D;
    private StateManeger StateManeger;
    private SpriteRenderer _SR;
    [SerializeField] private Sprite clean;


    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StateManeger = other.GetComponent<StateManeger>();//otherのstatemaneを取得
        if (StateManeger._currentstate == StateManeger.IngameState.StayBath && other.CompareTag("Nezumi"))
        //ぶつかったオブジェクトのステータスがStayWashであり、ネズミのタグのオブジェクトだった時
        {

            Transform Fukisashi = other.transform.Find("Fukidashi");//otherの子オブジェクトのFukidasiをみつける
            _SR = Fukisashi.GetComponent<SpriteRenderer>();//吹き出しのスプライトをゲット


            Invoke(nameof(WashChangeState), 5f);//5秒遅らせる
            StateManeger._currentstate = StateManeger.IngameState.Bath;//ステータスをBathに変更

        }

    }
    void WashChangeState()//ステータスを変更し、吹き出しイラストも変換する。
    {
        if (clean != null)//バスが指定されているとき
        {
            _SR.sprite = clean;
            Debug.Log("スプライトを変更しました");
        }
        else
        {
            Debug.LogWarning("cleanが見つかりません");
        }
        StateManeger._currentstate = StateManeger.IngameState.StayClean;

    }
}
