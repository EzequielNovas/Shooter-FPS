using UnityEngine;
using UnityEngine.AI;
public class EnemyLogic : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    private HP _HP;
    private Animator animator;
    private Collider collider;
    private HP HPPlayer;
    private PlayerLogic PlayerLogic;
    public AudioSource audioSource;
    public  GameObject screenScore;
    public AudioClip scream;
    public bool hp0 = false;
    public bool isAttacking = false;
    public bool looking;
    public bool addPoints = false;
    public float speed = 1.0f;
    public float angularSpeed = 120;
    public float damage = 25;

    void Start()
    {
        target = GameObject.Find("Player");
        HPPlayer = target.GetComponent<HP>();
        if (HPPlayer == null) 
            throw new System.Exception("The Player item has no Life component.");
      
        PlayerLogic = target.GetComponent<PlayerLogic>();

        if (PlayerLogic == null)
            throw new System.Exception("The Player object has no EnemyLogic component");

        agent    = GetComponent<NavMeshAgent>();
        _HP      = GetComponent<HP>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        ReviewLife();
        Chase();
        CheckAttack();
        InFrontOfThePlayer();
    }

    void InFrontOfThePlayer()
    {
        Vector3 adelante = transform.forward;
        Vector3 targetJugador = (GameObject.Find("Player").transform.position - transform.position).normalized;

        if (Vector3.Dot(adelante, targetJugador) < 0.6f)
        
            looking = false;
        else
        
            looking = true;
    }

    void ReviewLife()
    {
        if (hp0) return;
        if (_HP.value <= 0)
        {
            addPoints = true;
            if (addPoints)
            {
                screenScore.GetComponent<Score>().value += 1;
                addPoints = false; 
            }
            hp0 = true;
            agent.isStopped = true;
            collider.enabled = false;
            animator.CrossFadeInFixedTime("hp0", 0.1f);
            Destroy(gameObject, 3f);
        }
    }

    void Chase()
    {
        if (hp0) return;
        if (PlayerLogic.hp0) return;
        agent.destination = target.transform.position;
    }

    void CheckAttack()
    {
        if (hp0) return;
        if (isAttacking) return;
        if (PlayerLogic.hp0) return;
        float distanciaDelBlanco = Vector3.Distance(target.transform.position, transform.position);

        if (distanciaDelBlanco <= 2.0 && looking)
        Attack();
    }

    void Attack()
    {
        HPPlayer.TakeDamage(damage);
        audioSource.PlayOneShot(scream);
        agent.speed = 0;
        agent.angularSpeed = 0;
        isAttacking = true;
        animator.SetTrigger("MustAttack");
        Invoke("ResetAttack", 1.5f);
    }

    void ResetAttack()
    {
        isAttacking = false;
        agent.speed = speed;
        agent.angularSpeed = angularSpeed;
    }
}
