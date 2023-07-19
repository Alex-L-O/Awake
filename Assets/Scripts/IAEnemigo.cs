using UnityEngine;
using UnityEngine.AI;

public class IAEnemigo : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agente;
    private GameObject player;
    private float velEnemigo;
    private float dist;
    private float frecAtaque = 2.5f, tiempoSigAtaque = 0, iniciaConteo;
    public static int vidaEnemigo;

    public Hordas hordas;
    private Animator anim;

    public static Vector3 posUltimoAlien;

    void Start()
    {
        player = GameObject.Find("Capsule");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("caminando", true);
        dist = Vector3.Distance(player.transform.position, transform.position);
        agente.speed = Random.Range(1.0f, 5.0f); //Velocidad aleatoria del enemigo
        vidaEnemigo = 1;
    }

    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
        }
        else
        {
            tiempoSigAtaque = 0;
            agente.SetDestination(player.transform.position);
            VidasPlayer.puedePerderVida = 1;
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        { //Daño que el enemigo le genera al player
            anim.SetTrigger("ataca");
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;
            obj.transform.GetComponentInChildren<VidasPlayer>().TomarDaño(1);
        }
    }

    public void TomarDaño(int daño)
    {
        vidaEnemigo -= daño;
        if (vidaEnemigo <= 0)
        {
            hordas.enemigosVivos--;
            posUltimoAlien = gameObject.transform.position;
            Destroy(gameObject);
        }
    }


}
