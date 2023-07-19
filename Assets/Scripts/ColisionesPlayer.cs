using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesPlayer : MonoBehaviour
{
    public GameObject LlavePlayer, lanzaTomate, lanzaPollo, llaveEnPiso;
    public static bool puedeTomarBomba = true;

    private void OnTriggerEnter(Collider obj) {
        if (puedeTomarBomba) {
            if (obj.tag == "bomba1") {
                Debug.Log("bomba 1");
                puedeTomarBomba = false;
                Destroy(obj.gameObject);
            }
            if (obj.tag == "bomba2") {
                puedeTomarBomba = false;
                Destroy(obj.gameObject);
            }
            if (obj.tag == "bomba3") {
                puedeTomarBomba = false;
                Destroy(obj.gameObject);
            }
            if (obj.tag == "bomba4") {
                puedeTomarBomba = false;
                Destroy(obj.gameObject);
            }
            if (obj.tag == "bomba5") {
                puedeTomarBomba = false;
                Destroy(obj.gameObject);
            }
        }        

        if (obj.tag == "llave") {
            LlavePlayer.SetActive(true);
            lanzaTomate.SetActive(false);
            lanzaPollo.SetActive(false);
            llaveEnPiso.SetActive(false);
            IAEnemigo.posUltimoAlien = new Vector3(0, 0, 0);
        }


    }
}
