using UnityEngine;

public class Blast : MonoBehaviour
{
    //Instantiate prefab (the blast)
    //the prefab will be a hitbox which will check the collided objects inside.
    //if object has tag "Player", get vector from player, negate it.
    //Divide by 100 and multiply by charge amount
    //apply momentum to player rigidbody component.
}
