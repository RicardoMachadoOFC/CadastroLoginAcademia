using System.Security.Cryptography;
using System.Text;

public class ServicoAutenticacao
{
    private readonly RepositorioUsuario repositorioUsuario;

    public ServicoAutenticacao(RepositorioUsuario repositorio)
    {
        repositorioUsuario = repositorio;
    }

    public bool RegistrarUsuario(string nome, string email, string senha)
    {
        
        if (repositorioUsuario.ObterUsuarioPorEmail(email) != null)
        {
            Console.WriteLine("Email já cadastrado.");
            return false;
        }

        
        string senhaHash = HashSenha(senha);

       
        repositorioUsuario.AdicionarUsuario(new Usuario
        {
            Nome = nome,
            Email = email,
            Senha = senhaHash
        });

        Console.WriteLine("Usuário registrado com sucesso.");
        return true;
    }

    public bool Login(string email, string senha)
    {
        
        var usuario = repositorioUsuario.ObterUsuarioPorEmail(email);

        if (usuario == null)
        {
            Console.WriteLine("Usuário não encontrado.");
            return false;
        }

    
        if (usuario.Senha != HashSenha(senha))
        {
            Console.WriteLine("Senha incorreta.");
            return false;
        }

        Console.WriteLine($"Bem-vindo {usuario.Nome}!");
        return true;
    }

    private string HashSenha(string senha)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        return Convert.ToBase64String(bytes);
    }
}