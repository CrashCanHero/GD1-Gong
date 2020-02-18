using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour {
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<BallScript>()) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
