using UnityEngine;
using System.Collections;

public class SnapAndLockZone : MonoBehaviour
{
    public float lockDuration = 2f; // ���b�N����

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
        // �z��
        target.transform.position = transform.position;

        // ���b�N
        dragScript.isLocked = true;

        yield return new WaitForSeconds(lockDuration);

        // �A�����b�N
        dragScript.isLocked = false;
    }
}
