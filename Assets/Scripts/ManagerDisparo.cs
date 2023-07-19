using System;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDisparo : MonoBehaviour
{
    public Camera playerCamera;

    public GameObject objPistola, objRifle, objSciFiWeapon;
    public GameObject origenDisparo, tomate, huevo;

    public Arma pistola;
    public Arma rifle;
    public Arma SciFiWeapon;
    
    public static float rango;
    [SerializeField] private float frecuenciaDisparo;
    public static int dañoCausado;
    public static int capacidadArma;
    public static int tomatesRestantes, pollosRestantes;

    private float TiempoDisparo; //Tiempo para poder disparar    

    [SerializeField]private LayerMask lMask, otro;

    
    public static int puntosPlayer; //Puntos de la partida, posteriormente serán almacenados en el archivo de récords
    public static int enemigosEliminados;
    public static int armaSeleccionada = 1; //1-Tomate (default), 2- Huevo

    public Image btnTomate, btnHuevo;
    public Sprite tomate0, tomate1, huevo0, huevo1;

    private AudioSource reproductor;
    public AudioClip sndPollo, sndTomate, sndIntro;


    private void Awake() {
        //Instancias de las armas a utilizar en el juego
        pistola = new Arma(21, 1.0f, 1, 20);
        rifle = new Arma(50, 0.25f, 2, 10);
        SciFiWeapon = new Arma(77, 1.5f, 5, 1);
        reproductor = gameObject.GetComponent<AudioSource>();
    }

    private void Start() {
        reproductor.PlayOneShot(sndIntro);
        // Carga la pistola por default
        OcultaArmas();
        objPistola.SetActive(true);
        rango = pistola.alcance;
        frecuenciaDisparo = pistola.frecuenciaDisparo;
        dañoCausado = pistola.dañoCausado;
        capacidadArma = pistola.capacidad;
        puntosPlayer = 0; //Iniciamos en 0 los puntos de la partida
        enemigosEliminados = 0;
        btnTomate.GetComponent<Image>().sprite = tomate1;
        btnHuevo.GetComponent<Image>().sprite = huevo0;
        tomatesRestantes = pistola.capacidad;
        pollosRestantes = rifle.capacidad;
    }


    void Update() {
        CambiaArma();
        TiempoDisparo += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && TiempoDisparo > frecuenciaDisparo) {
            Dispara();
        }
    }

    private void CambiaArma() {        
        if (Input.GetKeyUp(KeyCode.Alpha1) ) { //Tomate
            reproductor.PlayOneShot(sndTomate);
            armaSeleccionada = 1;
            btnTomate.GetComponent<Image>().sprite = tomate1;
            btnHuevo.GetComponent<Image>().sprite = huevo0;
            OcultaArmas();
            objPistola.SetActive(true);
            rango = pistola.alcance;
            frecuenciaDisparo = pistola.frecuenciaDisparo;
            dañoCausado = pistola.dañoCausado;
            capacidadArma = pistola.capacidad;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2)) { //Pollo
            reproductor.PlayOneShot(sndTomate);
            armaSeleccionada = 2;
            btnTomate.GetComponent<Image>().sprite = tomate0;
            btnHuevo.GetComponent<Image>().sprite = huevo1;
            OcultaArmas();
            objRifle.SetActive(true);
            rango = rifle.alcance;
            frecuenciaDisparo = rifle.frecuenciaDisparo;
            dañoCausado = rifle.dañoCausado;
            capacidadArma = rifle.capacidad;
        }

    }

    private void Dispara() {
        if (armaSeleccionada == 1) {            
            if (tomatesRestantes > 0) {
                reproductor.PlayOneShot(sndTomate);
                GameObject tomatoe = Instantiate(tomate, origenDisparo.transform.position, Quaternion.identity);
                tomatesRestantes--;
            }
        } else if (armaSeleccionada == 2) {
            if (pollosRestantes > 0) {
                reproductor.PlayOneShot(sndPollo);
                GameObject egg = Instantiate(huevo, origenDisparo.transform.position, Quaternion.identity);
                pollosRestantes--;
            }            
        }               
        TiempoDisparo = 0;
    }

    private void OcultaArmas() {
        objPistola.SetActive(false);
        objRifle.SetActive(false);
        objSciFiWeapon.SetActive(false);
    }


}
