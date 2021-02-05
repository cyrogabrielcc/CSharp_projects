using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X") 
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        // ListarContas();
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
                    case "C":
                        Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }





            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Cyro");
            Console.WriteLine(minhaConta.ToString());
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor do saque: ");
            double valorDeposito = double.Parse(Console.ReadLine());
        
            listContas[indiceConta].Sacar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da conta destino: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
        
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());
        
            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.Write("Digite 1 - PF || 2 - PJ: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.Write("Nome do(a) Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
                                        saldo: entradaSaldo, 
                                        credito: entradaCredito, 
                                        nome: entradaNome
                                    );
            listContas.Add(novaConta);
        }

        public static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Banco ATEU, Ateu dispor");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("Banco ATEU, Ateu dispor");
            Console.WriteLine("1 - Listar Contas: ");
            Console.WriteLine("2 - inserir nova conta: ");
            Console.WriteLine("3 - Transferir: ");
            Console.WriteLine("4 - Saque: ");
            Console.WriteLine("5 - Depósito: ");
            Console.WriteLine("C - Clean: ");
            Console.WriteLine("X - Sair: ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            
            Console.WriteLine();

            return opcaoUsuario;
        } 
    }
}
