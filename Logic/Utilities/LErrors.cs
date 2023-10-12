namespace Logic.Utilities
{
    public class LErrors
    {
        public static string TranslateError(ErrorType type, string error = "") =>
            type switch
            {
                ErrorType.UserNotFound => "User not found.",
                ErrorType.Logout => "Session closed successfully.",
                ErrorType.PassError => "Wrong user / password.",
                ErrorType.LockoutEnabled => "User blocked.",
                _ => error,
            };
    }
}
