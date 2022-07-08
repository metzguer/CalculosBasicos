using CalculosBasicos.Shared.Utils;

namespace CalculosBasicos.Shared.DTOS
{
    public class SendOperation
    {
        public double Val1 { get; set; }
        public double Val2 { get; set; }
        public Operacion Operacion { get; set; }
    }
}
