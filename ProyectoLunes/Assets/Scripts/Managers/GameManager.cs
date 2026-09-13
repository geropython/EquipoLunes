using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Tiempo")]
    public float Hora = 12f;
    public int Dia = 1;

    private void Awake()
    {
        // Evitar duplicados
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CargarEscena(string nombreEscena)
    {
        StartCoroutine(CambiarEscena(nombreEscena));
    }

    private IEnumerator CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
        // Esperar a que Unity termine de cargar la escena
        yield return null;
    }

    public void Dormir()
    {
        StartCoroutine(DormirCoroutine());
    }

    private IEnumerator DormirCoroutine()
    {
        // Avanzar el día
        Dia++;
        // Establecer las 06:00
        Hora = 6f;
        // Volver al mapa principal
        SceneManager.LoadScene("Main_Scene");
        // Esperar a que cargue
        yield return null;
    }
}