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
                ErrorType.Saved => "The item was saved successfully.",
                ErrorType.Updated => "The item was updated successfully.",
                _ => error,
            };
    }
}
