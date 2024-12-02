namespace WebPOS.DTO
{
    public class BranchDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string? ArabicTitle { get; set; }
        public byte HasSeats { get; set; } = 0;
        public int ReservationCapacity { get; set; } = 0;
        public byte? SmsRecieveStatus { get; set; } = 0;
        public byte? DispatcherAcceptRequired { get; set; } = 1;
        public List<string>? BranchSettings {  get; set; }
    }
}
