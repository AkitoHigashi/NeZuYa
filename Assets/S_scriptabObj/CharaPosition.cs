using UnityEngine;

[CreateAssetMenu(menuName = "S_Scriptable")]
public class CharaPosition : ScriptableObject
{
    public Vector2 EndNezumiPos;//↓それに必要な要素
    public Vector2 EndNezukingPos;

    public bool hasSavedPosition = false;
}//スクリプタブルオブジェクトを生成するための文