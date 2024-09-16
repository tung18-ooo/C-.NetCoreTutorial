using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CS056_ASP.NET_Razor_07.Binders
{
    public class UserNameBinding : IModelBinder
    {
        /*
         * Chuyen ten thanh IN HOA
         * Ten khongduoc chua xxx
         * Cat khoang trang o dau va cuoi
         */


        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            string modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                // Sử dụng await Task.CompletedTask để chỉ ra rằng phương thức đã hoàn tất mà không cần thực hiện bất kỳ công việc gì khác.
                await Task.CompletedTask;
                return;
            }

            string value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
            {
                await Task.CompletedTask;
                return;
            }

            // Binding
            string s = value.ToUpper();

            if (s.Contains("XXX"))
            {
                bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
                bindingContext.ModelState.TryAddModelError(modelName, "Lỗi do chứa xxx");
                await Task.CompletedTask;
                return;
            }

            s = s.Trim();
            bindingContext.ModelState.SetModelValue(modelName, s, s);
            bindingContext.Result = ModelBindingResult.Success(s);

            await Task.CompletedTask;
        }
    }
}
