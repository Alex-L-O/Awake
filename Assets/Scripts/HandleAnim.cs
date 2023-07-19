using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnim : MonoBehaviour
{
    private Animator anim;

    private RagDoll ragDoll;

    void Start() {
        anim = GetComponent<Animator>();
        ragDoll = GetComponent<RagDoll>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            ActivateRagDoll();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            DeactivateRagDoll();
        }
    }

    public void ActivateRagDoll() {
        ragDoll.SetEnable(true);
        anim.enabled = false;
    }

    public void DeactivateRagDoll() {
        ragDoll.SetEnable(false);
        anim.enabled = true;
    }

}
