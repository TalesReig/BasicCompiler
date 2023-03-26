﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCompiler
{
    internal class Compiler
    {
        List<string> palavrasReservadas = new List<string>();
        List<string> ListaDeErros = new List<string>();
        List<string> lexemas = new List<string>();
        List<string> tokens = new List<string>();
 
        public Compiler()
        {
            preencherPalavrasReservadas();
        }

        public void compilerLine(string line)
        {
            char[] lineChar = line.ToCharArray();
            string lexema = "";
            int state = 0;

            foreach(char caractere in lineChar)
            {
                switch (state)
                {
                    case 0:
                        if (char.IsLetter(caractere))
                        {
                            state = 1;
                            lexema = lexema + caractere;
                            break;
                        }
                        if (char.IsDigit(caractere))
                        {
                            state = 2;
                            lexema = lexema + caractere;
                        }
                        if (caractere == '+')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if (caractere == '-')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if (caractere == '*')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if (caractere == '%')
                        {
                            lexemas.Add(caractere.ToString());
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
                        }
                        if (caractere == ';')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if (caractere == '(')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if (caractere == ')')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if (caractere == '[')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if(caractere == ']')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if (caractere == '{')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        if(caractere == '}')
                        {
                            lexemas.Add(caractere.ToString());
                        }
                        break;

                    case 1:
                        if (char.IsLetterOrDigit(caractere))
                        {
                            lexema = lexema + caractere;
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        break;

                    case 18:
                        if (caractere == '=')
                        {
                            lexema += caractere;
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                            goto case 0;
                        }
                        break;

                    case 21:
                        if (caractere == '=')
                        {
                            lexema += caractere;
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                            goto case 0;
                        }
                        break;

                    case 24:
                        if (caractere == '=')
                        {
                            lexema += caractere;
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                            goto case 0;
                        }
                        break;

                    case 27:
                        if(caractere == '=')
                        {
                            lexema += caractere;
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                            goto case 0;
                        }

                        break;
                    case 30:
                        if(caractere == '|')
                        {
                            lexema += caractere;
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        break;
                    case 32:
                        if(caractere == '&')
                        {
                            lexema += caractere;
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        else
                        {

                        }
                        break;
                }
            }
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
