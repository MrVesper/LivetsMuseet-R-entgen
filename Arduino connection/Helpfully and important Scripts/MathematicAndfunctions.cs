using UnityEngine;
using System;

public static class MathematicAndfunctions {

    public static float _GetNewMaximumPotentiometrValue(float _NEW_MAX_HEIGHT_BY_USER)
    {
        return Mathf.Abs((ConstantContainer._POTENTIOMETER_MAX*_NEW_MAX_HEIGHT_BY_USER)/ConstantContainer._HEIGHT_MAX);
    }

	/*public static float _GetNewLowerPhotoBorderFromUserHeigh(){
	}*/

    /// <summary>
    /// Function calculating photo position basing on distance calculation
    /// Y = PhotoYUppBorder + DistanceDifferenceBetweenActualPotValueAndMaxPotVal
    /// DistanceDifferenceBetweenActualPotValueAndMaxPotVal = Abs(CalcMaxPotV-ActPotV)
    /// 
    /// If we know that our calculated max Pot value  and actual pot value we know how much units is between them
    /// so we have distance between actual potentiometr value and max pot value.
    /// If we know distance we can multiply it by interval and we will get distance in px between this values.
    /// 
    /// </summary>
    /// <param name="maxPot"></param>
    /// <param name="alt"></param>
    /// <returns></returns>
    public static float _GetPictureYPosition_FromPotentiometr(float maxPot, float alt)
	{	float y1 = 0;
		
		if (alt <= maxPot) {
			 y1 = ConstantContainer._RENTGEN_PHOTO_UPPER_BORDER.y + GetDistanceDifferenceFromUpperBorder (maxPot, alt); 
		}
		else {
			 y1 = ConstantContainer._RENTGEN_PHOTO_UPPER_BORDER.y - GetDistanceDifferenceFromUpperBorder (maxPot, alt); 
		}
        return y1;
    }

    private static float GetMaxDistFromPot(float maxPot)
    {
        return Mathf.Abs(maxPot-ConstantContainer._POTENTIOMETER_MIN);
    }


    /// <summary>
    /// function which returning interval from max photo distance and max distance in range <255,NewMaxPot>
    /// Interval is basing on mark: x= MaxPhotoDist* 1unit in Pot / NewCalcMaxPot
    /// </summary>
    /// <param name="maxPot"></param>
    /// <returns></returns>
    public static float GetInterval(float maxPot)
    {
        return ConstantContainer._MAX_PHOTO_DIST / GetMaxDistFromPot(maxPot);
    }

    /// <summary>
    /// Function which returning distance between actual potentiometer value and calculated max pot value based on user high 
    /// Math.Abs((maxPot - alt)) - Distance between actual and max potentiometer value
    /// GetInterval(maxPot) * Math.Abs((maxPot - alt)); - Interval multiplayed by distance between pot values
    /// </summary>
    /// <param name="maxPot"></param>
    /// <param name="alt"></param>
    /// <returns></returns>
    public static float GetDistanceDifferenceFromUpperBorder(float maxPot, float alt)
    {
        return GetInterval(maxPot) * Math.Abs((maxPot - alt));
    }
}
