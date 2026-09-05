using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable, VolumeComponentMenu("Basics/Grayscale")]
public class GrayScaleSettings : VolumeComponent, IPostProcessComponent
{
    public ClampedFloatParameter strenght = new(0.0f, min: 0.0f, max: 1.0f);

    public bool IsActive()
    {
        return strenght.value > 0.0f && active;
    }
}
