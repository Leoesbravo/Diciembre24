﻿namespace ML
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public string Turno { get; set; }
        public string CicloEscolar { get; set; }
        public ML.Grupo Grupo { get; set; }
        
    }
}