namespace API.Endpoints
{
    public class TicketEndpoints
    {
        public const string Area = "";
        public const string Base = Area + "/ticket";
        public const string GetAll = Base;
        public const string GetSingle = Base + "/{id}";
        public const string CreateTicket = Base + "/create-ticket";
        public const string UpdateTicketInfo = Base + "/update-ticket-info";
        public const string DeleteTicket = Base + "/delete-ticket/{id}";
    }
}
