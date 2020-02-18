using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetTarget : MonoBehaviour {
    public CameraFollowTarget cameraFollowTarget;
    public Transform TargetSet;

    private void OnTriggerEnter (Collider other) {
        cameraFollowTarget.Target = TargetSet;
    }
}
