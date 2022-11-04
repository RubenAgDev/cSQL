using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class AnalizadorLexico
    {
        private string CodigoSinFormato;
        private string CodigoConFormato;

        private Lista MiLista;

        private ArrayList _Simbolos;

        #region Propiedades
        public ArrayList LosSimbolos
        {
            get { return _Simbolos; }
        }
        public string CodigoInicial
        {
            get { return CodigoSinFormato; }
        }
        public string CodigoNuevo
        {
            get { return CodigoConFormato; }
        }
        #endregion

        public AnalizadorLexico(string CodigoNoFormateado)
        {
            CodigoSinFormato = CodigoNoFormateado;
            
            MiLista = new Lista();

            string NuevoCodigo = EliminarComentarios(CodigoNoFormateado.Trim());
            NuevoCodigo = EliminarSaltosDeLinea(NuevoCodigo);
            NuevoCodigo = EliminarEspacios(NuevoCodigo);

            CodigoConFormato = NuevoCodigo;
        }

        private string EliminarComentarios(string Codigo)
        {
            char[] Caracteres = Codigo.ToCharArray();

            bool EsTexto = false;
            bool EsComentario = false;

            string CodigoSinComentarios = "";

            for (int i = 0; i < Caracteres.Length; i++)
            {
                if (Caracteres[i].Equals('\n'))
                    EsComentario = false;

                if (!EsTexto)
                {
                    if (Caracteres[i].Equals('-'))
                    {
                        if ((i + 1) != Caracteres.Length)
                        {
                            if (Caracteres[i + 1].Equals('-'))
                                EsComentario = true;
                        }
                    }
                }

                if (!EsComentario)
                {
                    if (Caracteres[i].Equals('\'') && EsTexto)
                        EsTexto = false;
                    else if (Caracteres[i].Equals('\''))
                        EsTexto = true;
                }

                if (!EsComentario)
                    CodigoSinComentarios += Caracteres[i];
            }

            return CodigoSinComentarios;
        }

        private string EliminarSaltosDeLinea(string Codigo)
        {
            char[] Caracteres = Codigo.ToCharArray();

            bool EsTexto = false;

            string CodigoSinSaltosDeLinea = "";

            for (int i = 0; i < Caracteres.Length; i++)
            {
                if (EsTexto)
                {
                    if (Caracteres[i].Equals('\''))
                        EsTexto = false;

                    CodigoSinSaltosDeLinea += Caracteres[i];
                    continue;
                }

                if (Caracteres[i].Equals('\''))
                {
                    EsTexto = true;
                    CodigoSinSaltosDeLinea += Caracteres[i];

                    continue;
                }

                if (Caracteres[i].Equals('\n'))
                {
                    CodigoSinSaltosDeLinea += '@';
                    continue;
                }

                CodigoSinSaltosDeLinea += Caracteres[i];
            }

            return CodigoSinSaltosDeLinea;
        }

        private string EliminarEspacios(string Codigo)
        {
            char[] Caracteres = Codigo.ToCharArray();

            bool EsTexto = false;
            bool HayEspacio = false;

            string CodigoSinEspacios = "";

            for (int i = 0; i < Caracteres.Length; i++)
            {
                if (EsTexto)
                {
                    if (Caracteres[i].Equals('\''))
                        EsTexto = false;

                    CodigoSinEspacios += Caracteres[i];

                    continue;
                }

                if (Caracteres[i].Equals('\''))
                {
                    EsTexto = true;
                    CodigoSinEspacios += Caracteres[i];

                    continue;
                }

                if (Caracteres[i].Equals(' '))
                {
                    if (HayEspacio)
                        continue;

                    HayEspacio = true;
                    CodigoSinEspacios += Caracteres[i];

                    continue;
                }

                HayEspacio = false;

                CodigoSinEspacios += Caracteres[i];
            }

            return CodigoSinEspacios;
        }

        public ArrayList ObtenerSimbolos()
        {
            _Simbolos = new ArrayList();
            string Token = "";

            char[] Caracteres = CodigoConFormato.ToCharArray();

            bool EsTexto = false;
            bool OperadorDoble = false;

            int Linea = 1;

            for (int i = 0; i < Caracteres.Length; i++)
            {
                if (Caracteres[i].Equals('\'') && EsTexto)
                {
                    EsTexto = false;
                    Token += Caracteres[i];

                    MiLista.InsertarAlFinal(Token, Linea);
                    _Simbolos.Add(Token);

                    Token = "";

                    OperadorDoble = false;

                    continue;
                }

                if (Caracteres[i].Equals('\''))
                {
                    EsTexto = true;
                    Token += Caracteres[i];

                    OperadorDoble = false;

                    continue;
                }

                if (EsTexto)
                {
                    Token += Caracteres[i];

                    OperadorDoble = false;

                    continue;
                }

                if (OperadorDoble)
                {
                    if (Caracteres[i].Equals('='))
                    {
                        MiLista.InsertarAlFinal(Caracteres[i - 1].ToString() + Caracteres[i].ToString(), Linea);
                        _Simbolos.Add(Caracteres[i - 1].ToString() + Caracteres[i].ToString());

                        OperadorDoble = false;

                        continue;
                    }
                    else if (Caracteres[i].Equals('>') && Caracteres[i - 1].Equals('<'))
                    {
                        MiLista.InsertarAlFinal(Caracteres[i - 1].ToString() + Caracteres[i].ToString(), Linea);
                        _Simbolos.Add(Caracteres[i - 1].ToString() + Caracteres[i].ToString());

                        OperadorDoble = false;

                        continue;
                    }
                    else
                    {
                        if (Caracteres[i - 1].Equals(' '))
                        {
                            MiLista.InsertarAlFinal(Caracteres[i - 2].ToString(), Linea);
                            _Simbolos.Add(Caracteres[i - 2].ToString());
                        }
                        else
                        {
                            MiLista.InsertarAlFinal(Caracteres[i - 1].ToString(), Linea);
                            _Simbolos.Add(Caracteres[i - 1].ToString());
                        }

                        OperadorDoble = false;
                    }
                }

                if (Caracteres[i].Equals(' '))
                {
                    if (Token.Equals(""))
                        continue;

                    MiLista.InsertarAlFinal(Token, Linea);
                    _Simbolos.Add(Token);

                    Token = "";

                    continue;
                }

                if (Caracteres[i].Equals('@'))
                {
                    if (Token.Equals(""))
                    {
                        Linea++;

                        continue;
                    }

                    MiLista.InsertarAlFinal(Token, Linea);
                    _Simbolos.Add(Token);

                    Token = "";

                    Linea++;

                    continue;
                }

                if (Caracteres[i].Equals(',') || Caracteres[i].Equals('+') || Caracteres[i].Equals('-') ||
                    Caracteres[i].Equals('*') || Caracteres[i].Equals('/') || Caracteres[i].Equals(';') ||
                    Caracteres[i].Equals('(') || Caracteres[i].Equals(')') || Caracteres[i].Equals('{') ||
                    Caracteres[i].Equals('[') || Caracteres[i].Equals(']') || Caracteres[i].Equals('}') || 
                    Caracteres[i].Equals('<') || Caracteres[i].Equals('>') || Caracteres[i].Equals('=') || 
                    Caracteres[i].Equals('!'))
                {
                    if (Caracteres[i].Equals('<') || Caracteres[i].Equals('>') || Caracteres[i].Equals('!'))
                    {
                        OperadorDoble = true;

                        if (!Token.Equals(""))
                        {
                            MiLista.InsertarAlFinal(Token, Linea);
                            _Simbolos.Add(Token);

                            Token = "";
                        }

                        continue;
                    }
                    if (Caracteres[i].Equals(';'))
                    {
                        if (!Token.Equals(""))
                        {
                            MiLista.InsertarAlFinal(Token, Linea);
                            _Simbolos.Add(Token);
                        }

                        MiLista.InsertarAlFinal(Caracteres[i].ToString(), Linea);
                        _Simbolos.Add(Caracteres[i].ToString());

                        Token = "";

                        continue;
                    }

                    if (Caracteres[i].Equals('(') || Caracteres[i].Equals(')'))
                    {
                        if (!Token.Equals(""))
                        {
                            MiLista.InsertarAlFinal(Token, Linea);
                            _Simbolos.Add(Token);
                            MiLista.InsertarAlFinal(Caracteres[i].ToString(), Linea);
                            _Simbolos.Add(Caracteres[i].ToString());

                            Token = "";

                            continue;
                        }

                        MiLista.InsertarAlFinal(Caracteres[i].ToString(), Linea);
                        _Simbolos.Add(Caracteres[i].ToString());

                        continue;
                    }

                    if (!(Token.Equals("")))
                    {
                        MiLista.InsertarAlFinal(Token, Linea);
                        _Simbolos.Add(Token);

                        Token = "";
                    }

                    MiLista.InsertarAlFinal(Caracteres[i].ToString(), Linea);
                    _Simbolos.Add(Caracteres[i].ToString());

                    continue;
                }

                Token += Caracteres[i];
            }

            if (!Token.Equals(""))
            {
                MiLista.InsertarAlFinal(Token, Linea);
                _Simbolos.Add(Token);
            }

            return MiLista.ObtenerValores();
        }

        public List<Error> ObtenerErrores()
        {
            return MiLista.Errores;
        }
    }
}