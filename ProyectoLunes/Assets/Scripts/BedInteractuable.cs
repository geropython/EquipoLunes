using UnityEngine;
using TMPro;
public class BedInteractuable : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textoDormir;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInteraction interaction = other.GetComponent<PlayerInteraction>();

            if (interaction != null)
            {
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
        if (GameManager.Instance != null) GameManager.Instance.Dormir();
        else Debug.LogError("No existe un GameManager."); 
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInteraction interaction = other.GetComponent<PlayerInteraction>();
            if (interaction != null) interaction.SalirDeInteraccion(this);  
        }
    }
}