﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace BasicCompiler
{
    internal class Compiler
    {
        List<string> palavrasReservadas = new List<string>();
        List<string> ListaDeErros = new List<string>();
        List<string> lexemas = new List<string>();
        List<string> tokens = new List<string>();
        TabelaDeSimbolos tabelaDeSimbolos = new TabelaDeSimbolos();
        private string lexema = "";
        private int state = 0;

        public Compiler()
        {
            preencherPalavrasReservadas();
        }

        public void compilerLine(string line, int numeroLinha)
        {
            List<char> lineChar = line.ToList<char>();
            lineChar.Add(' ');

            foreach(char caractere in lineChar)
            {
                switch (state)
                {
                    case 0:
                        #region
                        Regex regexLetras = new Regex(@"^[a-zA-Z]+$");
                        if (regexLetras.IsMatch(caractere.ToString()))
                        {
                            state = 1;
                            lexema += caractere;
                            break;
                        }
                        if (char.IsDigit(caractere))
                        {
                            state = 3;
                            lexema += caractere;
                            break;
                        }
                        if (caractere == '"')
                        {
                            lexema = lexema + caractere;
                            state = 8;
                            break;
                        }
                        if(caractere == '/')
                        {
                            state = 10;
                            lexema += caractere;
                            break;
                        }
                        if (caractere == '+')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == '-')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == '*')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == '%')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == '=')
                        {
                            state = 18;
                            lexema += caractere;
                            break;
                        }
                        if (caractere == '!')
                        {
                            state = 21;
                            lexema += caractere;
                            break;
                        }
                        if (caractere == '>')
                        {
                            state = 24;
                            lexema += caractere;
                            break;
                        }
                        if (caractere == '<')
                        {
                            state = 27;
                            lexema += caractere;
                            break;
                        }
                        if (caractere == '|')
                        {
                            state = 30;
                            lexema += caractere;
                            break;
                        }
                        if (caractere == '&')
                        {
                            state = 32;
                            lexema += caractere;
                            break;
                        }
                        if (caractere == ',')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == ';')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == '(')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == ')')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == '[')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == ']')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == '{')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }
                        if (caractere == '}')
                        {
                            lexemas.Add(caractere.ToString());
                            tokens.Add(caractere.ToString());
                            break;
                        }

                        if(caractere != ' ')
                        {
                            ListaDeErros.Add($"Caractere desconhecido na linha:  {numeroLinha}");
                        }
                        #endregion
                        break;

                    case 1:
                        Regex regexLetrasENumeros = new Regex(@"^[a-zA-Z0-9]+$");
                        if (char.IsLetterOrDigit(caractere))
                        {
                            if (regexLetrasENumeros.IsMatch(caractere.ToString()))
                            {
                                lexema = lexema + caractere;
                            }
                            else
                            {
                                ListaDeErros.Add($"Caractere desconhecido em nome de variavel na linha: {numeroLinha}");
                                state = 2;
                            }
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            VerificaEAdicionaToken(lexema);
                            lexema = "";
                            state = 0;
                            goto case 0;
                        }
                        
                        break;
                    case 2:
                        if (!char.IsLetterOrDigit(caractere))
                        {
                            lexema = "";
                            state = 0;
                            goto case 0;
                        }
                        break;
                    case 3:
                        if (char.IsLetter(caractere))
                        {
                            ListaDeErros.Add($"Variável começando com número na linha: {numeroLinha}");
                            state = 2;
                        }
                        if (char.IsDigit(caractere))
                        {
                            lexema = lexema + caractere;
                        }
                        if(caractere == '.')
                        {
                            lexema = lexema + caractere;
                            state = 5;
                            break;
                        }
                        if (!char.IsLetterOrDigit(caractere))
                        {
                            lexemas.Add(lexema);
                            tokens.Add("NUMINT, " + lexema);
                            lexema = "";
                            state = 0;
                            goto case 0;
                        }
                        break;
                    case 5:
                        if (char.IsDigit(caractere))
                        {
                            lexema = lexema + caractere;
                            state = 6;
                        }
                        else
                        {
                            ListaDeErros.Add($"Um decimal sem digito após . na linha: {numeroLinha}");
                            state = 0;
                            lexema = "";
                            goto case 0;
                        }
                        break;
                    case 6:
                        if (char.IsDigit(caractere))
                        {
                            lexema = lexema + caractere;
                        }
                        if (!char.IsLetterOrDigit(caractere))
                        {
                            lexemas.Add(lexema);
                            tokens.Add("NUMDEC, " + lexema);
                            lexema = "";
                            state = 0;
                            goto case 0;
                        }
                        break;
                    case 8:

                        if (caractere == '"')
                        {
                            lexema = lexema + caractere;
                            lexemas.Add(lexema);
                            tokens.Add("TEXTO, " + lexema);
                            lexema = "";
                            state = 0;
                            break;
                        }
                        if(caractere == '\n' || lineChar.IndexOf(caractere) == lineChar.Count - 1)
                        {
                            ListaDeErros.Add($"Uso de aspas incorreto na linha: {numeroLinha}");
                            lexema = "";
                            state = 0;
                            break;
                        }
                        if(caractere != '"' && caractere != '\n')
                        {
                            lexema = lexema + caractere;
                        }
                        break;
                    case 10:
                        if(caractere == '/')
                        {
                            state = 11;
                            lexema = lexema + caractere;
                        }
                        else
                        {
                            adicionandoLexemaToken(lexema);
                        }
                        break;

                    case 18:
                        if (caractere == '=')
                        {
                            lexema += caractere;
                            adicionandoLexemaToken(lexema);
                        }
                        else
                        {
                            adicionandoLexemaToken(lexema);
                            goto case 0;
                        }
                        break;

                    case 21:
                        if (caractere == '=')
                        {
                            lexema += caractere;
                            adicionandoLexemaToken(lexema);
                        }
                        else
                        {
                            adicionandoLexemaToken(lexema);
                            goto case 0;
                        }
                        break;

                    case 24:
                        if (caractere == '=')
                        {
                            lexema += caractere;
                            adicionandoLexemaToken(lexema);
                        }
                        else
                        {
                            adicionandoLexemaToken(lexema);
                            goto case 0;
                        }
                        break;

                    case 27:
                        if(caractere == '=')
                        {
                            lexema += caractere;
                            adicionandoLexemaToken(lexema);
                        }
                        else
                        {
                            adicionandoLexemaToken(lexema);
                            goto case 0;
                        }
                        break;

                    case 30:
                        if(caractere == '|')
                        {
                            lexema += caractere;
                            adicionandoLexemaToken(lexema);
                        }
                        else
                        {
                            ListaDeErros.Add($"Operador | utilizado de maneira incorreta na linha: {numeroLinha}");
                        }
                        break;
                    case 32:
                        if(caractere == '&')
                        {
                            lexema += caractere;
                            adicionandoLexemaToken(lexema);
                        }
                        else
                        {
                            ListaDeErros.Add($"Operador & utilizado de maneira incorreta na linha: {numeroLinha}");
                        }
                        break;
                    case 11:
                        if (caractere == '\n')
                        {
                            lexemas.Add(lexema);
                            tokens.Add("COMMENT, " + lexema);
                            lexema = "";
                            state = 0;
                        }
                        else
                        {
                            lexema = lexema + caractere;
                        }
                        break;
                }
            }
        }

        public void mostrarResultado()
        {
            Console.WriteLine("LEXEMAS");
            foreach (var item in lexemas)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nTOKENS");
            foreach (var item in tokens)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nTABELA SIMBOLOS");
            foreach (var item in tabelaDeSimbolos.simbolos)
            {
                Console.WriteLine(item.Id + " - " + item.Variavel);
            }
            if(ListaDeErros.Count > 0)
            {
                Console.WriteLine("\nLISTA DE ERROS");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (var item in ListaDeErros)
                {
                    Console.WriteLine(item);
                }
                Console.ResetColor();
            }
        }

        private void VerificaEAdicionaToken(string lexema)
        {
            if(palavrasReservadas.Exists(x => x == lexema))
            {
                tokens.Add(lexema);
            }
            else
            {
                if(!tabelaDeSimbolos.simbolos.Any(x => x.Variavel == lexema))
                {
                    tabelaDeSimbolos.AdicionarSimbolo(lexema);
                }
                tokens.Add("ID, " + tabelaDeSimbolos.simbolos.Find(x => x.Variavel == lexema).Id);
            }
        }

        private void adicionandoLexemaToken(string lexemaParametro)
        {
            lexemas.Add(lexema);
            tokens.Add(lexema);
            lexema = "";
            state = 0;
        }
        private void preencherPalavrasReservadas()
        {
            palavrasReservadas.Add("public");
            palavrasReservadas.Add("void");
            palavrasReservadas.Add("int");
            palavrasReservadas.Add("float");
            palavrasReservadas.Add("char");
            palavrasReservadas.Add("boolean");
            palavrasReservadas.Add("if");
            palavrasReservadas.Add("else");
            palavrasReservadas.Add("for");
            palavrasReservadas.Add("while");
            palavrasReservadas.Add("scanf");
            palavrasReservadas.Add("println");
            palavrasReservadas.Add("return");
        }
    }
}
