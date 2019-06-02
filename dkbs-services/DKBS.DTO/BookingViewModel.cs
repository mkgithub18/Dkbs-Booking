using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DKBS.DTO
{
    public class BookingViewModel
    {
        public BookingViewModel()
        {
            RegionIds = new List<int>();
            BookingRoomViewModel = new List<BookingRoomViewModel>();
            BookingArrangementTypeViewModel = new List<BookingArrangementTypeViewModel>();
            BookingAlternativeServiceViewModel = new List<BookingAlternativeServiceViewModel>();
        }

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
        public int NumberOfRooms { get; set; }
        public string OtherCompaignName { get; set; }
        public int NumberOfPerticipants { get; set; }
        public List<int> RegionIds { get; set; }
        public List<BookingRoomViewModel> BookingRoomViewModel { get; set; }
        public List<BookingArrangementTypeViewModel> BookingArrangementTypeViewModel { get; set; }
        public List<BookingAlternativeServiceViewModel> BookingAlternativeServiceViewModel { get; set; }
        public List<PartnerDTO> Partners { get; set; }
    }
}
