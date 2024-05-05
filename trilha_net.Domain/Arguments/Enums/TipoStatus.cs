using System.ComponentModel;

namespace trilha_net.Domain.Arguments.Enums;

public enum TipoStatus : int
{
    [Description("Inativo")]
    Inativo = 0,
    [Description("Ativo")]
    Ativo = 1,
}