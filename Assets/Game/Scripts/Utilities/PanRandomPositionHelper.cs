using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class PanRandomPositionHelper 
{
    public static Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(CONSTANTS.PAN_MIN_X_AXIS_POSITION,CONSTANTS.PAN_MAX_X_AXIS_POSITION),
                           0f, 
                          Random.Range(CONSTANTS.PAN_MIN_Z_AXIS_POSITION, CONSTANTS.PAN_MAX_Z_AXIS_POSITION));
    }
}
