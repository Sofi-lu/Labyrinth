using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public Image iconoMusica;  
    public Image iconoRedo;   
    public AudioSource musica; 

    private bool musicaActiva = true;
    public GameObject startGameImage;

    void Start()
    {
        iconoMusica.color = new Color(1, 1, 1, 1); 
        iconoRedo.color = new Color(1, 1, 1, 1);
        startGameImage.SetActive(true);

        if (musica != null)
        {
            musica.loop = true;  // Hace que la música se repita
            musica.Play();       // Comienza a reproducir la música
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            startGameImage.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))  
        {
            ReiniciarNivel();
           
}
    }



    public void ToggleMusica()
    {
        musicaActiva = !musicaActiva;

        if (musicaActiva)
        {
            musica.Play();
            iconoMusica.color = new Color(1, 1, 1, 1); 
        }
        else
        {
            musica.Pause();
            iconoMusica.color = new Color(1, 1, 1, 0.5f); 
        }
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
