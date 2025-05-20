using Unity.VisualScripting;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    bool onFloor = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("on floor");
            onFloor = true;
        }

        else
        {
            onFloor = false;
            Debug.Log("Left floor");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)    //In case player shoots elsewhere on floor without leaving it.
    {
        if (collision.CompareTag("Ground"))
        {
            onFloor = true;
            Debug.Log("still on floor");
        }

        else
        {
            onFloor = false;
            Debug.Log("guh2");
        }
    }


    public bool getFloorCheck()
    {
        if (onFloor == true)
        {
            Debug.Log("true");
            return true;
        }

        else if (onFloor == false)
        {
            Debug.Log("false");
            return false;
        }

        else
        {
            Debug.Log("ISSUE");
            return false;
        }
    }
}
