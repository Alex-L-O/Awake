using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Disparo : MonoBehaviour
{
    public Camera playerCamera;
    public Transform origenRayo;
    private float rango = 77.7f;
    public float duracion = 0.1f;
    public float frecuenciaDisparo = 0.25f;

    private LineRenderer rayoLaser;
    private float TiempoDisparo;


    private int dañoCausado = 1;
    [SerializeField] LayerMask lMask;

    private void Awake() {
        rayoLaser = GetComponent<LineRenderer>();
    }


    void Update()
    {
        TiempoDisparo += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && TiempoDisparo > frecuenciaDisparo)
        {
            Dispara();
        }
    }

    private void Dispara()
    {
        TiempoDisparo = 0;
        rayoLaser.SetPosition(0, origenRayo.position); //establece coordenada de origen
        Vector3 origen = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(origen, playerCamera.transform.forward, out hit, rango, lMask))
        {
            rayoLaser.SetPosition(1, hit.point); //establece coordenada final de impacto
            Debug.Log(hit.transform.gameObject.name);
            Destroy(hit.transform.gameObject);

            IAEnemigo enemigo = hit.transform.GetComponent<IAEnemigo>();
            if (enemigo != null)
            {
                Debug.Log(hit.collider.name);
                enemigo.TomarDaño(dañoCausado);
            }
            else
            {
                Debug.Log(hit.collider.name);
            }
        }
        else
        {
            rayoLaser.SetPosition(1, origen + (playerCamera.transform.forward) * rango);
        }

        StartCoroutine(DisparaLaser());

    }

    IEnumerator DisparaLaser()
    {
        rayoLaser.enabled = true;
        yield return new WaitForSeconds(duracion);
        rayoLaser.enabled = false;
    }

}
