using Unity.VisualScripting;
using UnityEngine;

public class WashArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DragWithMouse2D DragWithMouse2D;
    private Love_meter love_Meter;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nezumi"))//ネズミのタグのオブジェクトだった時
        {
            love_Meter = other.GetComponentInChildren<Love_meter>();//そのネズミのラブメータースクリプトをげっちゅ
            Invoke(nameof(CallmethodLove), 5f);//5秒遅らせる。

        }

    }
    void CallmethodLove()
    {
        love_Meter.AddLove(0.2f);//メーターを２増やす。
        Debug.Log("2増えたよ");
    }


}
