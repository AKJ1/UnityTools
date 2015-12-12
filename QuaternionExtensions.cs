using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class QuaternionExtensions
{
    public static Quaternion Clamp(this Quaternion Q, Quaternion other)
    {
        if(Q.eulerAngles.x > other.eulerAngles.x && Q.eulerAngles.x < 180)
        {
            Q = Quaternion.Euler(other.eulerAngles.x, Q.eulerAngles.y, Q.eulerAngles.z);
        }
        else if(Q.eulerAngles.x < 360 - other.eulerAngles.x && Q.eulerAngles.x > 180)
        {
            Q = Quaternion.Euler(360-other.eulerAngles.x, Q.eulerAngles.y, Q.eulerAngles.z);
        }
        if (Q.eulerAngles.y > other.eulerAngles.y && Q.eulerAngles.y < 180)  
        {
            Q = Quaternion.Euler(Q.eulerAngles.x, other.eulerAngles.y, Q.eulerAngles.z);   
        }
        else if ((Q.eulerAngles.y < 360 - other.eulerAngles.y && Q.eulerAngles.y > 180))
        {
            Q = Quaternion.Euler(Q.eulerAngles.x, 360 - other.eulerAngles.y, Q.eulerAngles.z);
        }

            Q = Quaternion.Euler(Q.eulerAngles.x, Q.eulerAngles.y, 0);
        return Q;
    }

    public static Quaternion RelativeToInverse(this Quaternion Q, Quaternion other)
    {
        return Quaternion.Inverse(other) * Q;
    }

    public static Quaternion RelativeTo(this Quaternion Q, Quaternion other)
    {
        return Quaternion.Inverse(Q) * other;
    }
}