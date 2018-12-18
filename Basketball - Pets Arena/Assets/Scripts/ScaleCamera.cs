using UnityEngine;
using System.Collections;

public class ScaleCamera : MonoBehaviour
{
    public float PIXELS_TO_UNITS = 56f;
    void Awake()
    {
        float currentRatio = (float)Screen.width / (float)Screen.height;
        float TARGET_WIDTH = 1280;
        float TARGET_HEIGHT = 720;
        float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
        if (currentRatio > desiredRatio)
        {
            Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS;
        }
        else
        {
            float differenceInSize = desiredRatio / currentRatio;
            Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS * differenceInSize;
        }

    }
}
