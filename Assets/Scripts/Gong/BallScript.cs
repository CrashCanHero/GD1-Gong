using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public float BounceForce;
    Rigidbody2D rb;

    public void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<PlayerController>()) {
            Vector2 dir = collision.contacts[0].normal * BounceForce;
            rb.velocity = dir;
        }
    }
}
