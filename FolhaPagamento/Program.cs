using System;

namespace FolhaPagamento
{
    class Program
    {
        static void Main()
        {
            int menu;

            do
            {
                Console.WriteLine("Digite uma das opções abaixo:\n");
                Console.WriteLine("1) Cadastro de funcionários.");
                Console.WriteLine("2) Cadastro da folha.");
                Console.WriteLine("3) Consultar folha.");
                Console.WriteLine("4) Listar folhas.");
                Console.WriteLine("5) Sair.");
                Console.Write("Informe a opção: ");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:

                        Funcionario funcionario = new();
                        Trabalho trabalho = new ();

                        Console.Clear();
                        Console.Write("CPF: ");
                        funcionario.Cpf = Console.ReadLine();

                        if (Folha.ConsultarCpf(funcionario.Cpf) == null)
                        {
                            Console.Write("Nome: ");
                            funcionario.Nome = Console.ReadLine();
                            trabalho.Nome = funcionario.Nome;
                            Folha.AddFuncionario(funcionario);
                            Console.WriteLine("\nFuncionario adicionado à sua folha!\n");
                        }
                        else
                        {
                            Console.WriteLine("\nATEÇÃO: Funcionário já cadastrado!\n");
                        }
                        break;

                    case 2:

                        trabalho = new Trabalho();
                        string mes;
                        string ano;
                        string cpf;

                        Console.Clear();
                        Console.Write("CPF: ");
                        cpf = Console.ReadLine();
                        trabalho.Cpf = cpf;

                        if (Folha.ConsultarCpf(cpf) == null)
                        {
                            Console.WriteLine("\nATENÇÃO: Funcionário NÂO cadastrado!\n");
                            break;
                        }

                        Console.Write("Insira o mês de trabalho: ");
                        trabalho.Mes = Console.ReadLine();
                        Console.Write("Insira o ano de trabalho: ");
                        trabalho.Ano = Console.ReadLine();
                        mes = trabalho.Mes;
                        ano = trabalho.Ano;

                        if (Folha.ConsultarMesAnoCpf(cpf, mes, ano) == null)
                        {
                            Console.Write("Digite as horas trabalhadas: ");
                            trabalho.Horastrabalhadas = Console.ReadLine();
                            Console.Write("Digite o valor das horas trabalhadas: ");
                            trabalho.Valordahora = Console.ReadLine();
                            Folha.AddTrabalho(trabalho);
                            Console.Write("\nATENÇÃO: cadastrado com sucesso.\n\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nATENÇÃO: Um Funcionário com esse CPF ja foi cadastrado nesse mês e nesse ano!");
                            break;
                        }
                        break;
                    case 3:

                        Console.Clear();
                        Console.Write("CPF: ");
                        cpf = Console.ReadLine();
                        if (Folha.ConsultarCpf(cpf) == null)
                        {
                            Console.WriteLine("\nATENÇÃO: Funcionário NÂO cadastrado!\n");
                            break;
                        }

                        Console.Write("Insira o mês de trabalho: ");
                        mes = Console.ReadLine();
                        Console.Write("Insira o ano de trabalho: ");
                        ano = Console.ReadLine();

                        if (Folha.ConsultarMesAnoCpf(cpf, mes, ano) == null)
                        {
                            Console.WriteLine("\nNão há nenhum CPF cadastrado com o mês e ano digitados!\n");
                        }
                        else
                        {
                            Folha.ConsultarFolha(mes, ano, cpf);
                        }
                        break;
                    case 4:

                        Console.Clear();
                        Console.Write("Insira o mês de trabalho: ");
                        mes = Console.ReadLine();
                        Console.Write("Insira o ano de trabalho: ");
                        ano = Console.ReadLine();

                        if (Folha.ConsultarMesAno(mes, ano) == null)
                        {
                            Console.WriteLine("\nATENÇÃO: Funcionário NÂO cadastrado!\n");
                        }
                        else
                        {
                            Folha.ListarFolhas(mes, ano);
                        }
                        break;

                    case 5:
                        break;

                    default:

                        Console.Clear();
                        Console.WriteLine("Entre uma Opção Válida.\n");
                        break;
                }
            }
            while (menu != 5);
        }
    }
}
