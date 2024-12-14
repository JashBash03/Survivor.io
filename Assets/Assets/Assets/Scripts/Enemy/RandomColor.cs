using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    [SerializeField] SpriteRenderer image;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] Gradient gradient;
    void Start()
    {
        ColorAndSpeed();
    }

    void ColorAndSpeed()
    {
        float randomT = Random.Range(0f, 1f);
        Color randomColor = gradient.Evaluate(randomT);

        if (image != null)
        {
            image.color = randomColor;

            float satMin = 0.0f;
            float satMax = 1.0f;
            float velMin = 5.0f;
            float velMax = 12.0f;

            float saturation = randomColor.maxColorComponent;
            float speed = ShiftRangeInLine(saturation, satMin, satMax, velMin, velMax);
        }
    }

    float ShiftRangeInLine(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }
}