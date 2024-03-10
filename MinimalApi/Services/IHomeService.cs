namespace Services;

public interface IHomeService
{
    string Message();
}


public class HomeService : IHomeService
{
    public string Message()
    {
        return "This is message generated by HomeService";
    }
}