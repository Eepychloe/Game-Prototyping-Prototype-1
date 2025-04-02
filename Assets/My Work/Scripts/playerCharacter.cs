using UnityEngine;

public class playerCharacter : MonoBehaviour
{
    private Rigidbody2D body;      //Reference to player, can move them with this
    public bool canShoot = true;
    public int shotsLeft = 2;
    [SerializeField] private int maxShots;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float projectileSpeed;
    private Vector3 mousePos;
    private Vector2 direction;

    [SerializeField] float chargeAmount;
    [SerializeField] float chargeSpeed;
    private bool isCharging;

    private void Awake()
    {
       body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

     void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;

        if (Input.GetMouseButton(0))    //if left click is true, (1) = right click, (2) = middle click
        {
            if (canShoot == true && shotsLeft > 0)
            {
                isCharging = true;
                chargeAmount += 0.8f;
                if (chargeAmount >= 100)
                {
                    chargeAmount = 100;
                }
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (isCharging == true)
            {
                isCharging = false;
                shotsLeft = shotsLeft - 1;
                Shoot(chargeAmount);
                chargeAmount = 0;
                
            }
        }
    }

    void Shoot(float chargeamount)
    {
        GameObject blast = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        if (blast.GetComponent<Rigidbody2D>() != null)
        {
            Debug.Log(direction);
            blast.GetComponent<Rigidbody2D>().AddForce(direction.normalized * projectileSpeed, ForceMode2D.Impulse);
        }
    }

    //Add a function to test if player is on the ground, maybe using an attached square hitbox under the player. If they are, replenish shotsLeft variable.
}
