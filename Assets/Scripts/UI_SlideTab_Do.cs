using DG.Tweening;
using UnityEngine;

public class UI_SlideTab_Do : MonoBehaviour
{
    private bool isOpen = false;
    [SerializeField] float openmovespeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.DOLocalMove(new Vector2(966f, 0), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Slide()
    {
        if (!isOpen)
        {
            transform.DOLocalMove(new Vector2(966f, 0), openmovespeed);
            isOpen = true;
        }
        else
        {
            transform.DOLocalMove(new Vector2(1236f, 0), openmovespeed);
            isOpen = false;
        }
        
    }
}
