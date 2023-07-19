using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveMaestra : MonoBehaviour
{
    public GameObject LlavePlayer, lanzaTomate, lanzaPollo, llaveEnPiso;

    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "Player") {
            LlavePlayer.SetActive(true);
            lanzaTomate.SetActive(false);
            lanzaPollo.SetActive(false);
            llaveEnPiso.SetActive(false);
            IAEnemigo.posUltimoAlien = new Vector3(0, 0, 0);
        }        
    }  

}
