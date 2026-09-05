using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FantasyActivation : MonoBehaviour
{
    private Volume _volume;
    private GrayScaleSettings _grayscale;
    [SerializeField] private KeyCode _fantasy = KeyCode.Q;

    void Start()
    {
        _volume = GetComponent<Volume>();

        _volume.profile.TryGet<GrayScaleSettings>(out _grayscale);
    }


    void Update()
    {
        if (Input.GetKeyDown(_fantasy)) Fantasy();
    }

    private void Fantasy()
    {
        _grayscale.strenght.value = _grayscale.strenght.value == 0 ? 1 : 0;
    }
}
