using Kernel.ViewModel.Common;
using Newtonsoft.Json.Linq;

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
                pattern = pattern.Replace("@" + Data.Key, Data.Value.ToString());
            }
            return pattern;
        }
    }
}
