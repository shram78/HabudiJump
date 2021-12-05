using UnityEngine;

public class NoSpeedBoost : Boost
{
    private int _power = 0;

    public override int GetPower()
    {
        Debug.Log("Использован буст no");
        return _power;
    }
}
