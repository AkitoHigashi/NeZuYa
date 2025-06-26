using UnityEngine;

public class CleanLove : MonoBehaviour
{
    private Love_meter _love_Meter;
    private GameObject _target;
    private SpriteRenderer _SR;

    public void SetCleanLove()
    {
        
    }
    public void Love_SetTarget(GameObject target)
    {
        _target = target;
        if (_target != null)
        {
            _love_Meter = _target.GetComponentInChildren<Love_meter>();

            if (_love_Meter == null)
            {
                Debug.LogWarning("Love_meter ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½");
            }
        }
    }

}
