using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleSpeedBoost : Boost
{
    private int _power = 800;
    public override int GetPower()
    {
        Debug.Log("����������� ���� middle");
        return _power;
    }
}
