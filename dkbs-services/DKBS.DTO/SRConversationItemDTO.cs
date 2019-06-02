using System;

namespace DKBS.DTO
{
    public class SRConversationItemDTO
    {
        public int SRConversationItemId { get; set; }
        public string SRConversationTitle { get; set; }
        public string ConversationMessage { get; set; }
        public string Sender { get; set; }
        public string CcAddress { get; set; }
        public BookingDTO BookingDTO { get; set; }
        public int ConversationMessageId { get; set; }
        public string Reciever { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
