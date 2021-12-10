using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento
{
    class Folha
    {
        static readonly List<Funcionario> dados = new();
        static readonly List<Trabalho> dados2 = new ();
        public static void AddFuncionario(Funcionario a)
        {
            dados.Add(a);
        }
        public static void AddTrabalho(Trabalho a)
        {
            dados2.Add(a);
        }
        public static Funcionario ConsultarCpf(string cpf)
        {
            {
                foreach (Funcionario b in dados)
                {
                    if (b.Cpf == cpf)
                        return b;
                }
                return null;
            }
        }
        public static Trabalho ConsultarMesAnoCpf(string cpf, string mes, string ano)
        {
            foreach (Trabalho c in dados2)
            {
                if (c.Mes == mes && c.Ano == ano && c.Cpf == cpf)
                    return c;
            }
            return null;
        }
        public static void ConsultarFolha(string mes, string ano, string cpf)
        {
            double valorHora;
            double horasTrabalhadas;
            double salarioBruto;
            double impostoRenda = 0;
            double inss = 0;
            double fgts;
            double salarioLiquido;

            foreach (Trabalho d in dados2)
            {
                valorHora = double.Parse(d.Valordahora);
                horasTrabalhadas = double.Parse(d.Horastrabalhadas);

                if (d.Mes == mes && d.Ano == ano && d.Cpf == cpf)
                {
                    salarioBruto = valorHora * horasTrabalhadas;
                    //imposto de renda
                    if (salarioBruto >= 1372.82 && salarioBruto <= 2743.25)
                        impostoRenda = salarioBruto * 0.15;
                    else if (salarioBruto > 2743.25)
                        impostoRenda = salarioBruto * 0.275;
                    //inss
                    if (salarioBruto <= 868.29)
                        inss = salarioBruto * 0.08;
                    else if (salarioBruto >= 868.30 || salarioBruto <= 1477.14)
                        inss = salarioBruto * 0.09;
                    else if (salarioBruto >= 1477.15 || salarioBruto <= 2894.28)
                        inss = salarioBruto * 0.011;
                    else
                        salarioBruto -= 318.37;
                    //FGTS
                    fgts = salarioBruto * 0.08;
                    //salario liquido
                    salarioLiquido = salarioBruto - impostoRenda - inss;

                    d.Salarioliquido = salarioLiquido;

                    Console.Write("\nSalário Bruto: " + Math.Round(salarioBruto, 2) + " R$ \n");
                    Console.Write("Imposto de Renda: " + Math.Round(impostoRenda, 2) + " R$ \n");
                    Console.Write("INSS: " + Math.Round(inss, 2) + " R$ \n");
                    Console.Write("FGTS: " + Math.Round(fgts, 2) + " R$ \n");
                    Console.WriteLine("Salário Líquido: " + Math.Round(salarioLiquido, 2) + " R$ \n");

                }
            }
        }
        public static Trabalho ConsultarMesAno(string mes, string ano)
        {
            foreach (Trabalho c in dados2)
            {
                if (c.Mes == mes && c.Ano == ano)
                    return c;
            }
            return null;
        }
        public static void ListarFolhas(string mes, string ano)
        {
            double valorHora;
            double horasTrabalhadas;
            double salarioBruto;
            double impostoRenda = 0;
            double inss = 0;
            double salarioLiquido;
            double totalizar1;
            double totalizar2=0;

            foreach (Trabalho d in dados2)
            {
                valorHora = double.Parse(d.Valordahora);
                horasTrabalhadas = double.Parse(d.Horastrabalhadas);

                if (d.Mes == mes && d.Ano == ano)
                {
                    salarioBruto = valorHora * horasTrabalhadas;
                    //imposto de renda
                    if (salarioBruto >= 1372.82 && salarioBruto <= 2743.25)
                        impostoRenda = salarioBruto * 0.15;
                    else if (salarioBruto > 2743.25)
                        impostoRenda = salarioBruto * 0.275;
                    //inss
                    if (salarioBruto <= 868.29)
                        inss = salarioBruto * 0.08;
                    else if (salarioBruto >= 868.30 || salarioBruto <= 1477.14)
                        inss = salarioBruto * 0.09;
                    else if (salarioBruto >= 1477.15 || salarioBruto <= 2894.28)
                        inss = salarioBruto * 0.011;
                    else
                        salarioBruto -= 318.37;
                    //salario liquido
                    salarioLiquido = salarioBruto - impostoRenda - inss;
                    //totalizar = salarioLiquido;

                    totalizar1 = salarioLiquido;
                    totalizar2 = totalizar1 + totalizar2;

                    Console.WriteLine("\nNome: " + d.Nome);
                    Console.WriteLine("Salário Líquido: " + Math.Round(salarioLiquido, 2) + " R$");
                }
            }
            Console.WriteLine("\nSalário Total: " + Math.Round(totalizar2, 2) + " R$\n");
        }
    }
}
