using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLoadScene : MonoBehaviour
{

    public Cena cenaSelecionada;

    public void TrocarCena()
    {
      
        SceneManager.LoadScene(cenaSelecionada.ToString());
    }
}
