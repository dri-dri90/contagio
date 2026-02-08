using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class LoadScenes : MonoBehaviour
{
    // ===== CENAS =====

    // Botão PLAY → vai para o jogo usando o número (Index) da cena
    public void Play()
    {
        Debug.Log("Botão Play clicado!"); // Verifique isso no Console!
        // Usamos o número 1 porque é o índice da SampleScene no seu Build Settings
        SceneManager.LoadScene(1); 
    }

    // Voltar para a tela inicial (Index 0)
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        // Se a cena de créditos não tiver número, use o nome entre aspas
        SceneManager.LoadScene("Credits");
    }

    // ===== SAIR DO JOGO =====

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("O comando de sair foi executado");
    }
}