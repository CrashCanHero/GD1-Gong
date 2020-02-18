using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour {
    public TargetSpawner spawner;
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<BallScript>()) {
            spawner.NextTarget();
            Destroy(gameObject);
        }
    }
}
