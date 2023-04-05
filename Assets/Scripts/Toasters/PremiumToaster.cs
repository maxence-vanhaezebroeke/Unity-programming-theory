using UnityEngine;

// INHERITANCE
public class PremiumToaster : Toaster
{
    // POLYMORPHISM
    protected override void ToastBread(Bread pBread)
    {
        // Premium bread can toast bread, but will also premium toast premium bread !
        if (pBread is PremiumBread lPremiumBread)
        {
            lPremiumBread.PremiumToast();
        }
        else
        {
            base.ToastBread(pBread);
        }
    }
}
