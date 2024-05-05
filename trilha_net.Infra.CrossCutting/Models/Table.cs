namespace trilha_net.Infra.CrossCutting.Models
{
    public class Table
    {
        public string Name { get; set; }
        public string Schema { get; set; }

        public Table(string name, string schema)
        {
            Name = name;
            Schema = schema;
        }
        public static Table Usuario { get; } = new Table("Usuario", "dbo");        
    }
}
