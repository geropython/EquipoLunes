using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Tiempo")]
    public float Hora = 12f;
    public int Dia = 1;

    [Header("Fade")]
    public CanvasGroup fade;
    public float duracionFade = 1f;

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
        // Fade Out
        yield return StartCoroutine(Fade(0f, 1f));
        SceneManager.LoadScene(nombreEscena);
        // Esperar a que Unity termine de cargar la escena
        yield return null;
        // Fade In
        yield return StartCoroutine(Fade(1f, 0f));
    }

    public void Dormir()
    {
        StartCoroutine(DormirCoroutine());
    }

    private IEnumerator DormirCoroutine()
    {
        // Fade Out
        yield return StartCoroutine(Fade(0f, 1f));
        // Avanzar el día
        Dia++;
        // Establecer las 06:00
        Hora = 6f;
        // Volver al mapa principal
        SceneManager.LoadScene("Main_Scene");
        // Esperar a que cargue
        yield return null;
        // Fade In
        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float inicio, float final)
    {
        if (fade == null) yield break;
        float tiempo = 0f;
        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo / duracionFade;
            fade.alpha = Mathf.Lerp(inicio, final, progreso);
            yield return null;
        }
        fade.alpha = final;
    }
}