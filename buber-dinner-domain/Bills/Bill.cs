// <copyright file="Bill.cs" company="buber-dinner">
// Copyright (c) buber-dinner. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Bills;

using Common;
using Common.ValueObjects;

using Dinners.ValueObjects;

using Guests.ValueObjects;

using Hosts.ValueObjects;

using ValueObjects;

public sealed class Bill : AggregateRoot<BillId>, ITrackable
{
    private Bill(
        BillId id,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public DinnerId DinnerId { get; }

    public GuestId GuestId { get; }

    public HostId HostId { get; }

    public Price Price { get; }

    public DateTime CreatedOn { get; }

    public DateTime ModifiedOn { get; }

    public static Bill SpawnOne(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new Bill(
            BillId.SpawnUniqueOne(),
            dinnerId,
            guestId,
            hostId,
            price,
            createdOn,
            modifiedOn);
    }
}