using UnityEngine;

public class Tomate : MonoBehaviour
{
    private GameObject camara;

    void Start() {        
        camara = GameObject.Find("Main Camera");
        this.GetComponent<Rigidbody>().velocity = camara.transform.forward * ManagerDisparo.rango;
    }

    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "Enemigo") {
            ManagerDisparo.enemigosEliminados++;
            float puntosDistancia = Vector3.Distance(gameObject.transform.position, camara.transform.position);
            ManagerDisparo.puntosPlayer += (int)puntosDistancia;
            obj.gameObject.GetComponent<IAEnemigo>().TomarDaño(ManagerDisparo.dañoCausado);
            Destroy(this.gameObject);          
        }
        if (obj.tag == "Objetos") {
            Destroy(this.gameObject);
        }
    }


}
