using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject blastPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Projectile"))
        {
            GameObject blast = Instantiate(blastPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("Projectile hit");
        }

        if (collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 2);
    }
}
