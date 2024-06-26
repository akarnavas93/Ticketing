﻿using Shared.Constants.Enum;
using Shared.Abstractions.Messaging;

namespace Ticketing.Application.Shipments.Commands.CreateShipment;

public sealed record CreateShipmentCommand(
    string TrackingNumber,
    ShipmentTrackingStatus Status,
    ShipmentCarrier Carrier,
    DateTimeOffset? ShippedAt,
    DateTimeOffset? ArrivedAt) : ICommand<Guid>;
