using CalculosBasicos.Shared.Utils;
using System.Globalization;

namespace CalculosBasicos.Shared.Response
{
    public static class StringExtension
    {
        public static string Response(this ResultOperation response)
        {
            CultureInfo mxCulture = new CultureInfo("en-US");
             
            string message = string.Empty;
             
            switch (response.Operacion)
            {
                case Operacion.SUMA:
                case Operacion.RESTA:
                case Operacion.MULTIPLICACION:
                case Operacion.DIVISION:
                    message = $"EL RESULTADO DE {response.Operacion} ENTRE EL VALOR {response.Val1} Y {response.Val2} ES : {response.Result}";
                    break;

                case Operacion.FACTORIAL:
                    message = $"EL RESULTADO DE FACTORIAL DEL VALOR {response.Val1} ES:  {response.Result} Y  " +
                        $"EL RESULTADO DE FACTORIAL DEL VALOR {response.Val2} ES:  {response.ResultV2} ";
                    break;
                default:
                    break;
            }
            
            return message;
        }
    }
}
