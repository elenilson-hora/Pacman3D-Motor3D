using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnJogar() => SceneManager.LoadScene(0);

    public void OnSair() => print("Sair");
}
