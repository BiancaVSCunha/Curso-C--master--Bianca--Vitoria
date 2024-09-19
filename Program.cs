using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaGerenciamentoTatuagens
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Tatuagem> tatuagens = new List<Tatuagem>();
        static List<Agendamento> agendamentos = new List<Agendamento>();

        static string caminhoClientes = @"C:\Users\Aluno Noite\Desktop\Bianca\Curso-C--master Bianca atl\Curso-C--master\clientes.json";
        static string caminhoTatuagens = @"C:\Users\Aluno Noite\Desktop\Bianca\Curso-C--master Bianca atl\Curso-C--master\tatuagens.json";
        static string caminhoAgendamentos = @"C:\Users\Aluno Noite\Desktop\Bianca\Curso-C--master Bianca atl\Curso-C--master\agendamentos.json";

        static void CentralizarTexto(string texto)
        {
            // Obtém a largura da janela do console
            int larguraConsole = Console.WindowWidth;

            // Calcula a largura do texto
            int larguraTexto = texto.Length;

            // Calcula o número de espaços antes do texto para centralizar
            int espacosAntes = (larguraConsole - larguraTexto) / 2;

            // Cria a string com os espaços necessários para centralizar o texto
            string textoCentralizado = new string(' ', espacosAntes) + texto;

            // Exibe o texto centralizado no console
            Console.WriteLine(textoCentralizado);
        }

        private const string VersaoSistema = "1.0.0";

        static void Main(string[] args)
        {
            CarregarDados();

            int opcao;
            do
            {
                Console.Clear();
                CentralizarTexto("=============================================");
                CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
                CentralizarTexto("===============   TATUAGENS   ===============");
                CentralizarTexto("=============================================");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Console.ResetColor();
                CentralizarTexto(" =============================================\n");
                Console.ResetColor();
                Console.WriteLine("                                                  1. Gerenciar Clientes");
                Console.WriteLine("                                                  2. Gerenciar Tatuagens");
                Console.WriteLine("                                                  3. Gerenciar Agendamentos");
                Console.WriteLine("                                                  0. Sair\n");
                CentralizarTexto(" =============================================\n");
                Console.ResetColor();

                Console.Write("                                                  Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuClientes();
                        break;
                    case 2:
                        MenuTatuagens();
                        break;
                    case 3:
                        MenuAgendamentos();
                        break;
                    case 0:
                        SalvarDados();
                        Console.WriteLine("\n                                     Saindo do programa...");
                        CentralizarTexto("==============================================");
                        CentralizarTexto($"Versão do Sistema: {VersaoSistema}");
                        CentralizarTexto(" ==============================================\n");
                        break;
                    default:
                        Console.WriteLine("\n                                     Opção inválida, tente novamente.");
                        break;
                }

                

            } while (opcao != 0);

            
        }

        static void MenuClientes()
        {
            int opcao;
            do
            {
                Console.Clear();
                CentralizarTexto("=============================================");
                CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
                CentralizarTexto("===============   TATUAGENS   ===============");
                CentralizarTexto("=============================================");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Console.ResetColor();
                CentralizarTexto("=============================================");
                CentralizarTexto("============  GERENCIAR CLIENTES  ===========");
                CentralizarTexto("=============================================\n");
                Console.WriteLine("                                                  1. Adicionar Cliente");
                Console.WriteLine("                                                  2. Listar Clientes");
                Console.WriteLine("                                                  3. Atualizar Cliente");
                Console.WriteLine("                                                  4. Remover Cliente");
                Console.WriteLine("                                                  0. Voltar\n");
                CentralizarTexto("=============================================\n");

                Console.Write("                                                  Escolha uma opção: ");
               
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        AtualizarCliente();
                        break;
                    case 4:
                        RemoverCliente();
                        break;
                    case 0:
                        Console.WriteLine("\n                                     Voltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\n                                     Opção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\n                                     Pressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (opcao != 0);
        }

        static void AdicionarCliente()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("==========  ADICIONAR NOVO CLIENTE  =========");
            CentralizarTexto("=============================================\n");
            Console.Write("                                        Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("                                        Digite o telefone do cliente: ");
            string telefone = Console.ReadLine();

            Console.Write("                                        Digite o e-mail do cliente: ");
            string email = Console.ReadLine();

            Console.Write("                                        Digite a data de nascimento (AAAA-MM-DD): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            int id = clientes.Count > 0 ? clientes[^1].Id + 1 : 1;
            Cliente cliente = new Cliente(id, nome, telefone, email, dataNascimento);
            clientes.Add(cliente);

            Console.WriteLine("\n                                     Cliente adicionado com sucesso!");
            SalvarDados();
        }

        static void ListarClientes()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("=============================================");
            CentralizarTexto("============  LISTA DE CLIENTES  ============");
            CentralizarTexto("=============================================\n");

            if (clientes.Count == 0)
            {
                Console.WriteLine("\nNenhum cliente cadastrado.");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"                                        ID: {cliente.Id}");
                    Console.WriteLine($"                                        Nome: {cliente.Nome}");
                    Console.WriteLine($"                                        Telefone: {cliente.Telefone}");
                    Console.WriteLine($"                                        E-mail: {cliente.Email}");
                    Console.WriteLine($"                                        Data de Nascimento: {cliente.DataNascimento.ToString("yyyy-MM-dd")}");
                    CentralizarTexto("=============================================");
                }
            }
        }

        static void AtualizarCliente()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("============  ATUALIZAR CLIENTE  ============");
            CentralizarTexto("=============================================\n");

            Console.Write("                                     Digite o ID do cliente a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                Console.Write("                                     Digite o novo nome do cliente: ");
                cliente.Nome = Console.ReadLine();

                Console.Write("                                     Digite o novo telefone do cliente: ");
                cliente.Telefone = Console.ReadLine();

                Console.Write("                                     Digite o novo e-mail do cliente: ");
                cliente.Email = Console.ReadLine();

                Console.Write("                                     Digite a nova data de nascimento (AAAA-MM-DD): ");
                cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\n                               Cliente atualizado com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\n                                     Cliente não encontrado.");
            }
        }

        static void RemoverCliente()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("=============  REMOVER CLIENTE  =============");
            CentralizarTexto("=============================================\n");

            Console.Write("                                     Digite o ID do cliente a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            var cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("\n                                     Cliente removido com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\n                                     Cliente não encontrado.");
            }
        }

        static void MenuTatuagens()
        {
            int opcao;
            do
            {
                Console.Clear();
                CentralizarTexto("=============================================");
                CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
                CentralizarTexto("===============   TATUAGENS   ===============");
                CentralizarTexto("=============================================");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Console.ResetColor();
                CentralizarTexto("=============================================");
                CentralizarTexto("===========  GERENCIAR TATUAGENS  ===========");
                CentralizarTexto("=============================================\n");
                Console.WriteLine("                                                  1. Adicionar Tatuagem");
                Console.WriteLine("                                                  2. Listar Tatuagens");
                Console.WriteLine("                                                  3. Atualizar Tatuagem");
                Console.WriteLine("                                                  4. Remover Tatuagem");
                Console.WriteLine("                                                  0. Voltar\n");
                CentralizarTexto("=============================================\n");
                Console.Write("                                                  Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarTatuagem();
                        break;
                    case 2:
                        ListarTatuagens();
                        break;
                    case 3:
                        AtualizarTatuagem();
                        break;
                    case 4:
                        RemoverTatuagem();
                        break;
                    case 0:
                        Console.WriteLine("\n                                     Voltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\n                                     Opção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\n                                     Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        static void AdicionarTatuagem()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");            
            CentralizarTexto("=========  ADICIONAR NOVA TATUAGEM  =========");
            CentralizarTexto("=============================================\n");
            Console.Write("                                     Digite o nome da tatuagem: ");
            string nome = Console.ReadLine();

            Console.Write("                                     Digite a descrição da tatuagem: ");
            string descricao = Console.ReadLine();

            int id = tatuagens.Count > 0 ? tatuagens[^1].Id + 1 : 1;
            Tatuagem tatuagem = new Tatuagem(id, nome, descricao);
            tatuagens.Add(tatuagem);

            Console.WriteLine("\n                                     Tatuagem adicionada com sucesso!");
            SalvarDados();
        }

        static void ListarTatuagens()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("============  LISTA DE TATUAGENS  ===========");
            CentralizarTexto("=============================================\n");


            if (tatuagens.Count == 0)
            {
                Console.WriteLine("\n                                           Nenhuma tatuagem cadastrada.");
            }
            else
            {
                foreach (var tatuagem in tatuagens)
                {
                    Console.WriteLine($"                                          ID: {tatuagem.Id}");
                    Console.WriteLine($"                                          Nome: {tatuagem.Nome}");
                    Console.WriteLine($"                                          Descrição: {tatuagem.Descricao}");
                }
            }
        }

        static void AtualizarTatuagem()
        {
            Console.Clear();
            CentralizarTexto("============================================="); 
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("==========   ATUALIZAR TATUAGEM   ===========");
            CentralizarTexto("=============================================\n");

            Console.Write("                                     Digite o ID da tatuagem a ser atualizada: ");
            int id = int.Parse(Console.ReadLine());

            var tatuagem = tatuagens.Find(t => t.Id == id);

            if (tatuagem != null)
            {
                Console.Write("                                     Digite o novo nome da tatuagem: ");
                tatuagem.Nome = Console.ReadLine();

                Console.Write("                                     Digite a nova descrição da tatuagem: ");
                tatuagem.Descricao = Console.ReadLine();

                Console.WriteLine("\n                                     Tatuagem atualizada com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\n                                     Tatuagem não encontrada.");
            }
        }

        static void RemoverTatuagem()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("=============  REMOVER TATUAGEM  ============");
            CentralizarTexto("=============================================\n");

            Console.Write("                                     Digite o ID da tatuagem a ser removida: ");
            int id = int.Parse(Console.ReadLine());

            var tatuagem = tatuagens.Find(t => t.Id == id);

            if (tatuagem != null)
            {
                tatuagens.Remove(tatuagem);
                Console.WriteLine("\n                                     Tatuagem removida com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\n                                     Tatuagem não encontrada.");
            }
        }

        static void MenuAgendamentos()
        {
            int opcao;
            do
            {
                Console.Clear();
                CentralizarTexto("=============================================");
                CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
                CentralizarTexto("===============   TATUAGENS   ===============");
                CentralizarTexto("=============================================");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Console.ResetColor();
                CentralizarTexto("=============================================");
                CentralizarTexto("=========  GERENCIAR AGENDAMENTOS  ==========");
                CentralizarTexto("=============================================\n");
                Console.WriteLine("                                              1. Adicionar Agendamento");
                Console.WriteLine("                                              2. Listar Agendamentos");
                Console.WriteLine("                                              3. Atualizar Agendamento");
                Console.WriteLine("                                              4. Remover Agendamento");
                Console.WriteLine("                                              0. Voltar\n");
                CentralizarTexto("=============================================\n");

                Console.Write("                                              Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarAgendamento();
                        break;
                    case 2:
                        ListarAgendamentos();
                        break;
                    case 3:
                        AtualizarAgendamento();
                        break;
                    case 4:
                        RemoverAgendamento();
                        break;
                    case 0:
                        Console.WriteLine("\n                                              Voltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\n                                              Opção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\n                                     Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        static void AdicionarAgendamento()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("========  ADICIONAR NOVO AGENDAMENTO  =======");
            CentralizarTexto("=============================================\n");

            Console.Write("                                     Digite o ID do cliente: ");
            int clienteId = int.Parse(Console.ReadLine());

            var cliente = clientes.Find(c => c.Id == clienteId);
            if (cliente == null)
            {
                Console.WriteLine("\n                           Cliente não encontrado.");
                return;
            }

            Console.Write("                                     Digite o ID da tatuagem: ");
            int tatuagemId = int.Parse(Console.ReadLine());

            var tatuagem = tatuagens.Find(t => t.Id == tatuagemId);
            if (tatuagem == null)
            {
                Console.WriteLine("\n                                     Tatuagem não encontrada.");
                return;
            }

            Console.Write("                                     Digite a data do agendamento (AAAA-MM-DD): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            int id = agendamentos.Count > 0 ? agendamentos[^1].Id + 1 : 1;
            Agendamento agendamento = new Agendamento(id, clienteId, tatuagemId, data);
            agendamentos.Add(agendamento);

            Console.WriteLine("\n                                     Agendamento adicionado com sucesso!");
            SalvarDados();
        }

        static void ListarAgendamentos()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("=========== LISTA DE AGENDAMENTOS  ==========");
            CentralizarTexto("=============================================\n");

            if (agendamentos.Count == 0)
            {
                Console.WriteLine("                                     Nenhum agendamento cadastrado.");
            }
            else
            {
                foreach (var agendamento in agendamentos)
                {
                    var cliente = clientes.Find(c => c.Id == agendamento.ClienteId);
                    var tatuagem = tatuagens.Find(t => t.Id == agendamento.TatuagemId);

                    Console.WriteLine($"                                     ID: {agendamento.Id}");
                    Console.WriteLine($"                                     Cliente: {cliente.Nome}");
                    Console.WriteLine($"                                     Tatuagem: {tatuagem.Nome}");
                    Console.WriteLine($"                                     Data: {agendamento.Data.ToString("yyyy-MM-dd")}");
                    CentralizarTexto("=============================================");
                }
            }
        }

        static void AtualizarAgendamento()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("==========  ATUALIZAR AGENDAMENTO  ==========");
            CentralizarTexto("=============================================\n");

            Console.Write("                                     Digite o ID do agendamento a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var agendamento = agendamentos.Find(a => a.Id == id);

            if (agendamento != null)
            {
                Console.Write("                                     Digite o novo ID do cliente: ");
                int clienteId = int.Parse(Console.ReadLine());
                agendamento.ClienteId = clienteId;

                Console.Write("                                     Digite o novo ID da tatuagem: ");
                int tatuagemId = int.Parse(Console.ReadLine());
                agendamento.TatuagemId = tatuagemId;

                Console.Write("                                     Digite a nova data do agendamento (AAAA-MM-DD): ");
                agendamento.Data = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\n                                     Agendamento atualizado com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\n                                     Agendamento não encontrado.");
            }
        }

        static void RemoverAgendamento()
        {
            Console.Clear();
            CentralizarTexto("=============================================");
            CentralizarTexto("======   SISTEMA DE GERENCIAMENTO DE   ======");
            CentralizarTexto("===============   TATUAGENS   ===============");
            CentralizarTexto("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CentralizarTexto($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.ResetColor();
            CentralizarTexto("=============================================");
            CentralizarTexto("===========  REMOVER AGENDAMENTO  ===========");
            CentralizarTexto("=============================================\n");

            Console.Write("                                     Digite o ID do agendamento a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            var agendamento = agendamentos.Find(a => a.Id == id);

            if (agendamento != null)
            {
                agendamentos.Remove(agendamento);
                Console.WriteLine("\n                                     Agendamento removido com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\n                                     Agendamento não encontrado.");
            }
        }

        static void CarregarDados()
        {
            if (File.Exists(caminhoClientes))
            {
                string clientesJson = File.ReadAllText(caminhoClientes);
                clientes = JsonSerializer.Deserialize<List<Cliente>>(clientesJson);
            }

            if (File.Exists(caminhoTatuagens))
            {
                string tatuagensJson = File.ReadAllText(caminhoTatuagens);
                tatuagens = JsonSerializer.Deserialize<List<Tatuagem>>(tatuagensJson);
            }

            if (File.Exists(caminhoAgendamentos))
            {
                string agendamentosJson = File.ReadAllText(caminhoAgendamentos);
                agendamentos = JsonSerializer.Deserialize<List<Agendamento>>(agendamentosJson);
            }
        }

        static void SalvarDados()
        {
            string clientesJson = JsonSerializer.Serialize(clientes);
            File.WriteAllText(caminhoClientes, clientesJson);

            string tatuagensJson = JsonSerializer.Serialize(tatuagens);
            File.WriteAllText(caminhoTatuagens, tatuagensJson);

            string agendamentosJson = JsonSerializer.Serialize(agendamentos);
            File.WriteAllText(caminhoAgendamentos, agendamentosJson);
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public Cliente(int id, string nome, string telefone, string email, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
        }
    }

    public class Tatuagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Tatuagem(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
    }

    public class Agendamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TatuagemId { get; set; }
        public DateTime Data { get; set; }

        public Agendamento(int id, int clienteId, int tatuagemId, DateTime data)
        {
            Id = id;
            ClienteId = clienteId;
            TatuagemId = tatuagemId;
            Data = data;
        }
    }
}
