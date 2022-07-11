using CalculosBasicos.Bussiness.Contracts;
using CalculosBasicos.Bussiness.Response;
using CalculosBasicos.Bussiness.Utils; 

namespace CalculosBasicos.Bussiness.Implements
{
    public class OperationsBussiness : IOperationsBussiness
    {
        public async Task<ResultOperation> Division(double? value1, double? value2)
        {
            ResultOperation result = new ResultOperation();
            result.Val1 = value1;
            result.Val2 = value2;
            result.Operacion = Enums.Operacion.DIVISION;

            if (value1 == null || value2 == null)
            {
                return await NullNumbers(value1, value2);
            }

            result.Success = true;
            result.Result = NumValue(value1.Value / value2.Value) ;

            return await Task.Run(() => result);
        }

        public async Task<ResultOperation> Factorial(double? value1, double? value2)
        {
            ResultOperation result = new ResultOperation();
            result.Val1 = value1;
            result.Val2 = value2;
            result.Operacion = Enums.Operacion.FACTORIAL;

            if (value1 == null || value2 == null)
            {
                return await NullNumbers(value1, value2);
            }

            result.Success = true;
            result.Result = NumValueFactorial(Factorial(value1.Value)); 
            result.ResultV2 = NumValueFactorial(Factorial(value2.Value));

            return await Task.Run(() => result);
        }

        public async Task<ResultOperation> Multiplicacion(double? value1, double? value2)
        {
            ResultOperation result = new ResultOperation();
            result.Val1 = value1;
            result.Val2 = value2;
            result.Operacion = Enums.Operacion.MULTIPLICACION;

            if (value1 == null || value2 == null)
            {
                return await NullNumbers(value1, value2);
            }

            result.Success = true;
            result.Result = NumValue(value1.Value * value2.Value);

            return await Task.Run(() => result);
        }

        public async Task<ResultOperation> Resta(double? value1, double? value2)
        {
            ResultOperation result = new ResultOperation();
            result.Val1 = value1;
            result.Val2 = value2;
            result.Operacion = Enums.Operacion.RESTA;

            if (value1 == null || value2 == null)
            {
                return await NullNumbers(value1, value2);
            }

            result.Success = true;
            result.Result = NumValue(value1.Value - value2.Value);  

            return await Task.Run(() => result);
        }

        public async Task<ResultOperation> Suma(double? value1, double? value2)
        {
            ResultOperation result = new ResultOperation();
            result.Val1 = value1;
            result.Val2 = value2;
            result.Operacion = Enums.Operacion.SUMA;

            if (value1 == null || value2 == null) {
                return await NullNumbers(value1, value2);
            }

            result.Success = true;
            result.Result = NumValue(value1.Value + value2.Value);   

            return await Task.Run(() => result);
        }

        private async Task<ResultOperation> NullNumbers(double? value1, double? value2)
        {
            ResultOperation result = new ResultOperation();
            result.Success = false;
            result.Errors = ErrorsValidations.ValidNumerics;
            return await Task.Run(() => result);
        }

        private double Factorial(double f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }


        private string NumValue(double val) => (double.IsInfinity(val)) ? "Infinito" : $"{val}"; 
   
        private string NumValueFactorial(double val) => (double.IsInfinity(val)) ?  "Infinito" :  ( ( (long)val < 0) ? "No existe" : $"{(long)val}" ) ; 
         
    }
}
