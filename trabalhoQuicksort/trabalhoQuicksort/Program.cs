using System;

namespace trabalhoQuicksort
{
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
            int quatidadeSubvetores = qtdSubvetores(tamanhoArray);
            int escalaDivisao = tamanhoArray / quatidadeSubvetores;
            criaArray(ref arr, tamanhoArray);
            int posicaofinal = arr.Length / quatidadeSubvetores;
            imprimeArray(ref arr, ordenado);

            while (tamanhoArray != 0)
            {
                sorted = QuickSort(arr, positionInicial, posicaofinal);
                posicaofinal = posicaofinal + escalaDivisao;
                positionInicial = positionInicial + escalaDivisao;
                tamanhoArray = tamanhoArray - escalaDivisao;
                cont++;
            }
            ordenado = true;
            imprimeArray(ref sorted, ordenado);

            int[] sortedInsertion = insertionSort(sorted);
            imprimeArrayOrdenadoInsertion(ref sortedInsertion);
            Console.WriteLine();
            Console.ReadKey();
        }

        private static int qtdSubvetores(int tamanhoArray)
        {
            return tamanhoArray / (tamanhoArray / 10);
        }

        private static void imprimeArray(ref int[] arr, bool flagOrdenado)
        {
            if (!flagOrdenado)
            {
                Console.WriteLine("Elementos do Vetor principal");
                foreach (int elementos in arr)
                {
                    Console.Write(elementos + " ");
                }
                Console.WriteLine();
            }
            if (flagOrdenado)
            {
                Console.WriteLine("Elementos do Vetor principal Ordenado");
                foreach (int elementos in arr)
                {
                    Console.Write(elementos + " ");
                }
                Console.WriteLine();
            }
        }

        private static void imprimeArrayOrdenadoInsertion(ref int[] arr)
        {
            Console.WriteLine("Elementos do Vetor Ordenado com insertion");
            foreach (int elementos in arr)
            {
                Console.Write(elementos + " ");
            }
            Console.WriteLine();
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
            }

            Console.WriteLine("Tamanho selecionado com sucesso, precione qualquer tecla para seguir");
            Console.ReadKey();
            Console.Clear();
            return tamanho;
        }

        public static void criaArray(ref int[] vetorPrincipal, int quantidadeNumero)
        {

            Random rand = new Random();
            for (int i = 0; i < vetorPrincipal.Length; i++)
            {
                vetorPrincipal[i] = rand.Next(quantidadeNumero);
            }
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
                if (arr[i] < pivot)
                {
                    swapIndex++;
                    Swap(arr, i, swapIndex);
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

                while (j >= 0 && key < list[j])
                {
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