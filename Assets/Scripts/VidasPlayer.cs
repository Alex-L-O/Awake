using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidasPlayer : MonoBehaviour
{    
    public static int vida;
    public Image marcadorVidas;
    public Sprite[] imgVidas;
    private bool haMuerto;
    public GameObject gameOver;
    private const int vidasINI = 5;
    public static int puedePerderVida = 1;
    public Text txtNumero;
    public Text txtPuntos;
    public Text txtRecord;
    public Text nombreR;
    public Text proyectilesRestantes;

    public GameObject fm; //Instancia del filmanager para acceder al método SaveToFile   
    

    void Start() {
        Time.timeScale = 1;
        haMuerto = false;
        vida = vidasINI;
        marcadorVidas.GetComponent<Image>().sprite = imgVidas[5];
        gameOver.SetActive(false);
        txtRecord.text = FileManager.record.ToString(); //Imprime el récord en pantalla
        nombreR.text = FileManager.nombreR; //Nombre del poseedor del récord
    }

    private void Update() {
        txtPuntos.text = ManagerDisparo.puntosPlayer.ToString(); //Actualización de los puntos de la partida
        txtNumero.text = ManagerDisparo.enemigosEliminados.ToString() + "/100"; //Actualización de los enemigos eliminados
        ImprimeMuniciones();        
    }

    public void TomarDaño(int daño) {
        if (vida > 0 && puedePerderVida == 1) {
            puedePerderVida = 0;
            vida -= daño;
            DibujaVida(vida);
        }
        if (vida <= 0 && !haMuerto) {
            haMuerto = true;  
            if (ManagerDisparo.puntosPlayer > FileManager.record) { //Si se rompe el récord
                fm.GetComponent<FileManager>().SaveToFile(); //Se actualiza el archivo de récords
            }            
            StartCoroutine(EjecutaMuerte());
        }
    }

    public void ImprimeMuniciones() {
        if (ManagerDisparo.armaSeleccionada == 1) {
            proyectilesRestantes.text = "Tomates: " + ManagerDisparo.tomatesRestantes.ToString() + "/" + ManagerDisparo.capacidadArma;
        } else if (ManagerDisparo.armaSeleccionada == 2) {
            proyectilesRestantes.text = "Pollos: " + ManagerDisparo.pollosRestantes.ToString() + "/" + ManagerDisparo.capacidadArma;
        }
    }
       

    private void DibujaVida(int vida) {
        marcadorVidas.GetComponent<Image>().sprite = imgVidas[vida];
    }

    IEnumerator EjecutaMuerte() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;        
        yield return new WaitForSeconds(0.12f);
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }    

}
