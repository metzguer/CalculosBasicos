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
        public async Task<ResultOperation> Index(SendOperation dataOperations)  
        {
            ResultOperation response = new ResultOperation();

            switch (dataOperations.Operacion)
            {
                case Operacion.SUMA:
                    response = await _operationsBussiness.Suma(dataOperations.Val1, dataOperations.Val2);
                    break;
                case Operacion.RESTA:
                    response = await _operationsBussiness.Resta(dataOperations.Val1, dataOperations.Val2);
                    break;
                case Operacion.MULTIPLICACION:
                    response = await _operationsBussiness.Multiplicacion(dataOperations.Val1, dataOperations.Val2);
                    break;
                case Operacion.DIVISION:
                    response = await _operationsBussiness.Division(dataOperations.Val1, dataOperations.Val2);
                    break;
                case Operacion.FACTORIAL:
                    response = await _operationsBussiness.Factorial(dataOperations.Val1, dataOperations.Val2);
                    break;
                default:
                    break;
            }

            return await Task.Run(() => response);
        }
    }
}
