using System.Text.RegularExpressions;

namespace EcommerceV4.Domain.Aggregates.UserAggregate.ValueObjects
{
    public class EmailObject
    {
        public string Value { get; private set; } = string.Empty;
        private EmailObject() { }

        //constructor private để bắt buộc dùng factory Create để tạo instance (bảo đảm mọi email đều được validat trước khi tạo)
        private EmailObject(string value)
        {
            Value = value;
        }

        public static EmailObject Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Email can not be empty");
            }

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!regex.IsMatch(value))
                throw new ArgumentNullException("Invalid email format.");

            return new EmailObject(value.Trim());
        }

        public override bool Equals(object? obj)
        {
            return obj is EmailObject email && Value == email.Value;
        }
        public override int GetHashCode() => Value.GetHashCode();

    }
}
