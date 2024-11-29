using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float secondsForADay = 120;

    void Update()
    {
        float rotationStep = 360 / secondsForADay * Time.deltaTime;
        transform.Rotate(0, 0, rotationStep, Space.World);
    }
}
