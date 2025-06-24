using UnityEngine;

public class DropWater : MonoBehaviour
{
    [Header("Á‚¦‚é‚Ü‚Å‚Ì@‚«‰ñ”")]
    [SerializeField] int rubsToDisappear = 10; // Á‚¦‚é‚Ü‚Å‚Ì@‚«‰ñ”
    private int currentRubs = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Towel"))
        {
            currentRubs++;
            Debug.Log($"@‚©‚ê‚½I¡‚Ì‰ñ”: {currentRubs}");

            // ‘å‚«‚³‚ğ­‚µ¬‚³‚­
            float scaleFactor = Mathf.Lerp(1f, 0f, (float)currentRubs / rubsToDisappear);
            transform.localScale = Vector3.one * scaleFactor;

            if (currentRubs >= rubsToDisappear)
            {
                Debug.Log("…“H‚ªÁ‚¦‚½I");
                Destroy(gameObject);
            }
        }
    }
}
