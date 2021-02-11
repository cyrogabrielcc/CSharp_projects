using System;

namespace Serie
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
             string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X") 
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                    break;
                    case "2":
                        InserirSerie();
                    break;
                    case "3":
                        AtualizarSerie();
                    break;
                    case "4":
                        ExcluirSerie();
                    break;
                    case "5":
                        VisualizarSerie();
                    break;
                    case "C":
                        Console.Clear();
                    break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Volte sempre!");
            Console.ReadLine();
        }
            private static void ListarSeries()
            {
                Console.WriteLine();
                Console.WriteLine("Listar Séries.");

                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadasrtada!"); 
                    return;                   
                }

                foreach(var serie in lista){
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0} - {1}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "excluído": ""));
                }
            }
            private static void ExcluirSerie()
		    {
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		    }
            
            private static void InserirSerie()
            {
                Console.WriteLine();
                Console.WriteLine("Inserir Séries.");

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
                }
                
                Console.Write("Digite o gênero dentre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o título: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o ano: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a descrição: ");
                string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(
                                        id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                        );

            repositorio.Insere(novaSerie);
            }

            /*Atualizar série*/
            private static void AtualizarSerie()
		    {
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        //ver série

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

           public static string ObterOpcaoUsuario()
           {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|- CG Series ao seu dispor!-|");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Séries: ");
            Console.WriteLine("2 - Add Séries: ");
            Console.WriteLine("3 - Atualizar séries: ");
            Console.WriteLine("4 - Excluir séries:");
            Console.WriteLine("5 - Ver série :"); 
            Console.WriteLine("C - Limpar tela:");
            Console.WriteLine("X - Sair: ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
