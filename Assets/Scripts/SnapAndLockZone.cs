using UnityEngine;
using System.Collections;

public class SnapAndLockZone : MonoBehaviour
{
    public float lockDuration = 2f; // ロック時間

    private void OnTriggerEnter2D(Collider2D other)
    {
        DragWithMouse2D dragScript = other.GetComponent<DragWithMouse2D>();
        if (dragScript != null)
        {
            StartCoroutine(SnapAndLock(other.gameObject, dragScript));
        }
    }

    private IEnumerator SnapAndLock(GameObject target, DragWithMouse2D dragScript)
    {
        // 吸着
        target.transform.position = transform.position;

        // ロック
        dragScript.isLocked = true;

        yield return new WaitForSeconds(lockDuration);

        // アンロック
        dragScript.isLocked = false;
    }
}
