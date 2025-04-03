class Program
{
    static void Main(string[] args)
    {
        var repositorio = new RepositorioUsuario();
        var servicoAutenticacao = new ServicoAutenticacao(repositorio);

        while (true)
        {
            Console.WriteLine("Bem-vindo ao sistema da academia!");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Sair");

            string? opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Write("Digite seu nome: ");
                string? nome = Console.ReadLine();

                Console.Write("Digite seu email: ");
                string? email = Console.ReadLine();

                Console.Write("Digite sua senha: ");
                string? senha = Console.ReadLine();

                if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(senha))
                {
                    servicoAutenticacao.RegistrarUsuario(nome, email, senha);
                }
                else
                {
                    Console.WriteLine("Todos os campos são obrigatórios.");
                }
            }
            else if (opcao == "2")
            {
                Console.Write("Digite seu email: ");
                string? email = Console.ReadLine();

                Console.Write("Digite sua senha: ");
                string? senha = Console.ReadLine();

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(senha))
                {
                    servicoAutenticacao.Login(email, senha);
                }
                else
                {
                    Console.WriteLine("Todos os campos são obrigatórios.");
                }
            }
            else if (opcao == "3")
            {
                Console.WriteLine("Saindo do sistema...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}