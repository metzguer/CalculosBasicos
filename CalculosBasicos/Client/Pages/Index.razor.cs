using CalculosBasicos.Shared.DTOS;
using CalculosBasicos.Shared.Response;
using CalculosBasicos.Shared.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;

namespace CalculosBasicos.Client.Pages
{
    public partial class Index
    {
        [Inject] public HttpClient Http { get; set; }
        private string? MessageField1 { get; set; } 
        private string? MessageField2 { get; set; } 
        private string? Field1 { get; set; }
        private string? Field2 { get; set; }

        private string? Message { get; set; }
        private string? Errors { get; set; }

        private bool EnableButtons  { get; set; } = false;

        SendOperation data = new SendOperation();
        CultureInfo mxCulture = new CultureInfo("en-US");
        public async void SendRequestOperation(Operacion operation) 
        {
            try
            {
                if (EnableButtons)
                {
                    data.Operacion = operation;
                    data.Val1 = double.Parse(Field1);
                    data.Val2 = double.Parse(Field2);
                    HttpResponseMessage result = await Http.PostAsJsonAsync<SendOperation>("/api/Operations", data);

                    if (result.IsSuccessStatusCode)
                    {
                        ResultOperation response = await result.Content.ReadFromJsonAsync<ResultOperation>();

                        if (response.Success)
                        {
                            string fact = response.Operacion == Operacion.FACTORIAL ? $"Y {response.ResultV2.ToString("N2", mxCulture)}" : "";

                            Message = $"EL RESULTADO DE {response.Operacion} ENTRE EL VALOR {response.Val1} " +
                                $"{await GetSimbol(response.Operacion)} {response.Val2} ES : {response.Result.ToString("N2", mxCulture)} {fact}";
                        }
                        else
                        {
                            Errors = response.Errors;
                        }
                    }
                }
                else
                {
                    Errors = MessageErrors.General;
                }
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Errors = MessageErrors.General;
            }
        }

        private async Task<string> GetSimbol(Operacion operation) 
        {
            string symbol = string.Empty;

            switch (operation)
            {
                case Operacion.SUMA:
                    symbol = "+";
                    break;
                case Operacion.RESTA:
                    symbol = "-";
                    break;
                case Operacion.MULTIPLICACION:
                    symbol = "*";
                    break;
                case Operacion.DIVISION:
                    symbol = "/";
                    break;
                case Operacion.FACTORIAL:
                    symbol = " Y ";
                    break;
                default:
                    break;
            }
            return symbol;

        }

        private async Task ValidateField1(KeyboardEventArgs e) 
        { 
            decimal? numberValue = await ParseData(Field1);

            if (numberValue == null)
            {
                MessageField1 = ErrorsValidations.ValidNumerics;
                Field1 = string.Empty; 
            }
            else {
                MessageField1 = string.Empty;
                data.Val1 = double.Parse(Field1);
            }

            Buttons();
        }

        private async Task ValidateField2(KeyboardEventArgs e)
        {
            decimal? numberValue = await ParseData(Field2);

            if (numberValue == null)
            {
                MessageField2 = ErrorsValidations.ValidNumerics;
                Field2 = string.Empty; 
            }
            else
            {
                MessageField2 = String.Empty;
                data.Val2 = double.Parse(Field2);
            }
            Buttons();
        }

        private async void Buttons()
        {
            EnableButtons = string.IsNullOrWhiteSpace(Field2) || string.IsNullOrWhiteSpace(Field1) ? false : true;
        }

        private async Task<decimal?> ParseData(string value) 
        { 
            decimal? val = decimal.TryParse(value, out decimal result) ? decimal.Parse(value) : null;
            return await Task.Run( () => val);
        }

    }
}
