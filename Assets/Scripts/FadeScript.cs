﻿using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.5f;
    int drawDepth = -1000;
    float alpha = 1.0f;
    int fadeDir = -1;
    void OnGUI() {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.b, GUI.color.g, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }
    public float StartFade(int direction) {
        fadeDir = direction;
        return (fadeSpeed);
    }
    void OnLevelWasLoaded() {
        StartFade(-1);
    }
}
