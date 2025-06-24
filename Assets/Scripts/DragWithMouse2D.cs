using UnityEngine;

public class DragWithMouse2D : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;
    [SerializeField] LayerMask _catch = 0;//レイヤーから選択　この場合ネズミ
    StateManeger _StateManeger;


    public bool isLocked = false;

    void Start()
    {
        cam = Camera.main;
        _StateManeger = GetComponent<StateManeger>();
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (isLocked == false)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // マウスを押した瞬間
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D hit = Physics2D.OverlapPoint(mousePos, _catch);
                //マウスのポインターの位置にコライダーがあるのか確認し、レイヤーがこの場合ネズミなら取得
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
                //Debug.Log("ドラッグ中");
                transform.position = mousePos + offset;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("WashArea") && _StateManeger._currentstate == StateManeger.IngameState.StayWash)
        //WashAreaのタグであり、現在のステータスがStayWashだった時。
        {
            if (isDragging == true)//ドラッグできるのをできないようにする。
            {
                isDragging = false;
                Debug.Log("ドラッグできないよ");
            }
            isLocked = true;
            Invoke(nameof(LockChanged), 5f);
            Debug.Log("ロック開始");
            transform.localPosition = collision.transform.localPosition;//ぶつかったコライダーの位置に吸われる。
        }
        if (collision.gameObject.CompareTag("BathArea") && _StateManeger._currentstate == StateManeger.IngameState.StayBath)
        //BathAreaのタグであり、現在のステータスがStayBathだった時。
        {
            if (isDragging == true)//ドラッグできるのをできないようにする。
            {
                isDragging = false;
                Debug.Log("ドラッグできないよ");
            }
            isLocked = true;
            Invoke(nameof(LockChanged), 5f);
            Debug.Log("ロック開始");
            transform.localPosition = collision.transform.localPosition;//ぶつかったコライダーの位置に吸われる。
        }
        if (collision.gameObject.CompareTag("CleanArea") && _StateManeger._currentstate == StateManeger.IngameState.StayClean)
        //CleanAreaのタグであり、現在のステータスがStayCleanだった時。
        {
            if (isDragging == true)
            {
                isDragging = false;
                Debug.Log("ドラッグできないよ");
            }
            isLocked = true;
            Invoke(nameof(LockChanged), 5f);
            Debug.Log("ロック開始");
            transform.localPosition = collision.transform.localPosition;
        }
    }

    private void LockChanged()
    {
        isLocked = false;
        Debug.Log("ロック解除");
    }
}


