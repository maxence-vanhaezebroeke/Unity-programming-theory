
public class PremiumBread : Bread
{
    // INHERITANCE
    protected override float FoodValue
    {
        get
        {
            return 2 * base.FoodValue;
        }
    }

    public override void TimePassed()
    {
        // Premium bread durability lasts longer than regular food/bread.
        _durability -= 0.01f;
    }

}
