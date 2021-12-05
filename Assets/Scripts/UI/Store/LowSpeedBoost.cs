using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowSpeedBoost : Boost
{
    private int _power = 500;

    public override int GetPower()
    {
        Debug.Log("Использован буст лоу");
        return _power;
    }
}
