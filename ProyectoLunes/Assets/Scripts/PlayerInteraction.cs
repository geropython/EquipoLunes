using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public InputActionReference interactAction;

    private BedInteractuable camaActual;

    private void OnEnable()
    {
        interactAction.action.Enable();
    }

    private void OnDisable()
    {
        interactAction.action.Disable();
    }

    private void Update()
    {
        if (interactAction.action.WasPressedThisFrame())
        {
            if (camaActual != null) camaActual.Dormir();
        }
    }

    public void EntrarEnInteraccion(BedInteractuable cama)
    {
        camaActual = cama;
        cama.MostrarTexto();
    }

    public void SalirDeInteraccion(BedInteractuable cama)
    {
        if (camaActual == cama)
        {
            camaActual = null;
            cama.OcultarTexto();
        }
    }
}