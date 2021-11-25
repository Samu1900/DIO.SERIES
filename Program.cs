using System;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Progam
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        private static int i;

        static void Main(string[] args)
        {
        string OpcaoUsuario = ObterOpcaoUsuario();

        while(OpcaoUsuario.ToUpper() != "X")
        {
            switch(OpcaoUsuario)
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
            OpcaoUsuario = ObterOpcaoUsuario();
        }
             Console.WriteLine("Origado por utilizar nossos serviços.");
             Console.ReadLine();
        }

        private static void ListarSeries()//1
        {
            Console.WriteLine("Listar Séries");

            var Lista = repositorio.Lista();

            if (Lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach(var serie in Lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine(" #IS {0} : - {1} {2}" ,serie.retornaId(), serie.retornaTitulo(),(excluido ? "*Excluido*" : ""));
            }
            }
            
    

        private static void InserirSerie ()//2
        {
            Console.WriteLine("Inserir nova série");
            
        
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
            Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genero), i));
                    
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse (Console.ReadLine());

            Console.WriteLine("Digite o Título da Serie : ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            String entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                                    
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()//3
        {
            Console.WriteLine("Digite o id da série: ");
            int indeceSerie = int.Parse(Console.ReadLine());

         foreach (int i in Enum.GetValues(typeof(Genero)))
            {
            Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genero), i));
                    
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse (Console.ReadLine());

            Console.WriteLine("Digite o Título da Serie : ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            String entradaDescricao = Console.ReadLine();

            Serie atualiaSerie = new Serie (id: indeceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indeceSerie,  atualiaSerie );
    
            
        }
        private static void ExcluirSerie()//4
        { 
            Console.WriteLine("Digite o id da série: ");

            int indeceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indeceSerie);

        }


         private static void VisualizarSerie()//5
        {
            Console.WriteLine("Digite o id da série: ");

            int indeceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorID(indeceSerie);

            Console.WriteLine(serie);
        }




        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("SAM Séries a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada: ");
            
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir navas série ");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            

        }
    }
}