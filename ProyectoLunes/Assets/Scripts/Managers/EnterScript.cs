using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        // Escuela
        if (CompareTag("TriggerSchool"))
        {
            Debug.Log("Entraste a la Escuela.");
            SceneManager.LoadScene("Escuela");
        }
        // Casa
        if (CompareTag("TriggerHouse"))
        {
            Debug.Log("Entraste a la Casa.");
            SceneManager.LoadScene("Casa");
        }
        // Salir
        if (CompareTag("Exit"))
        {
            Debug.Log("Salida.");
            SceneManager.LoadScene("Main_Scene");
        }
    }
}
