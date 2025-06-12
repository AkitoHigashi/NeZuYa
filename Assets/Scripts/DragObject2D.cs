using UnityEngine;

public class DragWithMouse2D : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // マウスを押した瞬間
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(mousePos);//マウスのポインターの位置にコライダーがあるのか確認
            if (hit != null && hit.gameObject == this.gameObject)//コライダーを見つけた上、そのオブジェクトがこのオブジェクトだったら
            {
                isDragging = true;
                offset = transform.position - mousePos;
                //コライダーとマウスポインターの距離を取得し、ポインターに吸われずそのままオブジェクトを移動できるようにする
            }
        }

        // マウスを離した瞬間
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // ドラッグ中の動き
        if (isDragging)
        {
            transform.position = mousePos + offset;
        }
    }
}
