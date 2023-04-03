using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public MusicManager _musicManager;
    [SerializeField] private GameObject menuLose;
    public HP vida;
    public bool Vida0 = false;
    public GameObject HUD;
    public Score score;


    // Use this for initialization
    void Start()
    {
        vida = GetComponent<HP>();
        Time.timeScale= 1.0f;
    }

    void Update()
    {
      if (vida.valor == 0)
      {
          menuLose.gameObject.SetActive(true);
            Time.timeScale = 0f;
          _musicManager.SwitchMusic(menuLose);
          HUD.SetActive(false);
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
      }

    }
}