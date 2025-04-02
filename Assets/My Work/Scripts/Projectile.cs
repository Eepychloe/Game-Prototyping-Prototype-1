using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            //Change this to spawn the blast prefab when hits floor.
        }
    }
}
