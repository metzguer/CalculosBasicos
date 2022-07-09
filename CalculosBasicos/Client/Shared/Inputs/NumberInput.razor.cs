using CalculosBasicos.Shared.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CalculosBasicos.Client.Shared.Inputs
{
    public partial class NumberInput
    {
        [Parameter]  public string Id { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public string FieldValue { get; set; }
        public string ErrorField { get; set; }

        [Parameter] public EventCallback<string> OnKeyUpCallback { get; set; }

        private async Task ValidateField2(KeyboardEventArgs e)
        {
            double? numberValue = ParseData(FieldValue);

            if (numberValue == null)
            {
                ErrorField = ErrorsValidations.ValidNumerics;
                FieldValue = string.Empty;
                await OnKeyUpCallback.InvokeAsync(String.Empty);
            }
            else
            {
                ErrorField = String.Empty;
                await OnKeyUpCallback.InvokeAsync(FieldValue);
            } 
        }

        private double? ParseData(string value) =>
           double.TryParse(value, out double result) ? double.Parse(value) : null;
    }
}
