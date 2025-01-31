using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public GameObject winImage;
    public float displayTime = 5f; 

    private void Start()
    {
       
        winImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
           
            winImage.SetActive(true);

            
            Time.timeScale = 0f;

           
            StartCoroutine(ShowWinMessageAndReloadScene());
        }
    }

    
    private IEnumerator ShowWinMessageAndReloadScene()
    {
        
        yield return new WaitForSecondsRealtime(displayTime);

        
        winImage.SetActive(false);

        
        Time.timeScale = 1f;

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
