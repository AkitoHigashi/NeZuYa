using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Area_Clean : MonoBehaviour
{
    [Header("メインのカメラ")]
    [SerializeField] GameObject _MainCamera;
    [SerializeField] GameObject _HeitenButton;
    [Header("清掃のカメラ")]
    [SerializeField] GameObject _CleanCamera;
    [Header("清掃パートのスライドUI")]
    [SerializeField] GameObject _CleanUI;
    [Header("清掃パートの完成UI")]
    [SerializeField] GameObject _CleanFinishUI;
    [SerializeField] GameObject _Love;
    [Header("クリーンモードで生成するキャラ")]
    [SerializeField] private GameObject Nezumi_C_Prefab;
    [SerializeField] private GameObject Nezuking_C_Prefab;
    [SerializeField] private GameObject Women_C_Prefab;
    [SerializeField] private Transform _SetPos;

    private GameObject prefabToSpawn;
   

    [Header("チェンジのディレイの時間")]
    [SerializeField] private float delaytime = 3f;
    [Header("退店時の吹き出し")]
    [SerializeField] private Sprite retun;

    private SpriteRenderer _SR;
    private Love_meter love_Meter;
    private Collider2D _boxCol2D;
    [SerializeField] private Clean_Finish _clean_Finish;
    [SerializeField] private Chara_Catch Chara_Catch;



    private void Start()
    {
        _boxCol2D = GetComponent<Collider2D>();
        _Love.SetActive(false);
        _CleanCamera.SetActive(false);
        _CleanUI.SetActive(false);
        _CleanFinishUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nezumi") || other.CompareTag("Nezuking") || other.CompareTag("Women"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayClean)
            {
                if (_boxCol2D != null)
                {
                    _boxCol2D.isTrigger = false;//トリガーとオフ
                    Debug.Log("CleanArea入れないよ！！");
                }
                AudioManager.Instance.PlaySE("Clean");

                Chara_Catch.Chara_Catch_SetTarget(other.gameObject);//オブジェクト取得
                _clean_Finish.SetTarget(other.gameObject);//オブジェクト取得
                Invoke(nameof(GoClean), delaytime);

                
                if (other.CompareTag("Nezumi"))
                {
                    prefabToSpawn = Nezumi_C_Prefab;
                }
                else if (other.CompareTag("Nezuking"))
                {
                    prefabToSpawn = Nezuking_C_Prefab;
                }
                else if (other.CompareTag("Women"))
                {
                    prefabToSpawn = Women_C_Prefab;
                }

                if (prefabToSpawn != null)
                {
                    Instantiate(prefabToSpawn, _SetPos.position, Quaternion.identity);
                    Debug.Log($"{other.tag} に対応したオブジェクトを生成しました");
                }

            }

        }
    }

    private IEnumerator CleanProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(0f);

        Transform fukidashi = target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//吹き出しのスプライトをゲット
            if (_SR != null && retun != null)
            {
                _SR.sprite = retun;
                Debug.Log($"{target.name} のスプライトを変更しました");
            }
            else
            {
                Debug.LogWarning("retunが見つかりません");
            }
        }

        love_Meter = target.GetComponentInChildren<Love_meter>();//そのネズミのラブメータースクリプトをげっちゅ
        if (love_Meter != null)
        {
            love_Meter.AddLove(0.25f);
            Debug.Log($"{target.name} のラブが2増えたよ！");
        }
        state._currentstate = StateManeger.IngameState.Return;//5秒後ステータスをStayBathに変更
        _boxCol2D.isTrigger = true;

    }
    public void EndCleaning(GameObject target)
    {
        StateManeger state = target.GetComponent<StateManeger>();
        if (state != null)
        {
            StartCoroutine(CleanProcess(target, state));
        }
    }
    void GoClean()
    {
        _MainCamera.SetActive(false);
        _HeitenButton.SetActive(false);
        _Love.SetActive(true);
        _CleanCamera.SetActive(true);
        _CleanUI.SetActive(true);
        _CleanFinishUI.SetActive(true);
        Chara_Catch.CleanSetLove();
        //_boxCol2D.isTrigger = true;//トリガーをオン

    }

}
