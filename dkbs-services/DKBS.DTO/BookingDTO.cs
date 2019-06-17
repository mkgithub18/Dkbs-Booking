using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DKBS.DTO
{
    public class BookingDTO
    {
        
        public BookingDTO()
        {
            RegionDTO = new List<RegionDTO>();
            BookingRoomDTO = new List<BookingRoomDTO>();
            BookingArrangementTypeDTO = new List<BookingArrangementTypeDTO>();
            BookingAlternativeServiceDTO = new List<BookingAlternativeServiceDTO>();
            ProcedureInfoDTO = new List<ProcedureInfoDTO>();
        }
        [Key]
        public int BookingId { get; set; }
        public PartnerDTO PartnerDTO { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public TableTypeDTO TableTypeDTO { get; set; }
        public CancellationReasonDTO CancellationReasonDTO { get; set; }
        public CauseOfRemovalDTO CauseOfRemovalDTO { get; set; }
        public ContactPersonDTO ContactPersonDTO { get; set; }
        public BookingAndStatusDTO BookingAndStatusDTO { get; set; }
        public FlowDTO FlowDTO { get; set; }
        public MailLanguageDTO MailLanguageDTO { get; set; }
        //public PartnerTypeDTO PartnerTypeDTO { get; set; }
        public ParticipantTypeDTO ParticipantTypeDTO { get; set; }
        public PurposeDTO PurposeDTO { get; set; }
        public LeadOfOriginDTO LeadOfOriginDTO { get; set; }
        public CampaignDTO CampaignDTO { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartDateTime { get; set; }
        public bool FlexibleDates { get; set; }
        public string InternalHistory { get; set; }
        public List<RegionDTO> RegionDTO { get; set; }
        public List<BookingRoomDTO> BookingRoomDTO { get; set; }
        public List<BookingArrangementTypeDTO> BookingArrangementTypeDTO { get; set; }
        public List<BookingAlternativeServiceDTO> BookingAlternativeServiceDTO { get; set; }
        public List<ProcedureInfoDTO> ProcedureInfoDTO { get; set; }
    }
}