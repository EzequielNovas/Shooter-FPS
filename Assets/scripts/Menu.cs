using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void SeleccionarNivel(int numeroNivel)
    {
        SceneManager.LoadScene(numeroNivel);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game...");
    }
}