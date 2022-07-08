using CalculosBasicos.Bussiness.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculosBasicos.Bussiness.Contracts
{
    public interface IOperationsBussiness
    {
        Task<ResultOperation> Suma(double? value1, double? value2);
        Task<ResultOperation> Resta(double? value1, double? value2);
        Task<ResultOperation> Multiplicacion(double? value1, double? value2);
        Task<ResultOperation> Division(double? value1, double? value2);
        Task<ResultOperation> Factorial(double? value1, double? value2);
    }
}
