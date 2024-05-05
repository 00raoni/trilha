namespace trilha_net.Domain.Arguments.ViewModels
{
    public class ResponseUsuario
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
