using UnityEngine;
using UnityEngine.SceneManagement;

public class Winbox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("aagggg");
            SceneManager.LoadScene("winscreen");
        }
    }
}

