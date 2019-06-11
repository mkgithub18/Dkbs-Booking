using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SharePoint.Client;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// This controller contains all master data.
    /// </summary>
    [Route("choice")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoiceRepository _choiceRepoistory;

        /// <summary>
        /// Will take IChoiceRepository as paramE:\DKBS-Booking-System\dkbs-services\DKBS.API\Controllers\ChoiceController.cs
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        public ChoiceController(IChoiceRepository choiceRepoistory)
        {
            _choiceRepoistory = choiceRepoistory;
        }

        /// <summary>
        /// Get All regions details.
        /// </summary>
        /// <returns>List of regions.</returns>
        [Route("regions")]
        [HttpGet()]
        public ActionResult<RegionDTO> GetRegions()
        {
            return Ok(_choiceRepoistory.GetRegions());

        }

        /// <summary>
        /// Get All tableset details.
        /// </summary>
        /// <returns>List of tablesets.</returns>
        [Route("tableSets")]
        [HttpGet()]
        public ActionResult<TableSetDTO> GetTableSets()
        {
            return Ok(_choiceRepoistory.GetTableSets());
        }

        /// <summary>
        /// Get All purposes details.
        /// </summary>
        /// <returns>List of purposes.</returns>
        [Route("purposes")]
        [HttpGet()]
        public ActionResult<PurposeDTO> GetPurposes()
        {
            return Ok(_choiceRepoistory.GetPurposes());
        }

        /// <summary>
        /// Get All Tabletypes details.
        /// </summary>
        /// <returns>List of tabletypes.</returns>
        [Route("tabletypes")]
        [HttpGet()]
        public ActionResult<TableTypeDTO> GetTableTypes()
        {
            return Ok(_choiceRepoistory.GetTableTypes());
        }

        /// <summary>
        /// Get All PartnerTypes details.
        /// </summary>
        /// <returns>List of Partnertypes.</returns>
        [Route("partnertypes")]
        [HttpGet()]
        public ActionResult<PartnerTypeDTO> GetPartnerTypes()
        {
            return Ok(_choiceRepoistory.GetPartnerTypes());
        }

        /// <summary>
        /// Get All mailLanguages details.
        /// </summary>
        /// <returns>List of maillanguages.</returns>
        [Route("maillanguages")]
        [HttpGet()]
        public ActionResult<MailLanguageDTO> GetMailLanguages()
        {
            return Ok(_choiceRepoistory.GetMailLanguages());
        }

        /// <summary>
        /// Get All LeadOfOrgins details.
        /// </summary>
        /// <returns>List of LeadOfOrgins.</returns>
        [Route("leadoforigins")]
        [HttpGet()]
        public ActionResult<LeadOfOriginDTO> GetLeadOfOrigins()
        {
            return Ok(_choiceRepoistory.GetLeadOfOrigins());
        }

        /// <summary>
        /// Get All Land details.
        /// </summary>
        /// <returns>List of Lands.</returns>
        [Route("lands")]
        [HttpGet()]
        public ActionResult<LandDTO> GetLandDetails()
        {
            return Ok(_choiceRepoistory.GetLandDetails());
        }

        /// <summary>
        /// Get All ITProcedureStatus details.
        /// </summary>
        /// <returns>List of ITProcedureStatuses.</returns>
        [Route("itprocedurestatus")]
        [HttpGet()]
        public ActionResult<ITProcedureStatusDTO> GetITProcedureStatusDetails()
        {
            return Ok(_choiceRepoistory.GetITProcedureStatuses());
        }

        /// <summary>
        /// Get All IndustryCodes details.
        /// </summary>
        /// <returns>List of IndustryCodes.</returns>
        [Route("industrycodes")]
        [HttpGet()]
        public ActionResult<IndustryCodeDTO> GetIndustryCodes()
        {
            return Ok(_choiceRepoistory.GetIndustryCodes());
        }

        /// <summary>
        /// Get All Flow details.
        /// </summary>
        /// <returns>List of Flows.</returns>
        [Route("flow")]
        [HttpGet()]
        public ActionResult<FlowDTO> GetFlowDetails()
        {
            return Ok(_choiceRepoistory.GetFlowDetails());
        }

        /// <summary>
        /// Get All CrmStatus details.
        /// </summary>
        /// <returns>List of CrmStatuses.</returns>
        [Route("crmstatus")]
        [HttpGet()]
        public ActionResult<CrmStatusDTO> GetCrmStatusDetails()
        {
            return Ok(_choiceRepoistory.GetCrmStatusDetails());
        }

        ///// <summary>
        ///// Get All CoursePackageType details.
        ///// </summary>
        ///// <returns>List of CoursePackageTypes.</returns>
        //[Route("coursepackagetype")]
        //[HttpGet()]
        //public ActionResult<CoursePackageTypeDTO> GetCoursePackageTypes()
        //{
        //    return Ok(_choiceRepoistory.GetCoursePackageTypes());
        //}

        /// <summary>
        /// Get All ContactPersons details.
        /// </summary>
        /// <returns>List of ContactPersons.</returns>
        [Route("contactpersons")]
        [HttpGet()]
        public ActionResult<ContactPersonDTO> GetContactPersons()
        {
            return Ok(_choiceRepoistory.GetContactPersons());
        }

        /// <summary>
        /// Get All Campaign details.
        /// </summary>
        /// <returns>List of Campaigns.</returns>
        [Route("campaigns")]
        [HttpGet()]
        public ActionResult<CampaignDTO> GetCampaigns()
        {
            return Ok(_choiceRepoistory.GetCampaigns());
        }

        /// <summary>
        /// Get All CenterType details.
        /// </summary>
        /// <returns>List of CenterTypes.</returns>
        [Route("centertypes")]
        [HttpGet()]
        public ActionResult<CenterTypeDTO> GetCenterTypes()
        {
            return Ok(_choiceRepoistory.GetCenterTypes());
        }

        /// <summary>
        /// Get All CenterMatching details.
        /// </summary>
        /// <returns>List of CenterMatchings.</returns>
        [Route("centermatchings")]
        [HttpGet()]
        public ActionResult<CenterMatchingDTO> GetCenterMatchings()
        {
            return Ok(_choiceRepoistory.GetCenterMatchings());
        }

        /// <summary>
        /// Get All CauseOfRemoval details.
        /// </summary>
        /// <returns>List of CauseOfRemovals.</returns>
        [Route("causeofremovals")]
        [HttpGet()]
        public ActionResult<CauseOfRemovalDTO> GetCauseOfRemovals()
        {
            return Ok(_choiceRepoistory.GetCauseOfRemovals());
        }

        /// <summary>
        /// Get All CancellationReason details.
        /// </summary>
        /// <returns>List of CancellationReasons.</returns>
        [Route("cancellationreasons")]
        [HttpGet()]
        public ActionResult<CancellationReasonDTO> GetCancellationReasons()
        {
            return Ok(_choiceRepoistory.GetCancellationReasons());
        }

        /// <summary>
        /// Get All partnerEmployees details.
        /// </summary>
        /// <returns>List of partnerEmployees.</returns>
        [Route("partnerEmployees")]
        [HttpGet()]
        public ActionResult<PartnerEmployeeDTO> GetPartnerEmployes()
        {
            return Ok(_choiceRepoistory.GetPartnerEmployees());
        }


        /// <summary>
        /// Get All partner details.
        /// </summary>
        /// <returns>List of partners.</returns>
        [Route("partners")]
        [HttpGet()]
        public ActionResult<CRMPartnerDTO> GetPartners()
        {
            return Ok(_choiceRepoistory.GetPartners());
        }


        /// <summary>
        /// Get All AlternativeService
        /// </summary>
        /// <returns></returns>
        [Route("BookingAlternativeServices")]
        [HttpGet()]
        public ActionResult<BookingAlternativeServiceDTO> GetBookingAlternativeServices()
        {
            return Ok(_choiceRepoistory.GetBookingAlternativeServices());
        }

        /// <summary>
        /// Get All AlternativeTypes
        /// </summary>
        /// <returns></returns>
        [Route("BookingArrangementTypes")]
        [HttpGet()]
        public ActionResult<BookingArrangementTypeDTO> GetBookingArrangementTypes()
        {
            return Ok(_choiceRepoistory.GetBookingArrangementTypes());
        }

        /// <summary>
        /// Get All Bookings
        /// </summary>
        /// <returns></returns>
        [Route("bookings")]
        [HttpGet()]
        public ActionResult<BookingDTO> GetBookings()
        {
            return Ok(_choiceRepoistory.GetAllBookings());
        }

        /// <summary>
        /// Get All BookingReferences
        /// </summary>
        /// <returns></returns>
        [Route("bookingReference")]
        [HttpGet()]
        public ActionResult<BookingReferenceDTO> GetBookingReferences()
        {
            return Ok(_choiceRepoistory.GetBookingReferences());
        }


        /// <summary>
        /// Get All BookingRegions
        /// </summary>
        /// <returns></returns>
        [Route("bookingRegions")]
        [HttpGet()]
        public ActionResult<BookingRegionDTO> GetBookingRegions()
        {
            return Ok(_choiceRepoistory.GetBookingRegions());
        }

        ///// <summary>
        ///// Get All ContactPeople
        ///// </summary>
        ///// <returns></returns>
        //[Route("contactPeople")]
        //[HttpGet()]
        //public ActionResult<ContactPersonDTO> GetContactPeople()
        //{
        //    return Ok(_choiceRepoistory.GetContactPeople());
        //}

        /// <summary>
        /// Get All MailGroups
        /// </summary>
        /// <returns></returns>
        [Route("mailGroups")]
        [HttpGet()]
        public ActionResult<MailGroupDTO> GetMailGroups()
        {
            return Ok(_choiceRepoistory.GetMailGroups());
        }

        /// <summary>
        /// Get All ParticipantTypes
        /// </summary>
        /// <returns></returns>
        [Route("participantTypes")]
        [HttpGet()]
        public ActionResult<ParticipantTypeDTO> GetParticipantTypes()
        {
            return Ok(_choiceRepoistory.GetParticipantTypes());
        }

        /// <summary>
        /// Get All Procedures
        /// </summary>
        /// <returns></returns>
        [Route("procedures")]
        [HttpGet()]
        public ActionResult<ProcedureDTO> GetProcedures()
        {
            return Ok(_choiceRepoistory.GetProcedures());
        }

        /// <summary>
        /// Get All ProcedureReviewTypes
        /// </summary>
        /// <returns></returns>
        [Route("procedureReviewTypes")]
        [HttpGet()]
        public ActionResult<ProcedureReviewTypeDTO> GetProcedureReviewTypes()
        {
            return Ok(_choiceRepoistory.GetProcedureReviewTypes());
        }


        /// <summary>
        /// Get All Provisions
        /// </summary>
        /// <returns></returns>
        [Route("provisions")]
        [HttpGet()]
        public ActionResult<ProvisionDTO> GetProvisions()
        {
            return Ok(_choiceRepoistory.GetProvisions());
        }

        /// <summary>
        /// Get All Rooms
        /// </summary>
        /// <returns></returns>
        [Route("BookingRooms")]
        [HttpGet()]
        public ActionResult<BookingRoomDTO> GetBookingRooms()
        {
            return Ok(_choiceRepoistory.GetBookingRooms());
        }

        /// <summary>
        /// Get All TownZipCodes
        /// </summary>
        /// <returns></returns>
        [Route("townZipCodes")]
        [HttpGet()]
        public ActionResult<TownZipCodeDTO> GetTownZipCodes()
        {
            return Ok(_choiceRepoistory.GetTownZipCodes());
        }

        /// <summary>
        /// Get All BookingAndStatuses
        /// </summary>
        /// <returns></returns>
        [Route("BookingAndStatuses")]
        [HttpGet()]
        public ActionResult<BookingAndStatusDTO> GetBookingAndStatuses()
        {
            return Ok(_choiceRepoistory.GetBookingAndStatuses());
        }

        /// <summary>
        /// Get All ServiceCatalogs
        /// </summary>
        /// <returns></returns>
        [Route("ServiceCatalogs")]
        [HttpGet()]
        public ActionResult<ServiceCatalogueDTO> GetServiceCatalogs()
        {
            return Ok(_choiceRepoistory.GetServiceCatalog());
        }

        /// <summary>
        /// Get All ServiceRequestCommunications
        /// </summary>
        /// <returns></returns>
        [Route("ServiceRequestCommunications")]
        [HttpGet()]
        public ActionResult<ServiceRequestCommunicationDTO> GetServiceRequestCommunications()
        {
            return Ok(_choiceRepoistory.GetServiceRequestCommunications());
        }

        /// <summary>
        /// Get All ServiceRequestNotes
        /// </summary>
        /// <returns></returns>
        [Route("ServiceRequestNotes")]
        [HttpGet()]
        public ActionResult<ServiceRequestNoteDTO> GetServiceRequestNotes()
        {
            return Ok(_choiceRepoistory.GetServiceRequestNotes());
        }

        /// <summary>
        /// Get All SRConversationItems
        /// </summary>
        /// <returns></returns>
        [Route("SRConversationItems")]
        [HttpGet()]
        public ActionResult<SRConversationItemDTO> GetSRConversationItems()
        {
            return Ok(_choiceRepoistory.GetSRConversationItems());
        }

        /// <summary>
        /// Get All Refreshments
        /// </summary>
        /// <returns></returns>
        [Route("Refreshments")]
        [HttpGet()]
        public ActionResult<RefreshmentsDTO> GetRefreshments()
        {
            return Ok(_choiceRepoistory.GetRefreshments());
        }

    }
}