using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {
    public Vector2 SpawnArea;
    public GameObject target;

    public bool DrawDebugStuff;

    public void Awake() {
        NextTarget();
    }

    public void OnDrawGizmos() {
        if (DrawDebugStuff) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, SpawnArea);
        }
    }

    public void NextTarget() {
        float PosX = Random.insideUnitSphere.x * SpawnArea.x;
        float PosY = Random.insideUnitSphere.y * SpawnArea.y;
        Vector2 Pos = new Vector2(PosX, PosY);
        GameObject obj = Instantiate(target, Pos + (Vector2)transform.position, Quaternion.identity);
        obj.GetComponent<targetScript>().spawner = this;
    }
}
