using AutoMapper;

namespace Oscar.Profiles
{
    public class CurrencyFormatter : IValueConverter<decimal, string>
    {
      
        public string Convert(decimal sourceMember, ResolutionContext context)
        => sourceMember.ToString("c");
        
    }
}