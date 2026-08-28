using UnityEngine;

public class EnterScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        // Escuela
        if (CompareTag("TriggerSchool"))
        {
            Debug.Log("Entraste a la Escuela.");
            GameManager.Instance.CargarEscena("Escuela");
        }
        // Casa
        if (CompareTag("TriggerHouse"))
        {
            Debug.Log("Entraste a la Casa.");
            GameManager.Instance.CargarEscena("Casa");
        }
        // Salir
        if (CompareTag("Exit"))
        {
            Debug.Log("Salida.");
            GameManager.Instance.CargarEscena("Main_Scene");
        }
    }
}
