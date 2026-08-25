using UnityEngine;
using StarterAssets;

public class MapUI : MonoBehaviour
{
    [SerializeField] private GameObject mapUI;
    [SerializeField] private CicloDiaNoche cicloDiaNoche;
    [SerializeField] private ThirdPersonController playerController;

    private bool mapIsOpen;

    private void Awake()
    {
        if (cicloDiaNoche == null) cicloDiaNoche = FindFirstObjectByType<CicloDiaNoche>();
        if (playerController == null) playerController = FindFirstObjectByType<ThirdPersonController>();
    }

    private void Start()
    {
        mapUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMapUI();
        }
    }
    //M for Open/Close Map
    public void ToggleMapUI()
    {
        mapIsOpen = !mapIsOpen;
        mapUI.SetActive(mapIsOpen);

        if (cicloDiaNoche != null) cicloDiaNoche.SetTimePaused(mapIsOpen);
        if (playerController != null) playerController.enabled = !mapIsOpen;
    }
}
