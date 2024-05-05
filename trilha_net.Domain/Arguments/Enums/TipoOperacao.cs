using System.ComponentModel;

namespace trilha_net.Domain.Arguments.Enums;

public enum TipoOperacao : int
{
    [Description("Inclusao")]
    Inclusao = 0,
    [Description("Alteracao")]
    Alteracao = 1,
    [Description("Exclusao")]
    Exclusao = 1,
}