using DataContracts;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototipos.Models
{
    public class ComentarioNoticiaBean
    {

        public string usuario { get; set; }
        public string mensaje { get; set; }
        public DateTime fecha { get; set; }

        public static List<ComentarioNoticiaBean> getComents(List<ComentariosNoticias> listaComents)
        {
            List<ComentarioNoticiaBean> lista = new List<ComentarioNoticiaBean>();
            foreach (var coment in listaComents)
            {
                ComentarioNoticiaBean comentario = new ComentarioNoticiaBean();
                Usuarios user = Usuario.getUser(coment.IDUsuario);
                comentario.usuario = user.nombre + " " + user.apellido1 + " " + user.apellido2;
                comentario.mensaje = coment.mensaje;
                comentario.fecha = coment.fecha;
                lista.Add(comentario);
            }
            return lista;
        }

    }
}