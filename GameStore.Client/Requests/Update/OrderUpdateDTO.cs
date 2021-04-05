using GameStore.Client.Requests.Create;

namespace GameStore.Client.Requests.Update
{
    public class OrderUpdateDTO : OrderCreateDTO
    {
        public int Id { get; set; }
    }
}