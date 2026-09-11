using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private AudioSource jogar;
    [SerializeField] 
    private VideoPlayer inicio;
    [SerializeField] 
    private GameObject menu;
    public void OnJogar()
    {
        jogar.Play();
        inicio.Play();
        menu.SetActive(false);
        inicio.loopPointReached += VideoTerminou;
    }

    public void OnSair() => print("Sair");

    private void VideoTerminou(VideoPlayer video)
    {
        SceneManager.LoadScene(0);
    }
}
