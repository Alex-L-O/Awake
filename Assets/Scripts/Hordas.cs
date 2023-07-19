using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hordas : MonoBehaviour
{
    public int enemigosVivos;
    public static int numRonda;
    public GameObject[] puntosDeSpawn;
    public GameObject prefabEnemigo;
    public GameObject llave;

    private int limInf, limSup, numEnemigos;
    public static bool puertaAbierta = true;
    private bool puedeAumentarRonda = true;

    void Start()
    {
        numRonda = 0;
        llave.SetActive(false); //llave oculta al inicio del juego
    }

    void Update()
    {
        if (enemigosVivos == 0 && ControladorMenusjuego.iniciaJuego)
        {

            if (puedeAumentarRonda)
            {
                numRonda++;
                puedeAumentarRonda = false;
            }

            switch (numRonda)
            {
                case 1:
                    limInf = 0;
                    limSup = 1;
                    numEnemigos = 5;
                    break;
                case 2:

                    break;
            }

            //Obten posicion del ultimo alien muerto y dibuija en sea posicion la llave
            llave.transform.position = IAEnemigo.posUltimoAlien;
            llave.SetActive(true);
            //Hasta que se recoja el pedazo de bomba... calculo siguiente oleada
            if (ColisionesPlayer.puedeTomarBomba)
            {
                SiguienteOleada(numEnemigos, limInf, limSup);
                ColisionesPlayer.puedeTomarBomba = false;
            }
        }
    }

    private void SiguienteOleada(int n, int li, int ls)
    {
        for (int i = 0; i < n; i++)
        {
            int randomPos = Random.Range(li, ls);
            GameObject puntoEmision = puntosDeSpawn[randomPos];
            GameObject instanciaEnemigo = Instantiate(prefabEnemigo, puntoEmision.transform.position, Quaternion.identity);
            instanciaEnemigo.GetComponent<IAEnemigo>().hordas = GetComponent<Hordas>();
            enemigosVivos++;
        }
    }
}
