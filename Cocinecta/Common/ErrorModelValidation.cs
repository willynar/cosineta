using System.Collections;

namespace Cocinecta.Common
{
    public static class ErrorModelValidation
    {
        public static string ShowError(Dictionary<string, object>.ValueCollection ErrorCollection)
        {
            List<string> lstErrors = new();
            foreach (var item in ErrorCollection)
            {
                if (item is IEnumerable)
                {
                    if (item is ICollection listError)
                    {
                        foreach (string error in listError)
                        {
                            lstErrors.Add(error);
                        }
                    }
                }
                else
                {
                    lstErrors.Add(item.ToString() ?? string.Empty);
                }
            }

            return string.Join(". " + Environment.NewLine, lstErrors);
        }
    }
}
