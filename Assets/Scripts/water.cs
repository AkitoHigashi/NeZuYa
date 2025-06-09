using UnityEngine;

public class WatorDryScript : MonoBehaviour
{
    public string targetTag = "Dryer";       // 対象となるタグ
    public float requiredTime = 3f;          // 消えるまでの必要時間
    private float currentTime = 0f;          // 現在のカウント時間
    private bool isDryerInside = false;      // Dryerが中にいるかどうか

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isDryerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isDryerInside = false;
            currentTime = 0f; // 出たらカウントリセット
        }
    }

    private void Update()
    {
        if (isDryerInside)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= requiredTime)
            {
                Debug.Log("Dryerが一定時間中にいたので、Watorを消します！");
                Destroy(gameObject); // 自分自身（Wator）を消す
            }
        }
    }
}