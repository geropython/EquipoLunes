using UnityEngine;
using System.Collections;

public class MiniMapaUI : MonoBehaviour
{
    public RectTransform mapa;

    [Header("Tamaño")]
    public Vector2 tamanoNormal = new Vector2(250, 250);
    public Vector2 tamanoGrande = new Vector2(600, 600);

    [Header("Posición")]
    public Vector2 posicionNormal = new Vector2(-150, -150);
    public Vector2 posicionGrande = Vector2.zero;

    [Header("Animación")]
    public float duracionAnimacion = 0.4f;

    private bool mapaGrande = false;
    private Coroutine animacion;

    void Start()
    {
        mapa.sizeDelta = tamanoNormal;
        mapa.anchoredPosition = posicionNormal;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapaGrande = !mapaGrande;
            if (animacion != null) StopCoroutine(animacion);
            if (mapaGrande) animacion = StartCoroutine(AnimarMapa(tamanoNormal,tamanoGrande,posicionNormal,posicionGrande));
            else animacion = StartCoroutine(AnimarMapa(tamanoGrande,tamanoNormal,posicionGrande,posicionNormal));
        }
    }

    IEnumerator AnimarMapa(Vector2 tamanoInicial,Vector2 tamanoFinal,Vector2 posicionInicial,Vector2 posicionFinal)
    {
        float tiempo = 0f;
        while (tiempo < duracionAnimacion)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo / duracionAnimacion;
            // Hace que la animación sea más suave
            progreso = Mathf.SmoothStep(0f, 1f, progreso);
            mapa.sizeDelta = Vector2.Lerp(tamanoInicial,tamanoFinal,progreso);
            mapa.anchoredPosition = Vector2.Lerp(posicionInicial,posicionFinal,progreso);
            yield return null;
        }
        mapa.sizeDelta = tamanoFinal;
        mapa.anchoredPosition = posicionFinal;
        animacion = null;
    }
}
