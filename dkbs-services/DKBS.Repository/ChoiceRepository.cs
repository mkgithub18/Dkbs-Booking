using DKBS.Data;
using DKBS.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DKBS.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DKBS.Repository
{
    public interface IChoiceRepository
    {
        void Complete();
        List<BookingAlternativeServiceDTO> GetBookingAlternativeServices();
        List<BookingArrangementTypeDTO> GetBookingArrangementTypes();
        List<BookingDTO> GetBookings();
        List<BookingReferenceDTO> GetBookingReferences();
        List<BookingRegionDTO> GetBookingRegions();
        List<ContactPersonDTO> GetContactPeople();
        List<MailGroupDTO> GetMailGroups();
        List<ParticipantTypeDTO> GetParticipantTypes();
        List<ProcedureDTO> GetProcedures();
        List<ProcedureInfoDTO> GetProcedureInfos();
        List<ProcedureReviewTypeDTO> GetProcedureReviewTypes();
        List<ProvisionDTO> GetProvisions();
        List<BookingRoomDTO> GetBookingRooms();
        List<TownZipCodeDTO> GetTownZipCodes();
        List<TableSetDTO> GetTableSets();
        List<CoursePackageMenueDTO> GetAllCoursePackageMenue();
        List<PartnerCoursePackagePremiumServicesDTO> GetAllCoursePackagePremiumServices();
        List<CoursePackageYearPriceDTO> GetAllCoursePackageYearPrice();
        List<SCPartnerCoursePackageMappingDTO> GetAllSCPartnerCoursePackageMapping();
       
        List<ServiceCatalogueDTO> GetServiceCatalog();
        List<RegionDTO> GetRegions();
        List<PurposeDTO> GetPurposes();
        List<PartnerTypeDTO> GetPartnerTypes();
        List<TableTypeDTO> GetTableTypes();
        List<MailLanguageDTO> GetMailLanguages();
        List<LeadOfOriginDTO> GetLeadOfOrigins();
        List<LandDTO> GetLandDetails();
        List<ITProcedureStatusDTO> GetITProcedureStatuses();
        List<IndustryCodeDTO> GetIndustryCodes();
        List<FlowDTO> GetFlowDetails();
        List<CrmStatusDTO> GetCrmStatusDetails();
        List<CoursePackageTypeDTO> GetCoursePackageTypes();

        List<ContactPersonDTO> GetContactPersons();
        List<CampaignDTO> GetCampaigns();
        List<CenterTypeDTO> GetCenterTypes();
        List<CenterMatchingDTO> GetCenterMatchings();
        List<CauseOfRemovalDTO> GetCauseOfRemovals();
        List<CancellationReasonDTO> GetCancellationReasons();
        List<CustomerDTO> GetCustomers();
        List<CRMPartnerDTO> GetPartners();
        List<GetWebsitePartnerListDTO> GetWebsitePartners();
        List<PartnerCenterDescriptionDTO> GetPartnerCenterDescriptions();
        List<PartnerCoursePackageFreeServicesDTO> GetPartnerCoursePackageFreeServices();
        List<PartnerCoursePackagesDTO> GetPartnerCoursePackages();
        List<PartnerCoursePackageMenueDTO> GetPartnerCoursePackagesMenue();
        List<PartnerEmployeeDTO> GetPartnerEmployees();
        List<BookingAndStatusDTO> GetBookingAndStatuses();

        List<ServiceRequestCommunicationDTO> GetServiceRequestCommunications();
        List<ServiceRequestNoteDTO> GetServiceRequestNotes();
        List<SRConversationItemDTO> GetSRConversationItems();
        List<BookingDTO> GetAllBookings(int bookingId = -1);
        List<RefreshmentsDTO> GetRefreshments();
        List<PartnerCenterInfoDTO> GetPartnerCenterInfo();
        List<PartnerCenterRoomInfoDTO> GetPartnerCenterRoomInfo();

        List<PartnerInspirationCategoriesUKDTO> GetPartnerInspirationCategoriesUK();
        List<PartnerInspirationCategoriesDKDTO> GetPartnerInspirationCategoriesDK();

        List<ChatCommunicationDTO> GetChatCommunication();
        List<EmailConversationDTO> GetEmailConversation();
        List<SRInternalNotesDTO> GetSRInternalNotes();
        List<SRInternalNotifyDTO> GetSRInternalNotify();

        TEntity GetById<TEntity>(int id) where TEntity : class;

        TEntity GetById<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        List<TEntity> GetAll<TEntity>() where TEntity : class;

        void Attach<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Remove<TEntity>(TEntity entity) where TEntity : class;

        void SetBookings(Booking booking);
        void SetPartnerEmployees(PartnerEmployee partnerEmployee);
        void SetPartner(Partner newlyCreatedPartner);
        void SetCenterType(CenterType centerTypeMapped);
        void SetPartnerType(PartnerType partnerTypeMapped);
        void AttachIndustryCode(IndustryCode industryCode);
        void SetCreatedCustomer(Customer newlyCreatedCustomer);
        void SetTableType(TableType newlyCreatedtableType);
        void SetCancellationReason(CancellationReason newlyCreatedCancellationReason);
        void SetCauseOfRemoval(CauseOfRemoval newlyCreatedCancellationReason);
        void SetContactPerson(ContactPerson newlyCreatedContactPerson);
        void SetBookingAndStatus(BookingAndStatus newlyCreatedBookingAndStatus);
        void SetFlow(Flow newlyCreatedFlow);
        void SetMailLanguage(MailLanguage newlyCreatedmailLanguage);
        void SetParticipantType(ParticipantType newlyCreatedParticipantType);
        void SetPurpose(Purpose newlyCreatedPurpose);
        void SetCampaign(Campaign newlyCreatedCampaign);
        void SetLeadOfOrigin(LeadOfOrigin newlyCreatedLeadOfOrigin);
        void SetpartnerCenterRoomInfo(PartnerCenterRoomInfo partnerCenterRoomInfo);
        void SetpartnerInspirationCategoriesUK(PartnerInspirationCategoriesUK partnerInspirationCategoriesUK);
        void SetpartnerInspirationCategoriesDK(PartnerInspirationCategoriesDK partnerInspirationCategoriesDK);
        void SetProvision(Provision provision);

        void SetChatCommunication(ChatCommunication chatCommunication);
        void SetEmailConversation(EmailConversation emailConversation);
        void SetSRInternalNotes(SRInternalNotes sRInternalNotes);
        void SetSRInternalNotify(SRInternalNotify sRInternalNotify);


    }

    public class ChoiceRepository : IChoiceRepository
    {
        DKBSDbContext _dbContext;
        IMapper _mapper;
        public ChoiceRepository(DKBSDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }


        public List<RegionDTO> GetRegions()
        {
            return _mapper.Map<List<RegionDTO>>(_dbContext.Region.ToList());
        }

        public List<TableSetDTO> GetTableSets()
        {
            return _mapper.Map<List<TableSetDTO>>(_dbContext.TableSet.ToList());
        }

        public List<PurposeDTO> GetPurposes()
        {
            return _dbContext.Purpose.Select(p => new PurposeDTO { PurposeName = p.PurposeName, PurposeId = p.PurposeId }).ToList();
        }
        public List<PartnerCenterDescriptionDTO> GetPartnerCenterDescriptions()
        {
            return _mapper.Map<List<PartnerCenterDescriptionDTO>>(_dbContext.PartnerCenterDescription.ToList());
        }

        public List<PartnerTypeDTO> GetPartnerTypes()
        {
            return _dbContext.PartnerType.Select(p => new PartnerTypeDTO { PartnerTypeTitle = p.PartnerTypeTitle, PartnerTypeId = p.PartnerTypeId }).ToList();
        }

        public List<TableTypeDTO> GetTableTypes()
        {
            return _dbContext.TableType.Select(p => new TableTypeDTO { TableTypeName = p.TableTypeName, TableTypeId = p.TableTypeId }).ToList();
        }

        public List<MailLanguageDTO> GetMailLanguages()
        {
            return _dbContext.MailLanguage.Select(p => new MailLanguageDTO { Language = p.Language, MailLanguageId = p.MailLanguageId }).ToList();
        }

        public List<LeadOfOriginDTO> GetLeadOfOrigins()
        {
            return _dbContext.LeadOfOrigin.Select(p => new LeadOfOriginDTO { Name = p.Name, LeadOfOriginId = p.LeadOfOriginId }).ToList();
        }

        public List<LandDTO> GetLandDetails()
        {
            return _dbContext.Land.Select(p => new LandDTO { LandTitle = p.LandTitle, LandId = p.LandId }).ToList();
        }

        public List<ITProcedureStatusDTO> GetITProcedureStatuses()
        {
            return _dbContext.ITProcedureStatus.Select(p => new ITProcedureStatusDTO { ITProcedureStatusTitle = p.ITProcedureStatusTitle, ITProcedureStatusId = p.ITProcedureStatusId, InternalName = p.InternalName }).ToList();
        }

        public List<IndustryCodeDTO> GetIndustryCodes()
        {
            return _dbContext.IndustryCode.Select(p => new IndustryCodeDTO { IndustryCodeTitle = p.IndustryCodeTitle, IndustryCodeId = p.IndustryCodeId, IsNewBranch = p.IsNewBranch }).ToList();
        }

        public List<FlowDTO> GetFlowDetails()
        {
            return _dbContext.Flow.Select(p => new FlowDTO { FlowName = p.FlowName, FlowId = p.FlowId }).ToList();
        }

        public List<CrmStatusDTO> GetCrmStatusDetails()
        {
            return _dbContext.CrmStatus.Select(p => new CrmStatusDTO { CrmStatusTitle = p.CrmStatusTitle, CrmStatusId = p.CrmStatusId, LastModified = p.LastModified, LastModifiedBy = p.LastModifiedBy }).ToList();
        }

        public List<CoursePackageTypeDTO> GetCoursePackageTypes()
        {
            return _dbContext.CoursePackageType.Select(p => new CoursePackageTypeDTO { CoursePackageTypeTitle = p.CoursePackageTypeTitle, CoursePackageTypeId = p.CoursePackageTypeId, LastModified = p.LastModified, LastModifiedBy = p.LastModifiedBy }).ToList();
        }

        public List<ContactPersonDTO> GetContactPersons()
        {
            return _dbContext.ContactPerson.Select(p => new ContactPersonDTO { FirstName = p.FirstName, LastName = p.LastName, ContactPersonId = p.ContactPersonId, AccountId = p.AccountId, /*Department = p.Department,*/ Email = p.Email, MobilePhone = p.MobilePhone, Telephone = p.Telephone, ContactId = p.ContactId }).ToList();
        }

        public List<CampaignDTO> GetCampaigns()
        {
            return _dbContext.Campaign.Select(p => new CampaignDTO { Name = p.Name, CampaignId = p.CampaignId }).ToList();
        }

        public List<CenterTypeDTO> GetCenterTypes()
        {
            return _dbContext.CenterType.Select(p => new CenterTypeDTO { CenterTypeTitle = p.CenterTypeTitle, CenterTypeId = p.CenterTypeId, LastModified = p.LastModified, LastModifiedBy = p.LastModifiedBy }).ToList();
        }

        public List<CenterMatchingDTO> GetCenterMatchings()
        {
            return _dbContext.CenterMatching.Select(p => new CenterMatchingDTO { MatchingCenter = p.MatchingCenter, CenterMatchingId = p.CenterMatchingId }).ToList();
        }

        public List<CauseOfRemovalDTO> GetCauseOfRemovals()
        {
            return _dbContext.CauseOfRemoval.Select(p => new CauseOfRemovalDTO { CauseOfRemovalTitle = p.CauseOfRemovalTitle, CauseOfRemovalId = p.CauseOfRemovalId, LastModified = p.LastModified, LastModifiedBy = p.LastModifiedBy }).ToList();
        }

        public List<CancellationReasonDTO> GetCancellationReasons()
        {
            return _dbContext.CancellationReason.Select(p => new CancellationReasonDTO { CancellationReasonName = p.CancellationReasonName, CancellationReasonId = p.CancellationReasonId }).ToList();
        }

        public List<CustomerDTO> GetCustomers()
        {
            return _mapper.Map<List<CustomerDTO>>(_dbContext.Customer.ToList());
        }

        public List<CRMPartnerDTO> GetPartners()
        {
            return _mapper.Map<List<CRMPartnerDTO>>(_dbContext.CRMPartner.ToList());
        }

        public List<PartnerEmployeeDTO> GetPartnerEmployees()
        {
            return _mapper.Map<List<PartnerEmployeeDTO>>(_dbContext.PartnerEmployee.ToList());
        }

        public List<BookingAlternativeServiceDTO> GetBookingAlternativeServices()
        {
            return _mapper.Map<List<BookingAlternativeServiceDTO>>(_dbContext.BookingAlternativeService.ToList());
        }

        public List<BookingArrangementTypeDTO> GetBookingArrangementTypes()
        {
            return _mapper.Map<List<BookingArrangementTypeDTO>>(_dbContext.BookingArrangementType.ToList());
        }

        public List<RefreshmentsDTO> GetRefreshments()
        {
            return _mapper.Map<List<RefreshmentsDTO>>(_dbContext.Refreshment.ToList());
        }

        public List<PartnerCenterInfoDTO> GetPartnerCenterInfo()
        {
            return _mapper.Map<List<PartnerCenterInfoDTO>>(_dbContext.PartnerCenterInfo.ToList());
        }

        public List<PartnerCenterRoomInfoDTO> GetPartnerCenterRoomInfo()
        {
            return _mapper.Map<List<PartnerCenterRoomInfoDTO>>(_dbContext.PartnerCenterRoomInfo.ToList());
        }


        public List<PartnerInspirationCategoriesUKDTO> GetPartnerInspirationCategoriesUK()
        {
            return _mapper.Map<List<PartnerInspirationCategoriesUKDTO>>(_dbContext.PartnerInspirationCategoriesUK.ToList());
        }
        public List<PartnerInspirationCategoriesDKDTO> GetPartnerInspirationCategoriesDK()
        {
            return _mapper.Map<List<PartnerInspirationCategoriesDKDTO>>(_dbContext.PartnerInspirationCategoriesDK.ToList());
        }


        public List<ChatCommunicationDTO> GetChatCommunication()
        {
            return _mapper.Map<List<ChatCommunicationDTO>>(_dbContext.chatCommunication.ToList());
        }

        public List<EmailConversationDTO> GetEmailConversation()
        {
            return _mapper.Map<List<EmailConversationDTO>>(_dbContext.emailConversation.ToList());
        }

        public List<SRInternalNotesDTO> GetSRInternalNotes()
        {
            return _mapper.Map<List<SRInternalNotesDTO>>(_dbContext.sRInternalNotes.ToList());
        }

        public List<SRInternalNotifyDTO> GetSRInternalNotify()
        {
            return _mapper.Map<List<SRInternalNotifyDTO>>(_dbContext.sRInternalNotify.ToList());
        }



        public TEntity GetById<TEntity>(int id) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Attach(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }


        //public List<BookingDTO> GetAllBookingsDto()
        //{
        //    var booking = _dbContext.Booking;

        //    List<BookingDTO> bookingDtoList = new List<BookingDTO>();

        //    foreach (var item in booking)
        //    {
        //        BookingDTO bookingDto = new BookingDTO();

        //        var partner = _dbContext.Partner.Where(x => x.PartnerId == item.PartnerId).Include(x => x.CenterType).Include(x => x.PartnerType).FirstOrDefault();
        //        var centerType = _dbContext.CenterType.Where(x => x.CenterTypeId == partner.CenterType.CenterTypeId).FirstOrDefault();
        //        CenterTypeDTO centerTypeDto = _mapper.Map<CenterTypeDTO>(centerType);
        //        var partnerType = _dbContext.PartnerType.Where(x => x.PartnerTypeId == partner.PartnerType.PartnerTypeId).FirstOrDefault();
        //        PartnerTypeDTO partnerTypeDto = _mapper.Map<PartnerTypeDTO>(partnerType);

        //        var partnerDto = new PartnerDTO()
        //        {
        //            PartnerId = partner.PartnerId,
        //            CenterTypeDTO = centerTypeDto,
        //            PartnerTypeDTO = partnerTypeDto,
        //            EmailId = partner.EmailId,
        //            LastModified = partner.LastModified,
        //            LastModifiedBy = partner.LastModifiedBy,
        //            PartnerName = partner.PartnerName,
        //            PhoneNumber = partner.PhoneNumber
        //        };

        //        var customer = _dbContext.Customer.Where(x => x.CustomerId == item.CustomerId).Include(x => x.IndustryCode).FirstOrDefault();
        //        var industryCode = _dbContext.IndustryCode.Where(x => x.IndustryCodeId == customer.IndustryCode.IndustryCodeId).FirstOrDefault();
        //        IndustryCodeDTO industryCodeDto = _mapper.Map<IndustryCode, IndustryCodeDTO>(industryCode);
        //        var customerDto = new CustomerDTO()
        //        {
        //            City = customer.City,
        //            IndustryCodeDTO = industryCodeDto,
        //            CreatedBy = customer.CreatedBy,
        //            Country = customer.Country,
        //            CreatedDate = customer.CreatedDate,
        //            CustomerName = customer.CustomerName,
        //            EmailId = customer.EmailId,
        //            LastModifiedBY = customer.LastModifiedBY,
        //            LastModifiedDate = customer.LastModifiedDate,
        //            PhoneNumber = customer.PhoneNumber
        //        };

        //        var tableType = _unitOfWork.TableTypeRepository.Get(item.TableTypeId);
        //        TableTypeDTO tableTypeDTO = _mapper.Map<TableType, TableTypeDTO>(tableType);

        //        var cancellationReason = _unitOfWork.CancellationReasonRepository.Get(item.CancellationReasonId);
        //        CancellationReasonDTO cancellationReasonDTO = _mapper.Map<CancellationReason, CancellationReasonDTO>(cancellationReason);

        //        var causeOfRemoval = _unitOfWork.CauseOfRemovalRepository.Get(item.CauseOfRemovalId);
        //        CauseOfRemovalDTO causeOfRemovalDTO = _mapper.Map<CauseOfRemoval, CauseOfRemovalDTO>(causeOfRemoval);

        //        var contactPerson = _unitOfWork.ContactPersonRepository.Get(item.ContactPersonId);
        //        ContactPersonDTO contactPersonDTO = _mapper.Map<ContactPerson, ContactPersonDTO>(contactPerson);

        //        var bookingAndStatus = _unitOfWork.BookingAndStatusRepository.Get(item.BookingAndStatusId);
        //        BookingAndStatusDTO bookingAndStatusDTO = _mapper.Map<BookingAndStatus, BookingAndStatusDTO>(bookingAndStatus);

        //        var flow = _unitOfWork.FlowRepository.Get(item.FlowId);
        //        FlowDTO flowDTO = _mapper.Map<Flow, FlowDTO>(flow);

        //        var participantType = _unitOfWork.ParticipantTypeRepository.Get(item.ParticipantTypeId);
        //        ParticipantTypeDTO participantTypeDTO = _mapper.Map<ParticipantType, ParticipantTypeDTO>(participantType);

        //        var purpose = _unitOfWork.PurposeRepository.Get(item.PurposeId);
        //        PurposeDTO purposeDTO = _mapper.Map<Purpose, PurposeDTO>(purpose);

        //        var leadOfOrigin = _unitOfWork.LeadOfOriginRepository.Get(item.LeadOfOriginId);
        //        LeadOfOriginDTO leadOfOriginDTO = _mapper.Map<LeadOfOrigin, LeadOfOriginDTO>(leadOfOrigin);

        //        var campaign = _unitOfWork.CampaignRepository.Get(item.CampaignId);
        //        CampaignDTO campaignDTO = _mapper.Map<Campaign, CampaignDTO>(campaign);

        //        var mailLanguage = _unitOfWork.MailLanguageRepository.Get(item.MailLanguageId);
        //        MailLanguageDTO mailLanguageDTO = _mapper.Map<MailLanguageDTO>(mailLanguage);

        //        bookingDto.BookingId = item.BookingId;
        //        bookingDto.PartnerDTO = partnerDto;
        //        bookingDto.CustomerDTO = customerDto;
        //        bookingDto.TableTypeDTO = tableTypeDTO;
        //        bookingDto.CancellationReasonDTO = cancellationReasonDTO;
        //        bookingDto.CauseOfRemovalDTO = causeOfRemovalDTO;
        //        bookingDto.ContactPersonDTO = contactPersonDTO;
        //        bookingDto.BookingAndStatusDTO = bookingAndStatusDTO;
        //        bookingDto.FlowDTO = flowDTO;
        //        bookingDto.ParticipantTypeDTO = participantTypeDTO;
        //        bookingDto.PurposeDTO = purposeDTO;
        //        bookingDto.LeadOfOriginDTO = leadOfOriginDTO;
        //        bookingDto.CampaignDTO = campaignDTO;
        //        bookingDto.MailLanguageDTO = mailLanguageDTO;
        //        bookingDtoList.Add(bookingDto);

        //    }

        //    return bookingDtoList;
        //}


        public List<BookingDTO> GetAllBookings(int bookingId = -1)
        {

            var booking = bookingId != -1 ? _dbContext.Booking.Where(x => x.BookingId == bookingId).ToList() : _dbContext.Booking.ToList();
            List<BookingDTO> bookingDtoList = new List<BookingDTO>();

            foreach (var item in booking)
            {
                BookingDTO bookingDto = new BookingDTO();

                var partner = _dbContext.Partner.Where(x => x.PartnerId == item.PartnerId).Include(x => x.CenterType).Include(x => x.PartnerType).ToList().FirstOrDefault();
                var centerType = _dbContext.CenterType.Where(x => x.CenterTypeId == partner.CenterType.CenterTypeId).ToList().FirstOrDefault();
                CenterTypeDTO centerTypeDto = _mapper.Map<CenterTypeDTO>(centerType);
                var partnerType = _dbContext.PartnerType.Where(x => x.PartnerTypeId == partner.PartnerType.PartnerTypeId).FirstOrDefault();
                PartnerTypeDTO partnerTypeDto = _mapper.Map<PartnerTypeDTO>(partnerType);

                var partnerDto = new PartnerDTO()
                {
                    PartnerId = partner.PartnerId,
                    CenterTypeDTO = centerTypeDto,
                    PartnerTypeDTO = partnerTypeDto,
                    EmailId = partner.EmailId,
                    LastModified = partner.LastModified,
                    LastModifiedBy = partner.LastModifiedBy,
                    PartnerName = partner.PartnerName,
                    PhoneNumber = partner.PhoneNumber
                };

                var customer = _dbContext.Customer.Where(x => x.CustomerId == item.CustomerId).FirstOrDefault();//.Include(x => x.IndustryCode).FirstOrDefault();
                //var industryCode = _dbContext.IndustryCode.Where(x => x.IndustryCodeId == customer.IndustryCode.IndustryCodeId).FirstOrDefault();
                //IndustryCodeDTO industryCodeDto = _mapper.Map<IndustryCode, IndustryCodeDTO>(industryCode);

                var customerDto = _mapper.Map<Customer, CustomerDTO>(customer);

                var tableType = GetById<TableType>(item.TableTypeId);
                TableTypeDTO tableTypeDTO = _mapper.Map<TableType, TableTypeDTO>(tableType);

                var cancellationReason = GetById<CancellationReason>(item.CancellationReasonId);
                CancellationReasonDTO cancellationReasonDTO = _mapper.Map<CancellationReason, CancellationReasonDTO>(cancellationReason);

                var causeOfRemoval = GetById<CauseOfRemoval>(item.CauseOfRemovalId);
                CauseOfRemovalDTO causeOfRemovalDTO = _mapper.Map<CauseOfRemoval, CauseOfRemovalDTO>(causeOfRemoval);

                var contactPerson = GetById<ContactPerson>(item.ContactPersonId);
                ContactPersonDTO contactPersonDTO = _mapper.Map<ContactPerson, ContactPersonDTO>(contactPerson);

                var bookingAndStatus = GetById<BookingAndStatus>(item.BookingAndStatusId);
                BookingAndStatusDTO bookingAndStatusDTO = _mapper.Map<BookingAndStatus, BookingAndStatusDTO>(bookingAndStatus);

                var flow = GetById<Flow>(item.FlowId);
                FlowDTO flowDTO = _mapper.Map<Flow, FlowDTO>(flow);

                var participantType = GetById<ParticipantType>(item.ParticipantTypeId);
                ParticipantTypeDTO participantTypeDTO = _mapper.Map<ParticipantType, ParticipantTypeDTO>(participantType);

                var purpose = GetById<Purpose>(item.PurposeId);
                PurposeDTO purposeDTO = _mapper.Map<Purpose, PurposeDTO>(purpose);

                var leadOfOrigin = GetById<LeadOfOrigin>(item.LeadOfOriginId);
                LeadOfOriginDTO leadOfOriginDTO = _mapper.Map<LeadOfOrigin, LeadOfOriginDTO>(leadOfOrigin);

                var campaign = GetById<Campaign>(item.CampaignId);
                CampaignDTO campaignDTO = _mapper.Map<Campaign, CampaignDTO>(campaign);

                var mailLanguage = GetById<MailLanguage>(item.MailLanguageId);
                MailLanguageDTO mailLanguageDTO = _mapper.Map<MailLanguageDTO>(mailLanguage);

                var bookingRegions = _dbContext.BookingRegion.Where(x => x.BookingId == item.BookingId);
                foreach (var bookingRegion in bookingRegions)
                {
                    var region = GetById<Region>(bookingRegion.RegionId);
                    RegionDTO regionDTO = _mapper.Map<Region, RegionDTO>(region);
                    bookingDto.RegionDTO.Add(regionDTO);
                }

                //BookingRoomDTO
                var bookingRooms = _dbContext.BookingRoom.Where(x => x.BookingId == item.BookingId);
                foreach (var bookingRoom in bookingRooms)
                {
                    BookingRoomDTO bookingRoomDTO = _mapper.Map<BookingRoom, BookingRoomDTO>(bookingRoom);
                    bookingDto.BookingRoomDTO.Add(bookingRoomDTO);
                }

                //BookingArrangementTypeDTO
                var bookingArrangementTypes = _dbContext.BookingArrangementType.Where(x => x.BookingId == item.BookingId);
                foreach (var bookingArrangementType in bookingArrangementTypes)
                {
                    BookingArrangementTypeDTO bookingArrangementTypeDTO = _mapper.Map<BookingArrangementType, BookingArrangementTypeDTO>(bookingArrangementType);
                    bookingDto.BookingArrangementTypeDTO.Add(bookingArrangementTypeDTO);
                }

                //BookingAlternativeServiceDTO
                var bookingAlternativeServices = _dbContext.BookingAlternativeService.Where(x => x.BookingId == item.BookingId);
                foreach (var bookingAlternativeService in bookingAlternativeServices)
                {
                    BookingAlternativeServiceDTO bookingAlternativeServiceDTO = _mapper.Map<BookingAlternativeService, BookingAlternativeServiceDTO>(bookingAlternativeService);
                    bookingDto.BookingAlternativeServiceDTO.Add(bookingAlternativeServiceDTO);
                }

                var procedures = _dbContext.Procedure.Where(x => x.BookingId == item.BookingId).ToList();


                //TODO: Code has to refactor, wiil add as navigation property avoid to many mapping
                if (procedures != null)
                {
                    foreach (var procedure in procedures)
                    {
                        //ProcedureDTO
                        var customerInfo = GetById<Customer>(procedure.CustomerId);
                        var customerInfoDto = _mapper.Map<Customer, CustomerDTO>(customerInfo);
                        var CauseOfRemoval = GetById<CauseOfRemoval>(procedure.CauseOfRemovalId);
                        var CauseOfRemovalDto = _mapper.Map<CauseOfRemoval, CauseOfRemovalDTO>(CauseOfRemoval);
                        var ProcedureReviewType = GetById<ProcedureReviewType>(procedure.ProcedureReviewTypeId);
                        var ProcedureReviewTypeDto = _mapper.Map<ProcedureReviewType, ProcedureReviewTypeDTO>(ProcedureReviewType);
                        var procedureDto = _mapper.Map<Procedure, ProcedureDTO>(procedure);
                        procedureDto.CauseOfRemovalDTO = CauseOfRemovalDto;
                        procedureDto.ProcedureReviewTypeDTO = ProcedureReviewTypeDto;
                        procedureDto.CustomerDTO = customerInfoDto;
                        var procedureInfo = _dbContext.ProcedureInfo.Where(x => x.ProcedureId == procedure.ProcedureId).FirstOrDefault();

                        if (procedureInfo != null)
                        {
                            var partnerDtoInfo = _dbContext.Partner.Include(x => x.CenterType).FirstOrDefault();
                            //var centerTypeDtoInfo = _mapper.Map<CenterType, CenterTypeDTO>(partnerDtoInfo.CenterType);
                            var procedureInfoDto = new ProcedureInfoDTO()
                            {
                                //CenterTypeDTO = centerTypeDtoInfo,
                                Chat = procedureInfo.Chat,
                                Comment = procedureInfo.Comment,
                                EmailOffer = procedureInfo.EmailOffer,
                                PartnerDTO = partnerDto,
                                Price = procedureInfo.Price,
                                ProcedureInfoId = procedureInfo.ProcedureInfoId,
                                Reply = procedureInfo.Reply,
                                ProcedureDTO = procedureDto,
                            };

                            bookingDto.ProcedureInfoDTO.Add(procedureInfoDto);
                        }
                    }
                }


                bookingDto.BookingId = item.BookingId;
                bookingDto.PartnerDTO = partnerDto;
                bookingDto.CustomerDTO = customerDto;
                bookingDto.TableTypeDTO = tableTypeDTO;
                bookingDto.CancellationReasonDTO = cancellationReasonDTO;
                bookingDto.CauseOfRemovalDTO = causeOfRemovalDTO;
                bookingDto.ContactPersonDTO = contactPersonDTO;
                bookingDto.BookingAndStatusDTO = bookingAndStatusDTO;
                bookingDto.FlowDTO = flowDTO;
                bookingDto.ParticipantTypeDTO = participantTypeDTO;
                bookingDto.PurposeDTO = purposeDTO;
                bookingDto.LeadOfOriginDTO = leadOfOriginDTO;
                bookingDto.CampaignDTO = campaignDTO;
                bookingDto.MailLanguageDTO = mailLanguageDTO;
                bookingDto.ArrivalDateTime = item.ArrivalDateTime;

                //public DateTime DepartDateTime { get; set; }
                //public bool FlexibleDates { get; set; }
                //public string InternalHistory { get; set; }
                //public List<RegionDTO> RegionDTO { get; set; }
                //public List<BookingRoomDTO> BookingRoomDTO { get; set; }
                //public List<BookingArrangementTypeDTO> BookingArrangementTypeDTO { get; set; }
                //public List<BookingAlternativeServiceDTO> BookingAlternativeServiceDTO { get; set; }

                bookingDto.DepartDateTime = item.DepartDateTime;
                bookingDto.FlexibleDates = item.FlexibleDates;
                bookingDto.InternalHistory = item.InternalHistory;
                bookingDtoList.Add(bookingDto);

            }

            return bookingDtoList;
        }


        public List<BookingDTO> GetBookings()
        {

            var booking = _dbContext.Booking;

            List<BookingDTO> bookingDtoList = new List<BookingDTO>();

            foreach (var item in booking)
            {
                BookingDTO bookingDto = new BookingDTO();

                var partner = _dbContext.Partner.Where(x => x.PartnerId == item.PartnerId).Include(x => x.CenterType).Include(x => x.PartnerType).ToList().FirstOrDefault();
                var centerType = _dbContext.CenterType.Where(x => x.CenterTypeId == partner.CenterType.CenterTypeId).ToList().FirstOrDefault();
                CenterTypeDTO centerTypeDto = _mapper.Map<CenterTypeDTO>(centerType);
                var partnerType = _dbContext.PartnerType.Where(x => x.PartnerTypeId == partner.PartnerType.PartnerTypeId).FirstOrDefault();
                PartnerTypeDTO partnerTypeDto = _mapper.Map<PartnerTypeDTO>(partnerType);

                var partnerDto = new PartnerDTO()
                {
                    PartnerId = partner.PartnerId,
                    CenterTypeDTO = centerTypeDto,
                    PartnerTypeDTO = partnerTypeDto,
                    EmailId = partner.EmailId,
                    LastModified = partner.LastModified,
                    LastModifiedBy = partner.LastModifiedBy,
                    PartnerName = partner.PartnerName,
                    PhoneNumber = partner.PhoneNumber
                };

                var customer = _dbContext.Customer.Where(x => x.CustomerId == item.CustomerId).FirstOrDefault();//.Include(x => x.IndustryCode).FirstOrDefault();
                                                                                                                //var industryCode = _dbContext.IndustryCode.Where(x => x.IndustryCodeId == customer.IndustryCode.IndustryCodeId).FirstOrDefault();
                                                                                                                // IndustryCodeDTO industryCodeDto = _mapper.Map<IndustryCode, IndustryCodeDTO>(industryCode);

                var customerDto = _mapper.Map<Customer, CustomerDTO>(customer);

                var tableType = GetById<TableType>(item.TableTypeId);
                TableTypeDTO tableTypeDTO = _mapper.Map<TableType, TableTypeDTO>(tableType);

                var cancellationReason = GetById<CancellationReason>(item.CancellationReasonId);
                CancellationReasonDTO cancellationReasonDTO = _mapper.Map<CancellationReason, CancellationReasonDTO>(cancellationReason);

                var causeOfRemoval = GetById<CauseOfRemoval>(item.CauseOfRemovalId);
                CauseOfRemovalDTO causeOfRemovalDTO = _mapper.Map<CauseOfRemoval, CauseOfRemovalDTO>(causeOfRemoval);

                var contactPerson = GetById<ContactPerson>(item.ContactPersonId);
                ContactPersonDTO contactPersonDTO = _mapper.Map<ContactPerson, ContactPersonDTO>(contactPerson);

                var bookingAndStatus = GetById<BookingAndStatus>(item.BookingAndStatusId);
                BookingAndStatusDTO bookingAndStatusDTO = _mapper.Map<BookingAndStatus, BookingAndStatusDTO>(bookingAndStatus);

                var flow = GetById<Flow>(item.FlowId);
                FlowDTO flowDTO = _mapper.Map<Flow, FlowDTO>(flow);

                var participantType = GetById<ParticipantType>(item.ParticipantTypeId);
                ParticipantTypeDTO participantTypeDTO = _mapper.Map<ParticipantType, ParticipantTypeDTO>(participantType);

                var purpose = GetById<Purpose>(item.PurposeId);
                PurposeDTO purposeDTO = _mapper.Map<Purpose, PurposeDTO>(purpose);

                var leadOfOrigin = GetById<LeadOfOrigin>(item.LeadOfOriginId);
                LeadOfOriginDTO leadOfOriginDTO = _mapper.Map<LeadOfOrigin, LeadOfOriginDTO>(leadOfOrigin);

                var campaign = GetById<Campaign>(item.CampaignId);
                CampaignDTO campaignDTO = _mapper.Map<Campaign, CampaignDTO>(campaign);

                var mailLanguage = GetById<MailLanguage>(item.MailLanguageId);
                MailLanguageDTO mailLanguageDTO = _mapper.Map<MailLanguageDTO>(mailLanguage);

                bookingDto.BookingId = item.BookingId;
                bookingDto.PartnerDTO = partnerDto;
                bookingDto.CustomerDTO = customerDto;
                bookingDto.TableTypeDTO = tableTypeDTO;
                bookingDto.CancellationReasonDTO = cancellationReasonDTO;
                bookingDto.CauseOfRemovalDTO = causeOfRemovalDTO;
                bookingDto.ContactPersonDTO = contactPersonDTO;
                bookingDto.BookingAndStatusDTO = bookingAndStatusDTO;
                bookingDto.FlowDTO = flowDTO;
                bookingDto.ParticipantTypeDTO = participantTypeDTO;
                bookingDto.PurposeDTO = purposeDTO;
                bookingDto.LeadOfOriginDTO = leadOfOriginDTO;
                bookingDto.CampaignDTO = campaignDTO;
                bookingDto.MailLanguageDTO = mailLanguageDTO;
                bookingDtoList.Add(bookingDto);

            }

            return bookingDtoList;
        }

        public List<BookingReferenceDTO> GetBookingReferences()
        {
            return _mapper.Map<List<BookingReferenceDTO>>(_dbContext.BookingReference.ToList());
        }

        public List<BookingRegionDTO> GetBookingRegions()
        {
            return _mapper.Map<List<BookingRegionDTO>>(_dbContext.BookingRegion.ToList());
        }

        public List<ContactPersonDTO> GetContactPeople()
        {
            return _mapper.Map<List<ContactPersonDTO>>(_dbContext.ContactPerson.ToList());
        }

        public List<MailGroupDTO> GetMailGroups()
        {
            return _mapper.Map<List<MailGroupDTO>>(_dbContext.MailGroup.ToList());
        }

        public List<ParticipantTypeDTO> GetParticipantTypes()
        {
            return _mapper.Map<List<ParticipantTypeDTO>>(_dbContext.ParticipantType.ToList());
        }

        public List<ProcedureDTO> GetProcedures()
        {
            return _mapper.Map<List<ProcedureDTO>>(_dbContext.Procedure.ToList());
        }

        public List<ProcedureReviewTypeDTO> GetProcedureReviewTypes()
        {
            return _mapper.Map<List<ProcedureReviewTypeDTO>>(_dbContext.ProcedureReviewType.ToList());
        }

        public List<ProvisionDTO> GetProvisions()
        {
            return _mapper.Map<List<ProvisionDTO>>(_dbContext.Provision.ToList());
        }

        public List<BookingRoomDTO> GetBookingRooms()
        {
            return _mapper.Map<List<BookingRoomDTO>>(_dbContext.BookingRoom.ToList());
        }

        public List<TownZipCodeDTO> GetTownZipCodes()
        {
            return _mapper.Map<List<TownZipCodeDTO>>(_dbContext.TownZipCode.ToList());
        }

        public List<ProcedureInfoDTO> GetProcedureInfos()
        {
            return _mapper.Map<List<ProcedureInfoDTO>>(_dbContext.ProcedureInfo.ToList());
        }

        public List<BookingAndStatusDTO> GetBookingAndStatuses()
        {
            return _mapper.Map<List<BookingAndStatusDTO>>(_dbContext.BookingAndStatus.ToList());
        }

        public List<ServiceRequestCommunicationDTO> GetServiceRequestCommunications()
        {
            return _mapper.Map<List<ServiceRequestCommunicationDTO>>(_dbContext.ServiceRequestCommunication.ToList());
        }

        public List<ServiceRequestNoteDTO> GetServiceRequestNotes()
        {
            return _mapper.Map<List<ServiceRequestNoteDTO>>(_dbContext.ServiceRequestNote.ToList());
        }

        public List<SRConversationItemDTO> GetSRConversationItems()
        {
            return _mapper.Map<List<SRConversationItemDTO>>(_dbContext.SRConversationItem.ToList());
        }

        public void SetBookings(Booking booking)
        {
            _dbContext.Booking.Add(booking);
        }

        public void SetPartnerEmployees(PartnerEmployee partnerEmployee)
        {
            _dbContext.PartnerEmployee.Add(partnerEmployee);
        }
        public void SetPartner(Partner newlyCreatedPartner)
        {
            _dbContext.Partner.Add(newlyCreatedPartner);
        }

        public void SetCenterType(CenterType centerTypeMapped)
        {
            _dbContext.CenterType.Add(centerTypeMapped);
        }

        public void SetPartnerType(PartnerType partnerTypeMapped)
        {
            _dbContext.PartnerType.Add(partnerTypeMapped);
        }

        public void AttachIndustryCode(IndustryCode industryCode)
        {
            _dbContext.IndustryCode.Add(industryCode);
        }

        public void SetCreatedCustomer(Customer newlyCreatedCustomer)
        {
            _dbContext.Customer.Add(newlyCreatedCustomer);
        }

        public void SetTableType(TableType newlyCreatedtableType)
        {
            _dbContext.TableType.Add(newlyCreatedtableType);
        }

        public void SetCancellationReason(CancellationReason newlyCreatedCancellationReason)
        {
            _dbContext.CancellationReason.Add(newlyCreatedCancellationReason);
        }

        public void SetCauseOfRemoval(CauseOfRemoval newlyCreatedCauseOfRemoval)
        {
            _dbContext.CauseOfRemoval.Add(newlyCreatedCauseOfRemoval);
        }

        public void SetContactPerson(ContactPerson newlyCreatedContactPerson)
        {
            _dbContext.ContactPerson.Add(newlyCreatedContactPerson);
        }

        public void SetBookingAndStatus(BookingAndStatus newlyCreatedBookingAndStatus)
        {
            _dbContext.BookingAndStatus.Add(newlyCreatedBookingAndStatus);
        }

        public void SetFlow(Flow newlyCreatedFlow)
        {
            _dbContext.Flow.Add(newlyCreatedFlow);
        }

        public void SetMailLanguage(MailLanguage newlyCreatedmailLanguage)
        {
            _dbContext.MailLanguage.Add(newlyCreatedmailLanguage);
        }

        public void SetParticipantType(ParticipantType newlyCreatedParticipantType)
        {
            _dbContext.ParticipantType.Add(newlyCreatedParticipantType);
        }

        public void SetPurpose(Purpose newlyCreatedPurpose)
        {
            _dbContext.Purpose.Add(newlyCreatedPurpose);
        }

        public void SetCampaign(Campaign newlyCreatedCampaign)
        {
            _dbContext.Campaign.Add(newlyCreatedCampaign);
        }

        public void SetLeadOfOrigin(LeadOfOrigin newlyCreatedLeadOfOrigin)
        {
            _dbContext.LeadOfOrigin.Add(newlyCreatedLeadOfOrigin);
        }

        public void SetpartnerCenterRoomInfo(PartnerCenterRoomInfo partnerCenterRoomInfo)
        {
            _dbContext.PartnerCenterRoomInfo.Add(partnerCenterRoomInfo);
        }
        public void SetpartnerInspirationCategoriesUK(PartnerInspirationCategoriesUK partnerInspirationCategoriesUK)
        {
            _dbContext.PartnerInspirationCategoriesUK.Add(partnerInspirationCategoriesUK);
        }

        public void SetpartnerInspirationCategoriesDK(PartnerInspirationCategoriesDK partnerInspirationCategoriesDK)
        {
            _dbContext.PartnerInspirationCategoriesDK.Add(partnerInspirationCategoriesDK);
        }


        public void SetProvision(Provision provision)
        {
            _dbContext.provision.Add(provision);
        }

        public void SetChatCommunication(ChatCommunication chatCommunication)
        {
            _dbContext.chatCommunication.Add(chatCommunication);
        }

        public void SetEmailConversation(EmailConversation emailConversation)
        {
            _dbContext.emailConversation.Add(emailConversation);
        }

        public void SetSRInternalNotes(SRInternalNotes sRInternalNotes)
        {
            _dbContext.sRInternalNotes.Add(sRInternalNotes);
        }

        public void SetSRInternalNotify(SRInternalNotify sRInternalNotify)
        {
            _dbContext.sRInternalNotify.Add(sRInternalNotify);
        }


        List<TEntity> IChoiceRepository.GetAll<TEntity>()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        void IChoiceRepository.Remove<TEntity>(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        TEntity IChoiceRepository.GetById<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public List<CoursePackageMenueDTO> GetAllCoursePackageMenue()
        {
            return _mapper.Map<List<CoursePackageMenueDTO>>(_dbContext.CoursePackageMenue.ToList());
        }

        public List<CoursePackageYearPriceDTO> GetAllCoursePackageYearPrice()
        {
            return _mapper.Map<List<CoursePackageYearPriceDTO>>(_dbContext.PartnerCoursePackageYearPrice.ToList());
        }
        public List<SCPartnerCoursePackageMappingDTO> GetAllSCPartnerCoursePackageMapping()
        {
            return _mapper.Map<List<SCPartnerCoursePackageMappingDTO>>(_dbContext.SCPartnerCoursePackageMapping.ToList());
        }

        public List<ServiceCatalogueDTO> GetServiceCatalog()
        {
            var returnserviceCatalogueList = _mapper.Map<List<ServiceCatalogueDTO>>(_dbContext.ServiceCatalogue.ToList());
            foreach (var serviceCatalogue in returnserviceCatalogueList)
            {
                serviceCatalogue.CoursePackageMenueList = GetAllCoursePackageMenue().FindAll(x => x.ServiceCatalogueID == serviceCatalogue.ServiceCatalogueID);
            }
            return returnserviceCatalogueList;
        }

        public List<PartnerCoursePackagesDTO> GetPartnerCoursePackages()
        {
            var returnPartnerCoursePackages = _mapper.Map<List<PartnerCoursePackagesDTO>>(_dbContext.PartnerCoursePackages.ToList());
            foreach (var partnerCoursePackages in returnPartnerCoursePackages)
            {
                partnerCoursePackages.PartnerCoursePackageMenueList = GetPartnerCoursePackagesMenue().FindAll(x => x.PartnerID == partnerCoursePackages.PartnerID && x.ServiceCatalogueID == partnerCoursePackages.ServiceCatalogueID);
                partnerCoursePackages.PartnerCoursePackageFreeServicesList = GetPartnerCoursePackageFreeServices().FindAll(x => x.PartnerID == partnerCoursePackages.PartnerID && x.ServiceCatalogueID == partnerCoursePackages.ServiceCatalogueID);
                partnerCoursePackages.PartnerCoursePackagePremiumServicesList = GetAllCoursePackagePremiumServices().FindAll(x => x.PartnerID == partnerCoursePackages.PartnerID && x.ServiceCatalogueID == partnerCoursePackages.ServiceCatalogueID);
                partnerCoursePackages.PartnerCoursePackageYearPriceList = GetCoursePackageYearPrice().FindAll(x => x.PartnerID == partnerCoursePackages.PartnerID && x.ServiceCatalogueID == partnerCoursePackages.ServiceCatalogueID);
            }
            return returnPartnerCoursePackages;
        }

        public List<PartnerCoursePackagePremiumServicesDTO> GetAllCoursePackagePremiumServices()
        {
            return _mapper.Map<List<PartnerCoursePackagePremiumServicesDTO>>(_dbContext.PartnerCoursePackagePremiumServices.ToList());
        }

        public List<GetWebsitePartnerListDTO> GetWebsitePartners()
        {
            return _dbContext.CRMPartner.Select(p => new GetWebsitePartnerListDTO { CRMPartnerId = p.CRMPartnerId, CVR = p.CVR, Address1 = p.Address1, Address2 = p.Address2, PostNumber = p.PostNumber, Regions = p.Regions, Land = p.Land, Telefon = p.Telefon, Email = p.Email, PanoramView = p.PanoramView, PublicURL = p.PublicURL, Centertype = p.Centertype, RecommandedNPGRT60 = p.RecommandedNPGRT60, QualityAssuredNPSGRD30 = p.QualityAssuredNPSGRD30, Partnertype = p.Partnertype, LastModified = p.LastModified }).ToList();
        }

        public List<PartnerCoursePackageMenueDTO> GetPartnerCoursePackagesMenue()
        {
            return (from pcm in _dbContext.PartnerCoursePackageMenue
                    join cm in _dbContext.CoursePackageMenue
                    on pcm.CoursePackageMenueID equals cm.CoursePackageMenueID
                    select new PartnerCoursePackageMenueDTO
                    {
                        CoursePackageMenueID = pcm.CoursePackageMenueID,
                        PartnerID = pcm.PartnerID,
                        ServiceCatalogueID = pcm.ServiceCatalogueID,
                        PartnerCoursePackageMenueID = pcm.PartnerCoursePackageMenueID,
                        PartnerCoursePakageMenue_SPID = pcm.PartnerCoursePakageMenue_SPID,
                        CreatedDate = pcm.CreatedDate,
                        ModifiedDate = pcm.ModifiedDate,
                        createdBy = pcm.createdBy,
                        ModifiedBy = pcm.ModifiedBy,
                        Include = pcm.Include,
                        Description = cm.Description,
                        Order = cm.Order
                    }).ToList();
        }

        public List<PartnerCoursePackageFreeServicesDTO> GetPartnerCoursePackageFreeServices()
        {
            return _mapper.Map<List<PartnerCoursePackageFreeServicesDTO>>(_dbContext.PartnerCoursePackageFreeServices.ToList());
        }

        public List<PartnerCoursePackageYearPriceDTO> GetCoursePackageYearPrice()
        {
            return _mapper.Map<List<PartnerCoursePackageYearPriceDTO>>(_dbContext.PartnerCoursePackageYearPrice.ToList());
        }
    }
}
