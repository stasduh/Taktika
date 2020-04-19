
public class UIControllerSingleton
{
    private static UIControllerSingleton instance;

    public int killingCount = 0;
    public int playerHealth = 0;
    public int gold = 0;

    private UIControllerSingleton()
    {
        
    }

    public static UIControllerSingleton getInstance()
    {
        if (instance == null)
            instance = new UIControllerSingleton();
        return instance;
    }
}
