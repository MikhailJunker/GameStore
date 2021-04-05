using GameStore.Client.Requests.Create;

namespace GameStore.Client.Requests.Update
{
    public class GameUpdateDTO : GameCreateDTO
    {
        public int Id { get; set; }
    }
}