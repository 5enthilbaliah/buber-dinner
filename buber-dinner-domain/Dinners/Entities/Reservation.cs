namespace BuberDinner.Domain.Dinners.Entities;

using Bills.ValueObjects;

using Common;

using Enums;

using Guests.ValueObjects;

using ValueObjects;

public class Reservation : Entity<ReservationId>, ITrackable
{
    private Reservation(
        ReservationId id,
        int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static Reservation SpawnOne(
        int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new Reservation(
            ReservationId.SpawnUniqueOne(),
            guestCount,
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime,
            createdOn,
            modifiedOn);
    }
}