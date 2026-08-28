using UnityEngine;
using TMPro;
public class BedInteractuable : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textoDormir;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entró al trigger de la cama: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador entró en la cama!");

            PlayerInteraction interaction = other.GetComponent<PlayerInteraction>();

            if (interaction != null)
            {
                Debug.Log("PlayerInteraction encontrado.");
                interaction.EntrarEnInteraccion(this);
            }
            else Debug.LogError("El Player NO tiene PlayerInteraction.");
        }
    }
    public void MostrarTexto()
    {
        if (textoDormir != null) textoDormir.gameObject.SetActive(true);
    }

    public void OcultarTexto()
    {
        if (textoDormir != null) textoDormir.gameObject.SetActive(false);
    }

    public void Dormir()
    {
        Debug.Log("El jugador se va a dormir.");
        if (GameManager.Instance != null) GameManager.Instance.Dormir();
        else Debug.LogError("No existe un GameManager."); 
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Algo salió del trigger de la cama: " + other.name);

        if (other.CompareTag("Player"))
        {
            PlayerInteraction interaction = other.GetComponent<PlayerInteraction>();
            if (interaction != null) interaction.SalirDeInteraccion(this);  
        }
    }
}