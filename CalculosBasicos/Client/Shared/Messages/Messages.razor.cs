using CalculosBasicos.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace CalculosBasicos.Client.Shared.Messages
{
    public partial class Messages
    {
        [Parameter] public string Message { get; set; }
        [Parameter] public LevelMessage Level { get; set; } 
    }
}
