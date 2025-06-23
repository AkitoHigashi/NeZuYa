using UnityEngine;

public class SetNezukingPos : MonoBehaviour
{
    [SerializeField] CharaPosition CharaPosition;

    private Vector2 Nezukingpos;

    private void Start()
    {
        this.transform.position = CharaPosition.EndNezukingPos;
        //指定したオブジェクトのシーンの最終位置を記録しこのオブジェジェクトの位置に上書き
    }

    public void SavePositionNezuking()
    {
        Nezukingpos = this.transform.position;
        CharaPosition.EndNezukingPos = Nezukingpos;
        //このオブジェクトの位置を常にスクリプタブルに送る。
    }
}
