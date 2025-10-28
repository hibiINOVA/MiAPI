﻿using MiApi.Models;

namespace MiApi.DTOs;

public class AlumnoDTO
{
    public string Nombre { get; set; }
    public string Correo { get; set; }

    public AlumnoDTO(AlumnoM alumno){
        Nombre = alumno.Nombre;
        Correo = alumno.Correo;
    }
}
