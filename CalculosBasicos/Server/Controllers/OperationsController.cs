using CalculosBasicos.Bussiness.Contracts;
using CalculosBasicos.Bussiness.Response;
using CalculosBasicos.Shared.DTOS; 
using CalculosBasicos.Shared.Utils; 
using Microsoft.AspNetCore.Mvc;

namespace CalculosBasicos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationsBussiness _operationsBussiness;
        public OperationsController(IOperationsBussiness operationsBussiness)
        {
            _operationsBussiness = operationsBussiness;
        }
         
        [HttpPost]
        public async Task<ResultOperation> Index([FromBody] SendOperation dataOperations)  
        {
            ResultOperation response = new ResultOperation();
            
            switch (dataOperations.Operacion)
            {
                case Operacion.SUMA:
                    response = await _operationsBussiness.Suma(double.Parse(dataOperations.Val1), double.Parse(dataOperations.Val2));
                    break;
                case Operacion.RESTA:
                    response = await _operationsBussiness.Resta(double.Parse(dataOperations.Val1), double.Parse(dataOperations.Val2));
                    break;
                case Operacion.MULTIPLICACION:
                    response = await _operationsBussiness.Multiplicacion(double.Parse(dataOperations.Val1), double.Parse(dataOperations.Val2));
                    break;
                case Operacion.DIVISION:
                    response = await _operationsBussiness.Division(double.Parse(dataOperations.Val1), double.Parse(dataOperations.Val2));
                    break;
                case Operacion.FACTORIAL:
                    response = await _operationsBussiness.Factorial(double.Parse(dataOperations.Val1), double.Parse(dataOperations.Val2));
                    break;
                default:
                    break;
            }
           
            return await Task.Run(() => response);
        }
    }
}
