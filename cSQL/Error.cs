using System;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    public class Error
    {
        public int Id;
        public int LineaReferencia;
        public string Token;
        public string Descripcion;

        public Error(int ElId, string ElToken, string LaDescripcion, int LaLineaReferencia)
        {
            Id = ElId;
            Token = ElToken;
            Descripcion = LaDescripcion;
            LineaReferencia = LaLineaReferencia;
        }
    }
}