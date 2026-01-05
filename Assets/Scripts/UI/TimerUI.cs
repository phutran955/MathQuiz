using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Slider slider;

    public void UpdateTime(float current, float max)
    {
        slider.value = current / max;
    }
}
