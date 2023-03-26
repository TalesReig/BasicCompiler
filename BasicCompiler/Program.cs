using BasicCompiler;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Compiler compiladorTabajara = new Compiler();
            string filePath = "C:\\TextoTeste\\teste.txt";
            StreamReader sr = new StreamReader(filePath);
            string linha;

            while ((linha = sr.ReadLine()) != null)
            {
                compiladorTabajara.compilerLine(linha);
            }
            sr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}