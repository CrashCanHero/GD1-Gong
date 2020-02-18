using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Range {
    public float Min;
    public float Max;
}
public class PlayerController : MonoBehaviour {
    public Range MaxMovementValues;
    public Vector3 RightRotation;
    public Vector3 LeftRotation;
    public float MoveSpeed;
    Rigidbody2D rb;

    public int Horizontal() {
        return Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
    }
        
    public const float Y_POSITION = -2;

    public void Awake() {
        //Get the rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        //Making sure that the rigidbody was grabbed correctly
        if (!rb) {
            return;
        }

        //Check the movement
        rb.velocity = new Vector2(MoveSpeed * Horizontal() * Time.deltaTime, 0);

        //Rotate the player
        if (rb.velocity.x > 0) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(RightRotation.x, RightRotation.y, RightRotation.z), 3);
        } else if (rb.velocity.x < 0) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(LeftRotation.x, LeftRotation.y, LeftRotation.z), 3);
        } else {
            transform.rotation = Quaternion.identity;
        }
    }

    public void LateUpdate() {
        //Lock the players position
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, MaxMovementValues.Min, MaxMovementValues.Max), Y_POSITION);
    }
}
