using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VibrationHandler
{
    public static void Vibrate()
    {
        if (PlayerHelper.Instance.Player.IsVibrationOn)
            Handheld.Vibrate();
    }
}
