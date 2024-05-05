using System.ComponentModel;

namespace trilha_net.Infra.CrossCutting.Extensions
{
    /// <summary>
    /// Extensões de enumeradores
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Retona a string da Description do enum,
        /// Se não existir retorna o nome do enum.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum valor)
        {
            var enumType = valor.GetType();
            var field = enumType.GetField(valor.ToString());
            if(field is not null)
            {
                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
                return RetornaNomeEnumSeNaoTiverAtributo(valor, attributes);
            }

            return valor.ToString();
        }

        private static string RetornaNomeEnumSeNaoTiverAtributo(Enum valor, object[] atributos)
            => atributos.Length == 0 ? valor.ToString() : ((DescriptionAttribute)atributos[0]).Description;
    }
}
