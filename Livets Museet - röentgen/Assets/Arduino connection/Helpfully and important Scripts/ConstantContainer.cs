using UnityEngine;
using System;

public static class ConstantContainer{

    public static readonly Vector3 _RENTGEN_PHOTO_UPPER_BORDER = new Vector3(97, -132, 90);
    public static readonly Vector3 _RENTGEN_PHOTO_LOWER_BORDER = new Vector3(97, 135, 90);

    public static readonly float _HEIGHT_MAX = 185;
    public static readonly float _POTENTIOMETER_MAX = 770;
    public static readonly float _POTENTIOMETER_MIN = 255;


    public static readonly int _MAX_PHOTO_DIST =  Convert.ToInt32(Math.Abs(_RENTGEN_PHOTO_UPPER_BORDER.y - _RENTGEN_PHOTO_LOWER_BORDER.y));
}
