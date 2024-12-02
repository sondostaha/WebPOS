namespace WebPOS.Models
{
    public class Branches
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string? ArabicTitle {get; set; }
        public byte HasSeats { get; set; }
        //public int ReservationCapacity {  get; set; }
        //public byte? SmsRecieveStatus { get; set; }
        public byte? DispatcherAcceptRequired { get; set; } = 1;
        public List<string>? BranchSettings { get; set; }
    }
}
