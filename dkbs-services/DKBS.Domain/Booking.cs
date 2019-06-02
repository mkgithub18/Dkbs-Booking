using System;

namespace DKBS.Domain
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int PartnerId { get; set; }
        public int CustomerId { get; set; }
        public int TableTypeId { get; set; }
        public int CancellationReasonId { get; set; }
        public int CauseOfRemovalId { get; set; }
        public int ContactPersonId { get; set; }
        public int BookingAndStatusId { get; set; }
        public int FlowId { get; set; }
        public int MailLanguageId { get; set; }
        public int PartnerTypeId { get; set; }
        public int ParticipantTypeId { get; set; }
        public int PurposeId { get; set; }
        public int LeadOfOriginId { get; set; }
        public int CampaignId { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartDateTime { get; set; }
        public bool FlexibleDates { get; set; }
        public string InternalHistory { get; set; }
    }
}