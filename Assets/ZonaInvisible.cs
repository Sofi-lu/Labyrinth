using UnityEngine;

public class ZonaInvisible : MonoBehaviour
{
    private PlayerMovement playerMovement;  

    void Start()
    {
        
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            if (playerMovement != null)
            {
                playerMovement.velocidad = 0;  
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            if (playerMovement != null)
            {
                playerMovement.velocidad = 8.0f;  
            }
        }
    }
}
