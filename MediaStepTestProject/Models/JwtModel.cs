namespace MediaStepTestProject.Models;

public class JwtModel
{
    public static string Issuer => "FakeIssuer";
    public static string Audience => "FakeAudience";
    public static string SecretKey => "this is my custom Secret key for authentication";
}
