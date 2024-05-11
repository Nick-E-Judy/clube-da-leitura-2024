﻿using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class Reserva : EntidadeBase
    {
        public Reserva(Amigo amigo, Revista revista)
        {
            dataAbertura = DateTime.Now;
            Amigo = amigo;
            Revista = revista;
            Expirada = dataAbertura.AddDays(2); ;
        }

        public DateTime dataAbertura { get; set; }

        public Amigo Amigo { get; set; }

        public Revista Revista { get; set; }

        public DateTime Expirada { get; set; }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Reserva novasInformacoes = (Reserva)novoRegistro;

            this.Amigo = novasInformacoes.Amigo;
            this.Revista = novasInformacoes.Revista;
        }

        public override List<String> Validar()
        {
            List<String> erros = [];

            if (Amigo == null)
                erros.Add("Informe um número válido");

            if (Revista == null)
                erros.Add("Informe uma revista válida");

            return erros;
        }

        public bool Status()
        {
            return DateTime.Now > Expirada;
        }
    }
}