using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
public static class GamePrefs
{
    public static bool ServoOn = true;
    public static bool SoundOn = true;

    public static bool GameStart = true;

    public static int ResetCounter = 4;
    public static int ServoSpeed = 1;
    public static int NewCodeSpeed = 30;
    public static float MusicVol = 0.35f;

    public static bool EndlessMode = true;

    public static string LastTimer;

    public static string LastName = "Player";

    // Add led n screen values
}