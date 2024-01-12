using System.Text;

namespace Booking.BuildingBlocks.Infrastructure.Emails
{
    public abstract class EmailTemplate
    {
        private readonly Dictionary<string, string> _substitutions = new Dictionary<string, string>();

        protected abstract string GetEmailTemplate();

        public string GenerateBody()
        {
            var template = GetEmailTemplate();
            var builder = new StringBuilder(template);

            foreach (var substitution in _substitutions)
            {
                builder.Replace(substitution.Key, substitution.Value);
            }

            return builder.ToString();
        }

        public EmailTemplate WithSubstitution(string variable, string value)
        {
            if (string.IsNullOrEmpty(variable))
            {
                throw new ArgumentException("Variable cannot be null or empty.", nameof(variable));
            }

            _substitutions[variable] = value;
            return this;
        }
    }
}
