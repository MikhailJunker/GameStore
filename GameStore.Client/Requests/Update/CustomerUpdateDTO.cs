using GameStore.Client.Requests.Create;

namespace GameStore.Client.Requests.Update
{
    public class CustomerUpdateDTO : CustomerCreateDTO
    {
        public int Id { get; set; }
    }
}