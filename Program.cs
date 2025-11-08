using System;
using System.Collections.Generic;

class Program
{
    // Dicionário que associa cada setor à lista de funcionários
    static Dictionary<string, List<string>> setores = new Dictionary<string, List<string>>()
    {
        { "Financeiro", new List<string> { "Ana", "Carlos", "Fernanda" } },
        { "Operação", new List<string> { "João", "Marcos", "Luana", "Ricardo" } },
        { "Atendimento", new List<string> { "Paula", "Rafael", "Bianca" } }
    };

    static void Main(string[] args)
    {
        menu();
    }

    // Menu principal
    static void menu()
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("     SISTEMA DE CADASTRO EMPRESARIAL");
            Console.WriteLine("=======================================");
            Console.WriteLine("1 - Listar setores e funcionários");
            Console.WriteLine("2 - Visualizar funcionários por setor");
            Console.WriteLine("3 - Adicionar setor");
            Console.WriteLine("4 - Remover setor vazio");
            Console.WriteLine("5 - Adicionar funcionário");
            Console.WriteLine("6 - Remover funcionário");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("=======================================");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Pressione uma tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    listarTudo();
                    break;
                case 2:
                    listarPorSetor();
                    break;
                case 3:
                    adicionarSetor();
                    break;
                case 4:
                    removerSetorVazio();
                    break;
                case 5:
                    adicionarFuncionario();
                    break;
                case 6:
                    removerFuncionario();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Pressione uma tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

        } while (opcao != 0);
    }

    // Lista todos os setores e seus funcionários
    static void listarTudo()
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE SETORES E FUNCIONÁRIOS ===\n");

        foreach (var setor in setores)
        {
            Console.WriteLine($"Setor: {setor.Key}");
            if (setor.Value.Count == 0)
                Console.WriteLine("  (Sem funcionários)");
            else
                foreach (var funcionario in setor.Value)
                    Console.WriteLine($"  - {funcionario}");
            Console.WriteLine();
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    // Lista os funcionários de um setor específico
    static void listarPorSetor()
    {
        Console.Clear();
        Console.WriteLine("=== VISUALIZAR FUNCIONÁRIOS POR SETOR ===");
        Console.Write("Digite o nome do setor: ");
        string nome = Console.ReadLine();


        if (setores.ContainsKey(nome))
        {
            Console.WriteLine($"\nSetor: {nome}");
            if (setores[nome].Count == 0)
                Console.WriteLine("Nenhum funcionário cadastrado neste setor.");
            else
                foreach (string func in setores[nome])
                    Console.WriteLine($" - {func}");
        }
        else
        {
            Console.WriteLine("Setor não encontrado.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    // Adiciona novo setor
    static void adicionarSetor()
    {
        Console.Clear();
        Console.WriteLine("=== ADICIONAR NOVO SETOR ===");
        Console.Write("Nome do novo setor: ");
        string nome = Console.ReadLine();

        if (!setores.ContainsKey(nome))
        {
            setores.Add(nome, new List<string>());
            Console.WriteLine($"Setor '{nome}' adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Setor já existe!");
        }

        Console.ReadKey();
    }

    // Remove setores vazios
    static void removerSetorVazio()
    {
        Console.Clear();
        Console.WriteLine("=== REMOVER SETORES VAZIOS ===");

        List<string> setoresRemovidos = new List<string>();

        foreach (var setor in setores)
        {
            if (setor.Value.Count == 0)
                setoresRemovidos.Add(setor.Key);
        }

        if (setoresRemovidos.Count == 0)
        {
            Console.WriteLine("Nenhum setor vazio encontrado.");
        }
        else
        {
            foreach (string nome in setoresRemovidos)
                setores.Remove(nome);

            Console.WriteLine($"{setoresRemovidos.Count} setor(es) vazio(s) removido(s).");
        }

        Console.ReadKey();
    }

    // Adiciona funcionário a um setor
    static void adicionarFuncionario()
    {
        Console.Clear();
        Console.WriteLine("=== ADICIONAR FUNCIONÁRIO ===");
        Console.Write("Nome do funcionário: ");
        string nome = Console.ReadLine();

        Console.Write("Setor de destino: ");
        string setor = Console.ReadLine();

        if (setores.ContainsKey(setor))
        {
            setores[setor].Add(nome);
            Console.WriteLine($"Funcionário '{nome}' adicionado ao setor '{setor}'.");
        }
        else
        {
            Console.WriteLine("Setor não encontrado.");
        }

        Console.ReadKey();
    }

    // Remove funcionário
    static void removerFuncionario()
    {
        Console.Clear();
        Console.WriteLine("=== REMOVER FUNCIONÁRIO ===");
        Console.Write("Nome do funcionário: ");
        string nome = Console.ReadLine();

        bool encontrado = false;

        foreach (var setor in setores)
        {
            if (setor.Value.Remove(nome))
            {
                Console.WriteLine($"Funcionário '{nome}' removido do setor '{setor.Key}'.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
            Console.WriteLine("Funcionário não encontrado.");

        Console.ReadKey();
    }
}
