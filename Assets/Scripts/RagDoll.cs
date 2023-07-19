using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    private Rigidbody[] rigidBodies;


    void Start() {
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        SetEnable(false);
    }

    void Update() {
        
    }

    public void SetEnable(bool enable) {
        bool isKinematic = !enable;
        foreach (var rigidBody in rigidBodies) {
            rigidBody.isKinematic = isKinematic;
        }
    }


}
