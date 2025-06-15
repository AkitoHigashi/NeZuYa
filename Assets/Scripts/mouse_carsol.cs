using UnityEngine;

public class LockCursor : MonoBehaviour
{
    void Start()
    {
        // カーソルをロックする
        Cursor.lockState = CursorLockMode.Confined;

        // カーソルを表示する（非表示にしたい場合は false）
        Cursor.visible = true;
    }
}
