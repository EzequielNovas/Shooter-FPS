using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyLogic : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agente;
    private HP HP;
    private Animator animator;
    private Collider collider;
    private HP HPPlayer;
    private PlayerLogic PlayerLogic;
    public bool Vida0 = false;
    public bool estaAtacando = false;
    public float speed = 1.0f;
    public float angularSpeed = 120;
    public float da�o = 25;
    public bool mirando;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player");
        HPPlayer = target.GetComponent<HP>();
        if (HPPlayer == null)
        {
            throw new System.Exception("El objeto Jugador no tiene componente Vida");
        }

        PlayerLogic = target.GetComponent<PlayerLogic>();

        if (PlayerLogic == null)
        {
            throw new System.Exception("El objeto Jugador no tiene componente EnemyLogic");
        }

        agente = GetComponent<NavMeshAgent>();
        HP = GetComponent<HP>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        Perseguir();
        RevisarAtaque();
        EstaDefrenteAlJugador();
    }

    void EstaDefrenteAlJugador()
    {
        Vector3 adelante = transform.forward;
        Vector3 targetJugador = (GameObject.Find("Player").transform.position - transform.position).normalized;

        if (Vector3.Dot(adelante, targetJugador) < 0.6f)
        {
            mirando = false;
        }
        else
        {
            mirando = true;
        }
    }

    void RevisarVida()
    {
        if (Vida0) return;
        if (HP.valor <= 0)
        {
            Vida0 = true;
            agente.isStopped = true;
            collider.enabled = false;
            animator.CrossFadeInFixedTime("Vida0", 0.1f);
            Destroy(gameObject, 3f);
        }

    }

    void Perseguir()
    {
        if (Vida0) return;
        if (PlayerLogic.Vida0) return;
        agente.destination = target.transform.position;
    }

    void RevisarAtaque()
    {
        if (Vida0) return;
        if (estaAtacando) return;
        if (PlayerLogic.Vida0) return;
        float distanciaDelBlanco = Vector3.Distance(target.transform.position, transform.position);

        if (distanciaDelBlanco <= 2.0 && mirando)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        HPPlayer.RecibirDa�o(da�o);
        agente.speed = 0;
        agente.angularSpeed = 0;
        estaAtacando = true;
        animator.SetTrigger("DebeAtacar");
        Invoke("ReiniciarAtaque", 1.5f);
    }

    void ReiniciarAtaque()
    {
        estaAtacando = false;
        agente.speed = speed;
        agente.angularSpeed = angularSpeed;
    }

}
