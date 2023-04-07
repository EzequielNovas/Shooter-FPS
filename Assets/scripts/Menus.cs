using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Menus : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private AudioMixer audioMixerMusic;
    [SerializeField] private AudioMixer audioMixerGeneral;
    private MusicManager _musicManager;
    public bool juegoPausado = false;


    private void Start() => _musicManager = Camera.main.GetComponent<MusicManager>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                Resume();
            else
                Pausa();
        }
    }

    public void Pausa()
    {
        juegoPausado     = true;
        Time.timeScale   = 0f;
        Cursor.lockState = CursorLockMode.None;
        _musicManager.SwitchMusic(juegoPausado);
        menuPausa.SetActive(true);
    }

    public void Resume()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _musicManager.SwitchMusic(juegoPausado);
        menuPausa.SetActive(false);
        menuOptions.SetActive(false);
    }
    public void BackToMenu() => SceneManager.LoadScene(0);

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void ChangeVolumeMusic(float volume) => audioMixerMusic.SetFloat("Volume0", volume);

    public void ChangeVolumeGeneral(float volume) => audioMixerGeneral.SetFloat("Volume1", volume);

    public void ChangeQuality(int index) => QualitySettings.SetQualityLevel(index);

    public void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
