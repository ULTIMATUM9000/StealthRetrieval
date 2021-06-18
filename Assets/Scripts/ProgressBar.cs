using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    public void SetMax(float progress)
    {
        slider.maxValue = progress;
        slider.value = progress;
    }

    public void Set(float progress)
    {
        slider.value = progress;
    }
}
