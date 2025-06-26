using UnityEngine;

public class CleanManeger : MonoBehaviour
{
   public bool AllCleanDirt()
    {
        // "Dirt"タグのオブジェクトをシーン内で検索
        GameObject[] dirtObjects = GameObject.FindGameObjectsWithTag("Dirt");

        // 汚れオブジェクトが１つもなければtrue（きれい）
        return dirtObjects.Length == 0;
    }
    public bool AllCleanBubble()
    {
        GameObject[] BubbleObjects = GameObject.FindGameObjectsWithTag("Bubble");

        return BubbleObjects.Length == 0;

    }
}
