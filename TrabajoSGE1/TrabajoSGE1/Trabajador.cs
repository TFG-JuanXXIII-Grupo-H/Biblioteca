namespace TrabajoSGE1
{
    public class Trabajador
    {
        public Trabajador(int id, string usuario, string pass, string email)
        {
            this.Id = id;
            this.Usuario = usuario;
            this.Pass = pass;
            this.email = email;
        }
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public string email { get; set; }
    }
}