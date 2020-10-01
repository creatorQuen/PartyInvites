using System.Collections.Generic;

namespace PartyInvites.Models
{
    // Класс Repository и его члены объявлены статическими, чтобы облегчить со­хранение 
    // и извлечение данных в разных местах приложения. НО напрактике делают внедрение зависимостей.
    public static class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses { get { return responses; } }

        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}
