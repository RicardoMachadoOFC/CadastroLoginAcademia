public class RepositorioUsuario
{
    private List<Usuario> usuarios = new();

    public void AdicionarUsuario(Usuario usuario)
    {
        usuario.Id = usuarios.Count + 1; 
        usuarios.Add(usuario);
    }

    public Usuario? ObterUsuarioPorEmail(string email)
    {
        return usuarios.FirstOrDefault(u => u.Email == email);
    }
}