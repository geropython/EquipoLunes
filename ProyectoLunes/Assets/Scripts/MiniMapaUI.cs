using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MiniMapaUI : MonoBehaviour
{
    public RectTransform mapa;

    [Header("Tamaño")]
    public Vector2 tamanoNormal = new Vector2(400, 400);
    public Vector2 tamanoGrande = new Vector2(600, 600);

    [Header("Posición")]
    public Vector2 posicionNormal = new Vector2(-150, 150);
    public Vector2 posicionGrande = Vector2.zero;

    [Header("Animación")]
    public float duracionAnimacion = 0.4f;

    [Header("Input")]
    public InputActionReference teclaMapa;

    private bool mapaGrande = false;
    private Coroutine animacion;

    private void OnEnable()
    {
        teclaMapa.action.Enable();
    }

    private void OnDisable()
    {
        teclaMapa.action.Disable();
    }

    private void Update()
    {
        if (teclaMapa.action.WasPressedThisFrame())
        {
            mapaGrande = !mapaGrande;

            if (animacion != null)
                StopCoroutine(animacion);

            if (mapaGrande)
            {
                animacion = StartCoroutine(AnimarMapa(
                    mapa.sizeDelta,
                    tamanoGrande,
                    mapa.anchoredPosition,
                    posicionGrande
                ));
            }
            else
            {
                animacion = StartCoroutine(AnimarMapa(
                    mapa.sizeDelta,
                    tamanoNormal,
                    mapa.anchoredPosition,
                    posicionNormal
                ));
            }
        }
    }

    private IEnumerator AnimarMapa(
        Vector2 tamanoInicial,
        Vector2 tamanoFinal,
        Vector2 posicionInicial,
        Vector2 posicionFinal)
    {
        float tiempo = 0f;

        while (tiempo < duracionAnimacion)
        {
            tiempo += Time.deltaTime;

            float progreso = tiempo / duracionAnimacion;

            // Animación suave
            progreso = Mathf.SmoothStep(0f, 1f, progreso);

            mapa.sizeDelta = Vector2.Lerp(
                tamanoInicial,
                tamanoFinal,
                progreso
            );

            mapa.anchoredPosition = Vector2.Lerp(
                posicionInicial,
                posicionFinal,
                progreso
            );

            yield return null;
        }

        mapa.sizeDelta = tamanoFinal;
        mapa.anchoredPosition = posicionFinal;

        animacion = null;
    }
}
