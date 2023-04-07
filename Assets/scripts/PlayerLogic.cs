using UnityEngine;
public class PlayerLogic : MonoBehaviour
{
    public MusicManager _musicManager;
    [SerializeField] private GameObject menuLose;
    public HP _hp;
    public GameObject HUD;
    public Score score;
    public bool hp0 = false;
    void Start()
    {
        _hp = GetComponent<HP>();
        Time.timeScale= 1.0f;
    }

    void Update()
    {
      if (_hp.value == 0)
      {
          menuLose.gameObject.SetActive(true);
          Time.timeScale   = 0f;
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible   = true;
          _musicManager.SwitchMusic(menuLose);
          HUD.SetActive(false);
      }
    }
}