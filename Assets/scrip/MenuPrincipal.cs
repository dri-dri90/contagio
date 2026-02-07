using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJogo()
    {
        // Carrega a próxima cena na lista do Build (Index 1)
        SceneManager.LoadScene(1); 
    }
}