using UnityEngine;

[CreateAssetMenu(fileName = "LoveChara", menuName = "Game/LoveChara")]
public class LoveChara : ScriptableObject
{
    public float savedLoveRate = 0f; // 保存されるゲージ値
}