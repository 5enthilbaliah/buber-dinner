// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace BuberDinner.Domain.Dinners.Entities;

using Bills.ValueObjects;

using Common;

using Enums;

using Guests.ValueObjects;

using ValueObjects;

public class Reservation : Entity<ReservationId>, ITrackable
{
#pragma warning disable CS8618
    private Reservation()
    {
    }
#pragma warning restore CS8618
    
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
        ArrivalOn = arrivalDateTime;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public int GuestCount { get; private set; }
    public ReservationStatus ReservationStatus { get; private set; }
    public GuestId GuestId { get; private set; }
    public BillId BillId { get; private set; }
    public DateTime? ArrivalOn { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime ModifiedOn { get; private set; }

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