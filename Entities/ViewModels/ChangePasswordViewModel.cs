namespace Entities.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string LastPassword { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "New password and confirmation password don´t match.")]
        public string PasswordConfirmation { get; set; } = string.Empty;
    }

    public class EditPasswordViewModel
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), StringLength(100, ErrorMessage = "The number of characters of {0} must be at least {2}.")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password), Compare("Password", ErrorMessage = "New password and confirmation password don´t match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class ResetPassword
    {
        [Required]
        public string Hash { get; set; } = string.Empty;

        [Required]
        public string NewPassword { get; set; } = string.Empty;

        [Compare("NewPassword", ErrorMessage = "New password and confirmation password don´t match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
