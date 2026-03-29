namespace WebAPI.DTOs.ReservationDTO
{
    public class GetByIdReservationDTO
    {
        public int ReservationId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int CountPeople { get; set; }
        public string Message { get; set; }
        public bool ReservationStatus { get; set; }
    }
}
