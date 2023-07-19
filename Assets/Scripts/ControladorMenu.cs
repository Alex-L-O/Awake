using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    private bool edoCreditos;
    public GameObject creditos;
    public Text txtNombrePlayer;

    void Start() {
        txtNombrePlayer.text = Navegacion.nombreJugador;
        edoCreditos = false;
        creditos.SetActive(false);
    }

    public void IrJuego() {
        SceneManager.LoadScene("escenaAvanzada");
    }

    public void Creditos() {
        if (edoCreditos) {
            edoCreditos=false;
            creditos.SetActive(false);
        } else {
            edoCreditos = true;
            creditos.SetActive(true);
        }
    }

    public void IrMenu() {
        SceneManager.LoadScene("PreMenu");
    }

    public void Salir() {
        Application.Quit();
    }

}
