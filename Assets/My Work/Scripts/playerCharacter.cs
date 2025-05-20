using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class playerCharacter : MonoBehaviour
{
    private Rigidbody2D body;      //Reference to player, can move them with this
    public bool canShoot = true;
    public int shotsLeft = 2;
    [SerializeField] private int maxShots;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject blastPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject FloorCheck;
    [SerializeField] float projectileSpeed;
    private Vector3 mousePos;
    private Vector2 direction;
    float bulletCharge;

    [SerializeField] public float chargeAmount;
    private bool isCharging;
    bool isGrounded = false;
    float slideSpeed = 5f;
    float friction = 0.5f;

    private void Awake()
    {
       body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().linearDamping = 0.01f;
    }

     void Update()
     {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;

        //Grounded things

        if (isGrounded == true)
        {
            shotsLeft = maxShots;
        }

        //SHOOTING

        if (Input.GetMouseButton(0))    //if left click is true, (1) = right click, (2) = middle click
        {
            if (canShoot == true && shotsLeft > 0)
            {
                isCharging = true;
                chargeAmount += Time.deltaTime * 100;
                if (chargeAmount >= 100)
                {
                    chargeAmount = 100;
                }
            }
        }

        else if (Input.GetMouseButtonUp(0))   //If Left click is released.
        {
            if (isCharging == true)
            {
                isCharging = false;
                shotsLeft = shotsLeft - 1;

                if (chargeAmount * 100 >= 15)
                    Shoot(chargeAmount);

                bulletCharge = chargeAmount;
                chargeAmount = 0;
            }
        }
     }

    void Shoot(float chargeamount)
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        if (chargeAmount >= 15 && chargeAmount <= 80)
        bullet.transform.localScale = new Vector3(chargeamount / 100, chargeamount / 100, chargeamount / 100);

        else if (chargeAmount > 80)
        {
            chargeAmount = 80;
            bullet.transform.localScale = new Vector3(chargeamount / 100, chargeamount / 100, chargeamount / 100);
        }

        if (bullet.GetComponent<Rigidbody2D>() != null)
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * projectileSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)            //CHECKS IF PLAYER IS STOOD ON GROUND
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 normal = other.GetContact(0).normal;   //Gets first contact and stores as normal
            if (normal == Vector3.up)
            {
                isGrounded = true;
                GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            }

            else
            {
                isGrounded = false;
            }
        }

        else if (other.gameObject.CompareTag("SlideGround"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)   //Checks when player leaves ground
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("SlideGround"))
        {
            isGrounded = false;
        }
    }

    public float GetCharge()
    {
        float charge = bulletCharge;
        return charge;
    }
}
