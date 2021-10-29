using System;
using System.Collections.Generic;

namespace DioBank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpçaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                         InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpçaoUsuario();
            }

            Console.WriteLine("Obrigado por ultilizar nossos serviços!!");
            Console.ReadLine();
        }

        //=================================================================================
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTrasnferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTrasnferencia, listContas[indiceContaDestino]);
        }


        //=================================================================================

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDepositado = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDepositado);
        }

        //=================================================================================

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }


        //=================================================================================

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas: ");

            if (listContas.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        //=================================================================================

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta:");
            
            Console.Write("Digite 1 para conta física ou 2 para conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial: R$");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Limite de Credito: R$");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        //==================================================================================
        private static string ObterOpçaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Paulo Bank a seu Dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Infrome a opção desejada: ");
            Console.WriteLine();

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        //=====================================================================================
    }
}
