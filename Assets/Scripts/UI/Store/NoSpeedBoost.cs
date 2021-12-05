
public class NoSpeedBoost : Boost
{
    private int _power = 0;

    public override int GetPower()
    {
        return _power;
    }
}
