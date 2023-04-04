
public class Bread : Food
{
    // INHERITANCE
    protected override float FoodValue
    {
        get
        {
            return _durability * 3f;
        }
    }

    public virtual void Toast()
    {

    }
}
