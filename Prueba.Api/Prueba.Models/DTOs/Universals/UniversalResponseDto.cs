using System.Net;

namespace Prueba.Models.DTOs.Universals
{
    //Dto para respuestas universales
    public class UniversalResponseDto<T>
    {
        public T? Response { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
