using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{ 
    public float valor;
    public Score score;
    public Text text;
    public GameObject victoryMenu;
    public MusicManager musicManager;
    public int poinsToWin = 15;
    public GameObject HUD;



    void Start()
    {
       score.valor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score " + score.valor;
        if (score.valor >= poinsToWin)
        {
           Invoke("Victory", 0.5f);
        }
    }

    public void Victory()
    {
        victoryMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        musicManager.SwitchMusic(enabled);
        HUD.SetActive(false);

    }
}
