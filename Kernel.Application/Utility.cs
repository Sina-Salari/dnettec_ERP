using Kernel.ViewModel.Common;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Kernel.Application
{
    internal static class Utility
    {
        static Utility()
        {
        }

        public static async Task<FluentResults.Result<TValue>> Validate<TCommand, TValue>
            (FluentValidation.AbstractValidator<TCommand> validator, TCommand command)
        {
            FluentResults.Result<TValue> result = new FluentResults.Result<TValue>();

            FluentValidation.Results.ValidationResult
                validationResult = await validator.ValidateAsync(instance: command);

            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    result.WithError(errorMessage: error.ErrorMessage);
                }
            }

            return result;
        }

        public static async Task<string> JsonBodyValidation(List<JToken> jPattern, List<JToken> jBody)
        {
            foreach (var Pattern in jPattern)
            {
                var jItem = jBody.Where(p => p.Path == Pattern.Path).FirstOrDefault();
                if (jItem == null)
                {
                    return string.Format(Resources.Messages.Validations.Required, Pattern.Path);
                }
                else if (jItem.Type != Pattern.Type)
                {
                    return string.Format(Resources.Messages.Validations.RegularExpression, Pattern.Path);
                }

                if (Pattern.Type == JTokenType.Object || Pattern.Type == JTokenType.Array || Pattern.Type == JTokenType.Property)
                {
                    await JsonBodyValidation(Pattern.Values().ToList(), jItem.Values().ToList());
                }
            }

            return string.Empty;
        }

        public static async Task MapJsonToDataSource(this List<WorkFlowDataSource> DataSource, List<JToken> jDatas)
        {
            foreach (var jData in jDatas)
            {
                if (jData.Type == JTokenType.Object || jData.Type == JTokenType.Array || jData.Type == JTokenType.Property)
                {
                    await DataSource.MapJsonToDataSource(jData.Values().ToList());
                }
                else
                {
                    DataSource.Add(new WorkFlowDataSource()
                    {
                        Key = jData.Path,
                        Value = jData.Value<object>(),
                        Type = jData.Type,
                    });
                }
            }
        }

        public static async Task FixWorkFlowResponse(this List<JToken> jDatas, List<WorkFlowDataSource> dataSource)
        {
            foreach (var jData in jDatas)
            {
                if (jData.Type == JTokenType.Object || jData.Type == JTokenType.Array || jData.Type == JTokenType.Property)
                {
                    await jData.Values().ToList().FixWorkFlowResponse(dataSource);
                }
                else
                {
                    var Key = jData.Value<string>().ToUpper();

                    var value = dataSource
                        .Where(p => p.Key.ToUpper() == Key)
                        .FirstOrDefault();

                    if (value != null)
                        jData.Replace(JToken.FromObject(value.Value));
                }
            }
        }

        public static async Task<string> GetPathFromJToken(this JToken JData, string value)
        {
            return await JData.Next.GetPathFromJToken(value);
        }

        public static async Task<string> FixPattern(this string pattern, List<WorkFlowDataSource> DataSource)
        {
            foreach (var Data in DataSource)
            {
                pattern = pattern.Replace("#" + Data.Key, Data.Value.ToString());
            }
            return pattern;
        }

        public static string HashSHA256(this string input)
        {
            using (var sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string HashWithSalt(this string password, Guid salt)
        {
            return HashSHA256(password) + salt.ToString();
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static string GenarateToken(this Guid AccountId, string secretKey, int tokenTimeOut)
        {
            var TokenHandler = new JwtSecurityTokenHandler();

            var Key = Encoding.UTF8.GetBytes(secretKey);

            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("AccountId",AccountId.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(tokenTimeOut),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(token);
        }

        public static string ToShamsi(this DateTime date)
        {
            var persian = new PersianCalendar();
            return $"{persian.GetHour(date)}:{persian.GetMinute(date)} {persian.GetYear(date)}/{persian.GetMonth(date)}/{persian.GetDayOfMonth(date)}";
        }
    }
}
