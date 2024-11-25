namespace TrabajoSGE1
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rango { get; set; }

        public Usuario() { }

        public Usuario(int id, string name, string email, string rango)
        {
            Id = id;
            Name = name;
            Email = email;
            Rango = rango;
        }

        public string ShowUser()
        {
            return $"Usuario: {Id} - {Name} - {Email} - {Rango}";
        }
    }


}