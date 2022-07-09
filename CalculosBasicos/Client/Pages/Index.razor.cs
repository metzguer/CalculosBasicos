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
        private string? Field1 { get; set; }
        private string? Field2 { get; set; }

        private string? Message { get; set; }
        private string? Errors { get; set; }

        private bool EnableButtons  { get; set; } = false;
         
        public async void SendRequestOperation(Operacion operation) 
        {
            Errors = String.Empty;
            Message = String.Empty;
            try
            {
                if (EnableButtons)
                { 
                    HttpResponseMessage result = await Http.PostAsJsonAsync<SendOperation>("/api/Operations", Setdata(operation));

                    if (result.IsSuccessStatusCode)
                    {
                        ResultOperation response = await result.Content.ReadFromJsonAsync<ResultOperation>() ?? new ResultOperation { Success = false, Errors = MessageErrors.General };

                        if (response.Success)
                        { 
                            Message = response.Response(); 
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

        private SendOperation Setdata(Operacion operation) 
            => new SendOperation() {
                Operacion = operation,
                Val1 = double.Parse(Field1 ?? String.Empty),
                Val2 = double.Parse(Field2 ?? String.Empty)
            };
         
        private async Task SetValue1(string value)
        {
            Field1 = value;
            await Buttons();
        }

        private async Task SetValue2(string value)
        {
            Field2 = value;
            await Buttons();
        }
         
        private async Task Buttons() =>
           await Task.Run(() => EnableButtons = string.IsNullOrWhiteSpace(Field2) || string.IsNullOrWhiteSpace(Field1) ? false : true);
         
    }
}
