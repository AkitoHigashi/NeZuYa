using UnityEngine;

public class StateManeger : MonoBehaviour
{
    public IngameState _currentstate = IngameState.StayWash;
    public enum IngameState
    {
        StayWash,
        Wash,
        StayBath,
        Bath,
        StayClean,
        Return
    }





}
