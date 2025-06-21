using UnityEngine;

public class Bubble_Spawn : MonoBehaviour
{
    [SerializeField] GameObject _bubblePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BBpos"))
        {
            if (_bubblePrefab != null)
            {
                Instantiate(_bubblePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("ƒvƒŒƒnƒu‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
            }
        }
;
    }
}
