using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Blast : MonoBehaviour
{
    GameObject Player = GameObject.FindGameObjectWithTag("Player");
    Vector3 playerPos;
    Vector3 direction1;
    float chargeamount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GetCharge();
            Debug.Log(chargeamount);
            direction1 = (playerPos - transform.position);
            Debug.Log(direction1);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction1.normalized * 10, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
  
        Destroy(gameObject, 0.5f);
    }

    public void GetCharge()
    {
        float power = Player.GetComponent<playerCharacter>().GetCharge();
        Debug.Log(power);
        return;
    }
}
