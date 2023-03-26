using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCompiler
{
    public class TabelaDeSimbolos
    {
        public List<Simbolo> simbolos = new List<Simbolo>();

        public void AdicionarSimbolo(string lexema)
        {
            var simbolo = new Simbolo()
            {
                Id = simbolos.Count() + 1,
                Nome = lexema
            };
            
            simbolos.Add(simbolo);
        }

    }
}
