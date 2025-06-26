using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Clean_Finish : MonoBehaviour
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
    [Header("退店時の吹き出し")]
    [SerializeField] private Sprite retun;

    [Header("Area_cleanのコライダー")]
    [SerializeField] private Collider2D _ACCd;
    [Header("Area_cleanのスクリプト")]
    [SerializeField] private Area_Clean _AC;
    [Header("キャラ生成のスクリプト")]
    [SerializeField] private Generator_chara _GC;
    [SerializeField] private CleanManeger CleanManeger;
    private GameObject _target;
    private Love_meter love_Meter;
    private SpriteRenderer _SR;

    public bool PossiblePush = false;


    //[Header("チェンジのディレイの時間")]
    //[SerializeField] private float delaytime = 3f;


    public void GoInGame()
    {
        if (PossiblePush)
        {

            if (CleanManeger != null)
            {
                if (CleanManeger.AllCleanWater() && CleanManeger.AllCleanBubble() && CleanManeger.AllCleanDirt())
                {
                    GameObject cleanChara = GameObject.FindWithTag("CleanChara");//CleanCharaを削除
                    if (cleanChara != null)
                    {
                        Debug.Log("CleanChara を見つけた: " + cleanChara.name);
                        Destroy(cleanChara); // 例：削除
                    }
                    AudioManager.Instance.PlaySE("PushButton");
                    _MainCamera.SetActive(true);
                    _HeitenButton.SetActive(true);
                    _Love.SetActive(false);
                    _CleanCamera.SetActive(false);
                    _CleanUI.SetActive(false);
                    _CleanFinishUI.SetActive(false);
                    _ACCd.isTrigger = true;//トリガーをオン
                    Debug.Log("BathAreaに入れます！");
                    StartCoroutine(Change(_target.gameObject));//2
                    StartCoroutine(ReturnMove(_target.gameObject));//2

                }
                else
                {
                    Debug.Log("身体の汚れがきれいになっていません");
                }
            }
            else
            {
                Debug.Log("CleanManegerを取得できません");
            }
        }
    }
    public void SetTarget(GameObject target)
    {
        _target = target;//CleanAreaに入ったオブジェクトを取得。
    }
    private IEnumerator Change(GameObject _target)
    {
        yield return new WaitForSeconds(2f);
        StateManeger _state = _target.GetComponent<StateManeger>();
        Transform fukidashi = _target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//吹き出しのスプライトをゲット
            if (_SR != null && retun != null)
            {
                _SR.sprite = retun;
                Debug.Log($"{_target.name} のスプライトを変更しました");
            }
            else
            {
                Debug.LogWarning("retunが見つかりません");
            }
            love_Meter = _target.GetComponentInChildren<Love_meter>();//そのネズミのラブメータースクリプトをげっちゅ
            if (love_Meter != null)
            {
                love_Meter.AddLove(0.34f);
                Debug.Log($"{_target.name} のラブが3増えたよ！");
            }
            PossiblePush = false;
            _state._currentstate = StateManeger.IngameState.Return;

        }
    }
    private IEnumerator ReturnMove(GameObject _target)
    {
        yield return new WaitForSeconds(2f);
        _target.transform.DOMove(new Vector3(-12f, -3f, 0f), 3f)//キャラが移動する。5秒
                         .SetEase(Ease.InQuad)
                         .OnComplete(() =>
                         {
                             Destroy(_target.gameObject);//移動ご削除
                             Debug.Log($"{_target.name}が退店しました。");
                             _GC.SpawnRandomCharacter();
                             _GC.RemoveSpawnedCharacter(_target.gameObject.tag);
                         });


    }
}


