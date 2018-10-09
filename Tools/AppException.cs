using System;
using System.Security.Permissions;

namespace Tools
{
    [Serializable()]
    public class AppException : Exception
    {
        /// <summary>
        /// Obtiene o establece el id del ITSExceptionIds lanzado
        /// </summary>
        public AppExceptionIds Id { get; set; }

        /// <summary>
        /// Obtiene o establece el arreglo de datos adicionales que se pueden agregar al detalle de la excepción
        /// </summary>
        public object[] Datos { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public AppException() { }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">Tipo de excepción</param>
        /// <param name="message">Mensaje informativo de la excepción</param>
        /// <param name="datos">Datos adicionales de la excepción</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
        public AppException(AppExceptionIds id, string message, object[] datos) : this(id, message, datos, null) { }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">Tipo de excepción</param>
        /// <param name="message">Mensaje informativo de la excepción</param>
        /// <param name="datos">Datos adicionales de la excepción</param>
        /// <param name="inner">Excepción base generada</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public AppException(AppExceptionIds id, string message, object[] datos, Exception inner)
            : base(message, inner)
        {
            Id = id;
            Datos = datos;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="info">SerializationInfo</param>
        /// <param name="context">StreamingContext</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
        protected AppException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
