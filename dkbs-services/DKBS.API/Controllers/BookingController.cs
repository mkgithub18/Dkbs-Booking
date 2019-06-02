using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Booking
    /// </summary>
    [Route("BookingController")]
    public class BookingController : Controller
    {
        private IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>
        public BookingController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Bookings
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<BookingDTO> GetBookings()
        {
            return Ok(_choiceRepoistory.GetAllBookings());
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingReferenceDTO> GetBookingReference(int bookingId)
        {
            var temp = _choiceRepoistory.GetBookingReferences().FirstOrDefault(c => c.BookingDTO.BookingId == bookingId);
            return temp;
        }


        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingAlternativeServiceDTO> GetBookingAlternativeService(int bookingId)
        {
            return _choiceRepoistory.GetBookingAlternativeServices().FirstOrDefault(c => c.BookingId == bookingId);
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingAndStatusId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingAndStatusId}")]
        public ActionResult<BookingAndStatusDTO> GetBookingAndStatusById(int bookingAndStatusId)
        {
            return _choiceRepoistory.GetBookingAndStatuses().FirstOrDefault(c => c.BookingAndStatusId == bookingAndStatusId);
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingArrangementTypeDTO> GetBookingArrangementType(int bookingId)
        {
            return _choiceRepoistory.GetBookingArrangementTypes().FirstOrDefault(c => c.BookingId == bookingId);
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingRegionDTO> GetBookingRegion(int bookingId)
        {
            return _choiceRepoistory.GetBookingRegions().FirstOrDefault(c => c.BookingDTO.BookingId == bookingId);
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingRoomDTO> GetBookingRooms(int bookingId)
        {
            return _choiceRepoistory.GetBookingRooms().FirstOrDefault(c => c.BookingId == bookingId);
        }

        /// <summary>
        /// Get booking by id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("{bookingId}", Name = "GetBookingById")]
        public ActionResult<BookingDTO> GetBookingById(int bookingId)
        {
            return _choiceRepoistory.GetAllBookings(bookingId).FirstOrDefault();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookingId"></param>
        /// <param name="bookingPutViewModel"></param>
        /// <returns></returns>
        [HttpPut("{bookingId}")]
        public IActionResult UpdateBooking(int bookingId, [FromBody] BookingViewModel bookingPutViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (bookingPutViewModel == null)
                return BadRequest();

            var booking = _choiceRepoistory.GetById<Booking>(bookingId);

            if (booking == null)
            {
                return BadRequest();
            }

            var allBookingRegionInDb = _choiceRepoistory.GetAll<BookingRegion>().Where(x => x.BookingId == booking.BookingId).ToList();
            if (allBookingRegionInDb != null)
            {
                foreach (var bookingRegionDetail in allBookingRegionInDb)
                {
                    _choiceRepoistory.Remove<BookingRegion>(bookingRegionDetail);
                }
            }

            foreach (var item in bookingPutViewModel.RegionIds)
            {
                BookingRegion bookingRegion = new BookingRegion();
                var region = _choiceRepoistory.GetById<Region>(item);
                bookingRegion.BookingId = booking.BookingId;
                bookingRegion.RegionId = region.RegionId;
                _choiceRepoistory.Attach(bookingRegion);
            }


            var allBookingRoomInDb = _choiceRepoistory.GetAll<BookingRoom>().Where(x => x.BookingId == booking.BookingId).ToList();
            if (allBookingRoomInDb != null)
            {
                foreach (var bookingRoom in allBookingRoomInDb)
                {
                    var tableSets = _choiceRepoistory.GetAll<TableSet>().Where(x => x.TableSetId == bookingRoom.TableSet.TableSetId).ToList();
                    foreach (var tableSet in tableSets)
                    {
                        _choiceRepoistory.Remove<TableSet>(tableSet);
                    }
                    _choiceRepoistory.Remove<BookingRoom>(bookingRoom);
                }
            }

            foreach (var item in bookingPutViewModel.BookingRoomViewModel)
            {
                TableSet tableSet = new TableSet()
                {
                    LastModified = item.TableSetViewModel.LastModified,
                    LastModifiedBy = item.TableSetViewModel.LastModifiedBy,
                    TableSetName = item.TableSetViewModel.TableSetName,
                };

                BookingRoom bookingRoom = new BookingRoom()
                {
                    FromDate = item.FromDate,
                    LocationAttraction = item.LocationAttraction,
                    NumberOfRooms = item.NumberOfRooms,
                    PerPerson = item.PerPerson,
                    TableSet = tableSet,
                    ToDate = item.ToDate,
                    BookingId = booking.BookingId
                };

                _choiceRepoistory.Attach(bookingRoom);
            }


            //_choiceRepoistory.Complete();
            booking.PartnerId = bookingPutViewModel.PartnerId;
            booking.ArrivalDateTime = bookingPutViewModel.ArrivalDateTime;
            booking.BookingAndStatusId = bookingPutViewModel.BookingAndStatusId;
            booking.CampaignId = bookingPutViewModel.CampaignId;
            booking.CancellationReasonId = bookingPutViewModel.CancellationReasonId;
            booking.CauseOfRemovalId = bookingPutViewModel.CauseOfRemovalId;
            booking.ContactPersonId = bookingPutViewModel.ContactPersonId;
            booking.CustomerId = bookingPutViewModel.CustomerId;
            booking.DepartDateTime = bookingPutViewModel.DepartDateTime;
            booking.FlexibleDates = bookingPutViewModel.FlexibleDates;
            booking.FlowId = bookingPutViewModel.FlowId;
            booking.InternalHistory = bookingPutViewModel.InternalHistory;
            booking.LeadOfOriginId = bookingPutViewModel.LeadOfOriginId;
            booking.MailLanguageId = bookingPutViewModel.MailLanguageId;
            booking.ParticipantTypeId = bookingPutViewModel.ParticipantTypeId;
            booking.PartnerTypeId = bookingPutViewModel.PartnerTypeId;
            booking.PurposeId = bookingPutViewModel.PurposeId;
            booking.TableTypeId = bookingPutViewModel.TableTypeId;

            // First delete all existing booking arrangement type
            var allBookingArrangementTypeInDb = _choiceRepoistory.GetAll<BookingArrangementType>().Where(x => x.BookingId == booking.BookingId).ToList();
            if (allBookingArrangementTypeInDb != null)
            {
                foreach (var bookingArrangement in allBookingArrangementTypeInDb)
                {
                    _choiceRepoistory.Remove<BookingArrangementType>(bookingArrangement);
                }
            }


            // First delete all existing booking BookingAlternativeService
            var allBookingAlternativeServiceInDb = _choiceRepoistory.GetAll<BookingAlternativeService>().Where(x => x.BookingId == booking.BookingId).ToList();
            if (allBookingAlternativeServiceInDb != null)
            {
                foreach (var bookingAlternativeService in allBookingAlternativeServiceInDb)
                {
                    _choiceRepoistory.Remove<BookingAlternativeService>(bookingAlternativeService);
                }
            }


            foreach (var item in bookingPutViewModel.BookingArrangementTypeViewModel)
            {
                BookingArrangementType bookingArrangementType = new BookingArrangementType()
                {
                    BookingId = booking.BookingId,
                    FromDate = item.FromDate,
                    NumberOfParticipants = item.NumberOfParticipants,
                    ServiceCatalogId = item.ServiceCatalogId,
                    ToDate = item.ToDate
                };

                _choiceRepoistory.Attach(bookingArrangementType);
            }


            foreach (var item in bookingPutViewModel.BookingAlternativeServiceViewModel)
            {
                BookingAlternativeService bookingAlternativeService = new BookingAlternativeService()
                {
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    Description = item.Description,
                    LastModifiedBy = item.LastModifiedBy,
                    NumberOfPieces = item.NumberOfPieces,
                    BookingId = booking.BookingId,
                    LastModified = item.LastModified,

                };

                _choiceRepoistory.Attach(bookingAlternativeService);
            }
            _choiceRepoistory.Complete();

            return NoContent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookingViewModel"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CreateBooking([FromBody] BookingViewModel bookingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (bookingViewModel == null)
                return BadRequest();

            Booking newlyCreatedBooking = _mapper.Map<BookingViewModel, Booking>(bookingViewModel);
            _choiceRepoistory.Attach<Booking>(newlyCreatedBooking);
            //_choiceRepoistory.SetBookings(newlyCreatedBooking);
            _choiceRepoistory.Complete();

            for (int i = 0; i <bookingViewModel.Partners.Count; i++)
            {
                // This is for dummy data only
                var procedureReviewTypeId = _choiceRepoistory.GetAll<ProcedureReviewType>().FirstOrDefault().ProcedureReviewTypeId;
                Procedure procedure = new Procedure()
                {

                    BookingId = newlyCreatedBooking.BookingId,
                    PartnerId = bookingViewModel.Partners[0].PartnerId,
                    CustomerId = bookingViewModel.CustomerId,
                    CauseOfRemovalId = bookingViewModel.CauseOfRemovalId,
                    ProcedureReviewTypeId = procedureReviewTypeId,
                    ProcedureName = "Default Procedure Name",
                    LastModified = DateTime.Now,
                    LastModifiedBy = "Default state"
                };

                _choiceRepoistory.Attach<Procedure>(procedure);
                CenterType centerType = _choiceRepoistory.GetAll<CenterType>().FirstOrDefault();
                //PartnerType partnerType = _choiceRepoistory.GetAll<PartnerType>().FirstOrDefault();
                _choiceRepoistory.Complete();
                ProcedureInfo procedureInfo = new ProcedureInfo()
                {
                    ProcedureId = procedure.ProcedureId,
                    CenterTypeId = centerType.CenterTypeId,
                    PartnerId = bookingViewModel.Partners[0].PartnerId,
                    Reply = "Default Reply",
                    Chat = "Default Chat",
                    Comment = "Default Comment",
                    EmailOffer = "Default Email offer",
                    Price = "9.9",
                };
                _choiceRepoistory.Attach<ProcedureInfo>(procedureInfo);
            }
            _choiceRepoistory.Complete();
            foreach (var item in bookingViewModel.BookingRoomViewModel)
            {
                TableSet tableSet = new TableSet()
                {
                    LastModified = item.TableSetViewModel.LastModified,
                    LastModifiedBy = item.TableSetViewModel.LastModifiedBy,
                    TableSetName = item.TableSetViewModel.TableSetName,
                };

                BookingRoom bookingRoom = new BookingRoom()
                {
                    FromDate = item.FromDate,
                    LocationAttraction = item.LocationAttraction,
                    NumberOfRooms = item.NumberOfRooms,
                    PerPerson = item.PerPerson,
                    TableSet = tableSet,
                    ToDate = item.ToDate,
                    BookingId = newlyCreatedBooking.BookingId
                };

                _choiceRepoistory.Attach(bookingRoom);
            }
            _choiceRepoistory.Complete();
            foreach (var item in bookingViewModel.BookingArrangementTypeViewModel)
            {
                BookingArrangementType bookingArrangementType = new BookingArrangementType()
                {
                    BookingId = newlyCreatedBooking.BookingId,
                    FromDate = item.FromDate,
                    NumberOfParticipants = item.NumberOfParticipants,
                    ServiceCatalogId = item.ServiceCatalogId,
                    ToDate = item.ToDate
                };

                _choiceRepoistory.Attach(bookingArrangementType);

            }
            //_choiceRepoistory.Complete();
            foreach (var item in bookingViewModel.BookingAlternativeServiceViewModel)
            {
                BookingAlternativeService bookingAlternativeService = new BookingAlternativeService()
                {
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    Description = item.Description,
                    LastModifiedBy = item.LastModifiedBy,
                    NumberOfPieces = item.NumberOfPieces,
                    BookingId = newlyCreatedBooking.BookingId,
                    LastModified = item.LastModified,

                };

                _choiceRepoistory.Attach(bookingAlternativeService);

            }
            _choiceRepoistory.Complete();


            foreach (var item in bookingViewModel.RegionIds)
            {
                BookingRegion bookingRegion = new BookingRegion();
                var region = _choiceRepoistory.GetById<Region>(item);
                bookingRegion.BookingId = newlyCreatedBooking.BookingId;
                bookingRegion.RegionId = region.RegionId;
                _choiceRepoistory.Attach(bookingRegion);
            }

            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetBookingById", new { bookingId = newlyCreatedBooking.BookingId }, newlyCreatedBooking);
        }

    }
}