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
