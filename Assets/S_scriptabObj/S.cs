using UnityEngine;

[CreateAssetMenu(menuName = "S_Scriptable")]
public class S : ScriptableObject
{
    public Vector2 EndNezumiPos = new Vector2(-5,-5);//↓それに必要な要素
    public Vector2 EndNezukingPos = new Vector2(-5,5);
}//スクリプタブルオブジェクトを生成するための文