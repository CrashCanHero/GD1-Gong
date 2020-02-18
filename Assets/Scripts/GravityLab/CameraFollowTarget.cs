using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour {
    [SerializeField] bool x = false;
    [SerializeField] bool y = false;
    [SerializeField] bool z = false;
    [SerializeField] bool Rotation = false;

    [SerializeField] Vector3 TargetPositions = Vector3.zero;
    [SerializeField] Vector3 Offset = Vector3.zero;
    public Transform Target = null;
    [SerializeField] float FollowSpeed = 1;

    public void FixedUpdate () {
        if (Target != null) {
            Vector3 pos = new Vector3 ();
            if (x) {
                pos.x = Target.position.x;
            } else {
                pos.x = TargetPositions.x;
            }
            if (y) {
                pos.y = Target.position.y;
            } else {
                pos.y = TargetPositions.y;
            }
            if (z) {
                pos.z = Target.position.z;
            } else {
                pos.z = TargetPositions.z;
            }

            if (Rotation) {
                Quaternion rot = Target.rotation;

                Quaternion newRot = Quaternion.RotateTowards (transform.rotation, Target.rotation, 10);
                transform.rotation = newRot;
            }

            float Dist = Vector3.Distance (transform.position, pos);

            transform.position = Vector3.MoveTowards (transform.position, pos + Offset, (FollowSpeed / 10) * Dist);
        }
    }
}
