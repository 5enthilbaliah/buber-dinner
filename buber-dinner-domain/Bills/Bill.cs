// <copyright file="Bill.cs" company="buber-dinner">
// Copyright (c) buber-dinner. All rights reserved.
// </copyright>

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace BuberDinner.Domain.Bills;

using Common;
using Common.ValueObjects;

using Dinners.ValueObjects;

using Guests.ValueObjects;

using Hosts.ValueObjects;

using ValueObjects;

public sealed class Bill : AggregateRoot<BillId, Guid>, ITrackable
{
#pragma warning disable CS8618
    private Bill()
    {
    }
#pragma warning restore CS8618

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

    public DinnerId DinnerId { get; private set; }

    public GuestId GuestId { get; private set; }

    public HostId HostId { get; private set; }

    public Price Price { get; private set; }

    public DateTime CreatedOn { get; private set; }

    public DateTime ModifiedOn { get; private set; }

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