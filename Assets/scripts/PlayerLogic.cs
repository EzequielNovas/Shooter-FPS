using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public HP vida;
    public bool Vida0 = false;
    [SerializeField] private Animator animadorPerder;
    public Score score;

    // Use this for initialization
    void Start()
    {
        vida = GetComponent<HP>();
        score.valor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
    }

    void RevisarVida()
    {
        if (Vida0) return;
        if (vida.valor <= 0)
        {
            AudioListener.volume = 0;
            Vida0 = true;
            Invoke("ReiniciarJuego", 1f);
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        score.valor = 0;
        AudioListener.volume = 1;
    }


}