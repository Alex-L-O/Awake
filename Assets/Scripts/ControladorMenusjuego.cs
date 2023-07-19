using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorMenusjuego : MonoBehaviour
{
    public Image instrucciones, mision1;
    private float tiempoInicial, tiempoActual;
    private const float TIEMPO_CEDULAS = 10.5f;

    public static bool iniciaJuego = false;

    private void Start() {
        instrucciones.gameObject.SetActive(true);
        mision1.gameObject.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Recargarjuego() {
        SceneManager.LoadScene("escenaAvanzada");        
    }

    public void IrMenu() {
        SceneManager.LoadScene("PreMenu");
    }

    public void CierraInstrucciones() {  //Aquí se puede desplegar el texto dela misión
        Time.timeScale = 1;
        instrucciones.gameObject.SetActive(false);
        mision1.gameObject.SetActive(true);
        tiempoInicial = Time.time;
    }

    private void Update() {
        if ((Time.time - tiempoInicial >= TIEMPO_CEDULAS) && !iniciaJuego) {
            CierraTextoMision();
        }
    }

    public void CierraTextoMision() {
        mision1.GetComponent<Animator>().SetTrigger("cierraInfo");
        iniciaJuego = true; //después de que se cierre la cédula de la misión 1 se inicia el juego
    }


}
