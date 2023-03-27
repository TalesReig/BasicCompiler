using BasicCompiler;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        string linha;
        int contLinha = 0;
        string filePath = "C:\\MeusDocumentos\\arquivo.txt";

        try
        {
            Compiler compiladorTabajara = new Compiler();
            StreamReader sr = new StreamReader(filePath);

            while ((linha = sr.ReadLine()) != null)
            {
                contLinha++;
                compiladorTabajara.compilerLine(linha, contLinha);
            }

            compiladorTabajara.mostrarResultado();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}