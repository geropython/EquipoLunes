using UnityEngine;
using TMPro;

public class CicloDiaNoche : MonoBehaviour
{
    [Range(0.0f, 24f)] public float Hora = 12;
    public Transform Sol;
    public TMP_Text TextoHora;
    public GameObject LimitTime;
    public float DuracionDelDiaEnMinutos = 10f;
    private float SolX;
    private bool stopTime = false;
    private bool timePaused = false;

    private void Start()
    {
        if (LimitTime != null) LimitTime.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LimitTime.SetActive(true);           
        }
    }

    private void Update()
    {
        if (stopTime || timePaused) return;

        Hora += Time.deltaTime * (24f / (60f * DuracionDelDiaEnMinutos));
        if (Hora >= 12f)
        {
            Hora = 12f;
            stopTime = true;
            // Time.timeScale = 0f;
            if (LimitTime != null) LimitTime.SetActive(true);
        }
        RotacionSol();
        ActualizarUI();
    }

    public void SetTimePaused(bool paused)
    {
        timePaused = paused;
    }

    void RotacionSol()
    {
        SolX = 15 * Hora;
        Sol.localEulerAngles = new Vector3(SolX, 0, 0);
        if (Hora < 6 || Hora > 18) Sol.GetComponent<Light>().intensity = 0f;
        else Sol.GetComponent<Light>().intensity = 1f;
    }
    void ActualizarUI()
    {
        int horas = Mathf.FloorToInt(Hora);
        int minutos = Mathf.FloorToInt((Hora - horas) * 60);
        TextoHora.text = string.Format("{0:00}:{1:00}", horas, minutos);
    }
}