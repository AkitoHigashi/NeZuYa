using UnityEngine;

public class UIPush_Desroy : MonoBehaviour
{
    GameObject _Brush;
    GameObject _Towel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Destroy_Brush()
    {
        _Brush = GameObject.FindWithTag("Brush");
        if (_Brush != null)
        {
            Destroy(_Brush);
        }
    }
    public void Destroy_Towel()
    {
        _Towel = GameObject.FindWithTag("Towel");
        if (_Towel != null)
        {
            Destroy(_Towel);
        }

    }

}
