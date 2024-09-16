using System.ComponentModel.DataAnnotations;

namespace CS056_ASP.NET_Razor_07.Validation
{
    public class SoChan : ValidationAttribute
    {
        public SoChan() => ErrorMessage = "{0} phải là số chẵn";
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            int i = int.Parse(value.ToString());

            return i % 2 == 0;
        }
    }
}
