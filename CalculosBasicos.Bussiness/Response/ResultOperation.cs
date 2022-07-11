using CalculosBasicos.Bussiness.Enums; 

namespace CalculosBasicos.Bussiness.Response
{
    public class ResultOperation
    {
        public double? Val1 { get; set; }
        public double? Val2 { get; set; }
        public Operacion Operacion { get; set; }
        public string Result { get; set; }
        public string ResultV2 { get; set; }
        public bool Success { get; set; } 
        public List<string>? Warnings { get; set; }
        public string? Errors { get; set; }
    }
}
