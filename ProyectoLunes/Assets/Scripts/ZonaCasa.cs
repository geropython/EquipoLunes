using UnityEngine;

public class ZonaCasa : MonoBehaviour
{
    public AvisoDormir avisoDormir;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) avisoDormir.EntrarEnCasa();
    }
}
