using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaPuertas : MonoBehaviour
{
    private bool permisoParaAbrirPuerta = false;
    private GameObject puertaAbrir;

    private void OnCollisionEnter(Collision obj) {       
        string s = "";
        switch (Hordas.numRonda) {
            case 1:
                s = "puerta1";
                break;
            case 2:
                s = "puerta2";
                break;
            case 3:
                s = "puerta3";
                break;
            case 4:
                s = "puerta4";
                break;
            case 5:
                s = "puerta5";
                break;
        }
        if (obj.gameObject.tag == s) {
            Debug.Log("Para abrir la puerta presiona la letra k");
            permisoParaAbrirPuerta = true;
            puertaAbrir = obj.gameObject;
        }
    }  

    private void Update() {
        if (Input.GetKeyDown(KeyCode.K) && permisoParaAbrirPuerta) {
            Destroy(puertaAbrir);
            this.gameObject.SetActive(false);
            //Hordas.puertaAbierta = true; // Puede cambiar la condicion para la siguiente horda, pej hasta tomar el pedazo de bomba
        }
    }
}
