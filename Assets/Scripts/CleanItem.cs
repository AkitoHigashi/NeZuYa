using UnityEngine;

public class CleanItem : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;
    [SerializeField] LayerMask _item = 0;
    private bool isStop = false;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ItemMove();
    }
    void ItemMove()
    {
        if (!isStop)//ストップしていないとき（動かせる時）
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0)) //左クリックしたとき
            {
                Collider2D hit = Physics2D.OverlapPoint(mousePos, _item);//マウスのポイントにあるコライダーを取得。
                if (hit != null && hit.gameObject == this.gameObject)
                {
                    isDragging = true;
                    offset = this.transform.position - mousePos;
                }


            }
            if (Input.GetMouseButtonUp(0))//左クリック離した時
            {
                isDragging = false;
            }
            if (isDragging)
            {
                transform.position = mousePos + offset;
                //Debug.Log("アイテムドラッグ中");
            }
        }
    }
}
