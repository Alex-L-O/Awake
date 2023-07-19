using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorGanar : MonoBehaviour
{
    public GameObject puerta;
    public Image ganar;

    private void Start() {
        puerta.SetActive(true);
        ganar.gameObject.SetActive(false);
    }
    void Update() {
        if (ManagerDisparo.enemigosEliminados == 100) {
            puerta.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "ganar") {
            ganar.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
