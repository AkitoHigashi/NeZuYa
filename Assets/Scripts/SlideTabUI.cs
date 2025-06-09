using UnityEngine;
using System.Collections;

public class SlideTabUI : MonoBehaviour
{
    public RectTransform panel;
    public float slideTime = 0.3f;

    private bool isOpen = false;
    private Vector2 closedPos;
    private Vector2 openPos;

    void Start()
    {
        float panelWidth = panel.rect.width;//384 panel.rect.width
        float tabWidth = 364f; // ゲーム開始時にUIが右端にセットされる距離。つまみの見えてる幅（調整可）

        // つまみだけが見えている位置（パネルがほぼ画面外）
        closedPos = new Vector2(tabWidth, 0);

        // パネルが画面内にスライドしている位置
        openPos = new Vector2(0, 0);//UIの元の位置

        panel.anchoredPosition = closedPos;
    }

    public void TogglePanel()
    {
        StopAllCoroutines();
        StartCoroutine(Slide(isOpen ? closedPos : openPos));
        isOpen = !isOpen;
    }

    private IEnumerator Slide(Vector2 target)
    {
        Vector2 start = panel.anchoredPosition;
        float time = 0f;

        while (time < slideTime)
        {
            time += Time.deltaTime;
            panel.anchoredPosition = Vector2.Lerp(start, target, time / slideTime);
            yield return null;
        }
        panel.anchoredPosition = target;
    }
}
