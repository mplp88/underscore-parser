using System;

namespace UnderscoreParser
{
    public class Capitalizer
    {
        string[] DiccionarioConectores { get; }

        public Capitalizer()
        {
            DiccionarioConectores = new string[] {
                "el",
                "la",
                "de",
                "del",
                "con"
            };
        }

        public string CapitalizeWords(string[] palabras, out bool capitalizado) {
            bool palabraEnDiccionario = false;
            capitalizado = false;

            for(int i = 0; i < palabras.Length; i++)
            {
                palabraEnDiccionario = EnDiccionaroDeConectores(palabras[i]);
                char[] letras = palabras[i].ToCharArray();
                for(int j = 0; j < letras.Length; j++)
                {
                    if(!palabraEnDiccionario && j == 0) 
                    {
                        if(letras[0] != Convert.ToChar(letras[0].ToString().ToUpper()))
                        {
                            letras[0] = Convert.ToChar(letras[0].ToString().ToUpper());
                            capitalizado = true;    
                        }
                    }
                    else
                    {
                        if(letras[j] != Convert.ToChar(letras[j].ToString().ToLower()))
                        {
                            capitalizado = true;
                        }
                        letras[j] = Convert.ToChar(letras[j].ToString().ToLower());
                    }

                    palabras[i] = string.Join("", letras);
                }
            }

            return string.Join(" ", palabras);
        }

        public string CapitalizeWords(string frase, out bool capitalizado)
        {        
            string[] palabras = frase.Split(' ');
            return CapitalizeWords(palabras, out capitalizado);
        }

        public bool EnDiccionaroDeConectores(string palabra)
        {
            foreach(string p in DiccionarioConectores)
            {
                if(palabra.ToLower().Equals(p))
                {
                   return true;
                }
            }

            return false;
        }
    }
}