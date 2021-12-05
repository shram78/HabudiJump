using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiSpeedBoost : Boost
{
    private int _power = 1200;

    public override int GetPower()
    {
        Debug.Log("Использован буст hi");
        return _power;
    }
}
