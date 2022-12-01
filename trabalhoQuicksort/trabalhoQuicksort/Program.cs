using System;

namespace trabalhoQuicksort
{
    public class Global
    {
        public static int MovimentacoesQuicksort { get; set; }
        public static int ComparacoesQuicksort { get; set; }
        public static int MovimentacoesInsertionSort { get; set; }
        public static int ComparacoesInsertionSort { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ordenado = false;
            int tamanhoArray;
            int positionInicial = 0;
            int cont = 0;
            tamanhoArray = leTamanhoArray();
            int[] arr = new int[tamanhoArray];
            int[] sorted = new int[tamanhoArray];
            int[] sortedQuickSortClassico = new int[tamanhoArray];
            int quatidadeSubvetores = qtdSubvetores(tamanhoArray);
            int escalaDivisao = tamanhoArray / quatidadeSubvetores;
            arr = criaArray(tamanhoArray);
            int posicaofinal = arr.Length / quatidadeSubvetores;

            Console.WriteLine("Impressão do array desordenado");
            imprimeArray(arr, ordenado);
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("Impressão do método QuickSort clássico");
            //sortedQuickSortClassico = QuickSort(arr, positionInicial, arr.Length);
            //imprimeArray(sortedQuickSortClassico, ordenado = true);

            //Console.WriteLine("Impressão do método InsertionSort clássico");
            //int[] sortedInsertionClassico = insertionSort(arr);
            //imprimeArrayOrdenadoInsertion(sortedInsertionClassico);

            Console.WriteLine("Impressão do QuickSort + InsertionSort");

            while (tamanhoArray != 0)
            {
                sorted = QuickSort(arr, positionInicial, posicaofinal);
                posicaofinal = posicaofinal + escalaDivisao;
                positionInicial = positionInicial + escalaDivisao;
                tamanhoArray = tamanhoArray - escalaDivisao;
                cont++;
            }
            ordenado = true;
            imprimeArray(sorted, ordenado);

            int[] sortedInsertion = insertionSort(sorted);
            imprimeArrayOrdenadoInsertion(sortedInsertion);
            Console.WriteLine();
            Console.ReadKey();
        }

        private static int qtdSubvetores(int tamanhoArray)
        {
            return tamanhoArray / (tamanhoArray / 10);
        }

        private static void imprimeArray(int[] arr, bool flagOrdenado)
        {
            if (!flagOrdenado)
            {
              //  Console.WriteLine("Elementos do Vetor principal");
                foreach (int elementos in arr)
                {
                    Console.Write(elementos + " ");
                }
                Console.WriteLine();
            }
            if (flagOrdenado)
            {
               // Console.WriteLine("Elementos do Vetor principal Ordenado");
                foreach (int elementos in arr)
                {
                    Console.Write(elementos + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Número de movimentações do QuickSort: " + Global.MovimentacoesQuicksort);
                Console.WriteLine("Número de comparações do QuickSort: " + Global.ComparacoesQuicksort);
            }
        }

        private static void imprimeArrayOrdenadoInsertion(int[] arr)
        {
          //  Console.WriteLine("Elementos do Vetor Ordenado com insertion");
            foreach (int elementos in arr)
            {
                Console.Write(elementos + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Número de movimentações do InsertionSort: " + Global.MovimentacoesInsertionSort);
            Console.WriteLine("Número de comparações do InsertionSort: " + Global.ComparacoesInsertionSort);
        }

        public static int leTamanhoArray()
        {
          Console.WriteLine("Digite o tamanho do array para ser ordenado");

            int tamanho = int.Parse(Console.ReadLine());
            bool multiploDez = ((tamanho % 10) == 0);

            while (!multiploDez)
            {
                if (!multiploDez)
                {
                    Console.WriteLine("Digite um tamanho multiplo de dez");
                    tamanho = int.Parse(Console.ReadLine());
                }
                multiploDez = ((tamanho % 10) == 0);
            }

            Console.WriteLine("Tamanho selecionado com sucesso, precione qualquer tecla para seguir");
            Console.ReadKey();
            Console.Clear();
            return tamanho;
        }

        public static int[] criaArray(int quantidadeNumero)
        {
            int[] vetorPrincipal = new int[quantidadeNumero];


            Random rand = new Random();
            for (int i = 0; i < vetorPrincipal.Length; i++)
            {
                vetorPrincipal[i] = rand.Next(quantidadeNumero);
            }

            return vetorPrincipal;
        }

        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static int[] QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partion(arr, start, end);
                QuickSort(arr, start, pivot);
                QuickSort(arr, pivot + 1, end);
            }
            return arr;
        }

        public static int Partion(int[] arr, int start, int end)
        {
            int pivot = arr[start];
            int swapIndex = start;

            for (int i = start + 1; i < end; i++)
            {
                Global.ComparacoesQuicksort ++;
                if (arr[i] < pivot)
                {
                    swapIndex++;
                    Swap(arr, i, swapIndex);
                    Global.MovimentacoesQuicksort ++;
                }
            }
            Swap(arr, start, swapIndex);
            return swapIndex;
        }

        public static int[] insertionSort(int[] list)
        {
            int i, j, key, temp;

            for (i = 1; i < list.Length; i++)
            {
                key = list[i];
                j = i - 1;

                Global.ComparacoesInsertionSort++;
                while (j >= 0 && key < list[j])
                {
                    Global.MovimentacoesInsertionSort ++;
                    temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                    j--;
                }
            }
            return list;
        }
    }
}