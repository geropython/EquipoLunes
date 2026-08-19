using UnityEngine;
using TMPro;

public class AvisoDormir : MonoBehaviour
{
    public CicloDiaNoche cicloDiaNoche;
    public TMP_Text mensajeDormir;

    private bool estaEnCasa = false;
    void Start()
    {
        mensajeDormir.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (cicloDiaNoche.Hora >= 20f && !estaEnCasa) mensajeDormir.gameObject.SetActive(true);
        else mensajeDormir.gameObject.SetActive(false);
    }
    public void EntrarEnCasa()
    {
        estaEnCasa = true;
        mensajeDormir.gameObject.SetActive(false);
    }
}
