﻿using System;
using System.Collections.Generic;

namespace WIL_Project.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string? TicketSubject { get; set; }

    public string? TicketBody { get; set; }

    public DateTime? TicketCreationDate { get; set; }

    public string? TicketStatus { get; set; }

    public int? TicketAttachmentsId { get; set; }

    public string? UserId { get; set; }

    public byte[]? TicketAttatchment1 { get; set; }

    public byte[]? TicketAttatchment2 { get; set; }

    public byte[]? TicketAttatchment3 { get; set; }

    public string? UserTicket { get; set; }

    public virtual TicketAttachment? TicketAttachments { get; set; }

    public virtual ICollection<TicketResponse> TicketResponses { get; set; } = new List<TicketResponse>();

    public virtual User? User { get; set; }
}
