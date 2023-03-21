﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Examples.AdditiveLevels
{
    public class FadeInOut : MonoBehaviour
    {
        // set these in the inspector
        [Range(0.01f, 10f), Tooltip("Rate of fade in / out: higher is faster")]
        public float stepRate = 0.02f;

        [Tooltip("Reference to Image component on child panel")]
        public Image fadeImage;

        [Tooltip("Color to use during scene transition")]
        public Color fadeColor = Color.black;

        /// <summary>
        /// Calculates FadeIn / FadeOut time.
        /// </summary>
        /// <returns>Duration in seconds</returns>
        public float GetDuration()
        {
            float frames = 1 / (stepRate * 0.1f);
            float frameRate = Time.deltaTime;
            float duration = frames * frameRate * 0.1f;
            Debug.Log($"GetDuration {stepRate} : {frames} * {frameRate} = {duration}");
            return duration;
        }

        public IEnumerator FadeIn()
        {
            float alpha = fadeImage.color.a;

            while (alpha < 1)
            {
                yield return null;
                alpha += stepRate * 0.1f;
                fadeColor.a = alpha;
                fadeImage.color = fadeColor;
            }
        }

        public IEnumerator FadeOut()
        {
            Debug.Log("FadeOut");
            float alpha = fadeImage.color.a;

            while (alpha > 0)
            {
                yield return null;
                alpha -= stepRate * 0.1f;
                fadeColor.a = alpha;
                fadeImage.color = fadeColor;
            }
        }
    }
}
