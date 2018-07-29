namespace ClientLight.Model
{
    using ClientLight.Interfaces;

    using GalaSoft.MvvmLight;

    public class TicketDto : ViewModelBase, IEntity<int>
    {
        public int Id { get; set; } = 0;

        private float _price = 0;
        public float Price
        {
            get => _price;
            set => Set(ref _price, value);
        }


        public FlightDto Flight { get; set; } = new FlightDto();
    }
}
