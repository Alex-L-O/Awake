using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectaObjetos : MonoBehaviour
{
    public AudioClip sndEncuentra;
    private AudioSource reproductor;
    private GameObject jugador;

    private void Start() {
        reproductor = gameObject.GetComponent<AudioSource>();
        jugador = GameObject.Find("Capsule");
    }
    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "tomate") {
            reproductor.PlayOneShot(sndEncuentra);
            ManagerDisparo.armaSeleccionada = 1;
            ManagerDisparo.tomatesRestantes = 20;
            ManagerDisparo.capacidadArma = 20;
            jugador.GetComponent<VidasPlayer>().ImprimeMuniciones();
            
            Destroy(obj.gameObject);
        }
        if (obj.tag == "pollo") {
            reproductor.PlayOneShot(sndEncuentra);
            ManagerDisparo.armaSeleccionada = 2;
            ManagerDisparo.pollosRestantes = 10;
            ManagerDisparo.capacidadArma = 10;
            jugador.GetComponent<VidasPlayer>().ImprimeMuniciones();
            Destroy(obj.gameObject);
        }

    }

}
