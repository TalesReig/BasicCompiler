using System;
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
                        if(caractere == '"')
                        {
                            state = 8;
                        }
                        break;
                        if(caractere == '/')
                        {
                            state = 10;
                            lexema = lexema + caractere;
                        }
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
                    case 3:
                        if (char.IsDigit(caractere))
                        {
                            lexema = lexema + caractere;
                        }
                        if(caractere == '.')
                        {
                            state = 5;
                        }
                        if (!char.IsLetterOrDigit(caractere))
                        {
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        break;
                    case 5:
                        if (char.IsDigit(caractere))
                        {
                            lexema = lexema + caractere;
                        }
                        if (!char.IsLetterOrDigit(caractere))
                        {
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        break;
                    case 8:
                        if(caractere == '"')
                        {
                            lexemas.Add(lexema);
                            lexema = "";
                            state = 0;
                        }
                        if(caractere == '\n')
                        {
                            //erro
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
                            //erro
                        }
                        break;
                    case 11:
                        if (caractere == '\n')
                        {
                            lexemas.Add(lexema);
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
