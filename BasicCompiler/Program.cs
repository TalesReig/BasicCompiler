﻿using BasicCompiler;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Compiler compiladorTabajara = new Compiler();
            string filePath = "C:\\MeusDocumentos\\arquivo.txt";
            StreamReader sr = new StreamReader(filePath);
            string linha;

            while ((linha = sr.ReadLine()) != null)
            {
                compiladorTabajara.compilerLine(linha);
            }

            compiladorTabajara.mostrarLexemas();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}