using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // ===== CENAS =====

    // Voltar para a tela inicial
    public void MenuScene()
    {
        SceneManager.LoadScene("tela inicial");
    }

    // Botão PLAY → vai para o jogo
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void SelectLevels()
    {
        SceneManager.LoadScene("SelectLevels");
    }

    // ===== LINKS =====

    public void InstagramMarks()
    {
        Application.OpenURL("https://www.instagram.com/marksviniciusmoraes/");
    }

    public void InstagramRomulo()
    {
        Application.OpenURL("https://www.instagram.com/romulomorais/");
    }

    // ===== SAIR DO JOGO =====

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}