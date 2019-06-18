using DKBS.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.Domain
{


    public class PartnerEmployeeCRMService
    {
        private string UpdateUrl = "https://dkbsdev.crm4.dynamics.com/api/data/v9.1/niq_update_partner_contact";
        private string CreateUrl = "https://dkbsdev.crm4.dynamics.com/api/data/v9.1/niq_create_partner_contact";
        private CRMPartnerEmployeeDTO GetCreateCrmPartnerEmployeeDto(PartnerEmployee partnerEmployee)
		{
		    CRMPartnerEmployeeDTO cRMPartnerEmployeeDTO = new CRMPartnerEmployeeDTO
            {
                first_name = partnerEmployee.FirstName,
                last_name = partnerEmployee.LastName,
                email_address = partnerEmployee.Email,
                telephone = partnerEmployee.TelePhoneNumber,
                // In future we have to get the account Id from Partner
                parent_customer_id = partnerEmployee.CrmPartnerAccountId,
                partner_contact_id = partnerEmployee.PESharePointId,
                job_title = partnerEmployee.JobTitle,
                mail_group = partnerEmployee.MailGroup,

            };
            return cRMPartnerEmployeeDTO;

        }
		
  		private CRMPartnerEmployeeUpdateDTO GetUpdateCrmPartnerEmployeeDto(PartnerEmployee partnerEmployee)
		{
            CRMPartnerEmployeeUpdateDTO cRMPartnerEmployeeUpdateDTO = new CRMPartnerEmployeeUpdateDTO
            {
                first_name = partnerEmployee.FirstName,
                last_name = partnerEmployee.LastName,
                email_address = partnerEmployee.Email,
                telephone = partnerEmployee.TelePhoneNumber,
                // In future we have to get the account Id from Partner
                // parent_customer_id = checkPartnerIdinDb.CrmPartnerAccountId,
                partner_contact_id = partnerEmployee.PESharePointId,
                job_title = partnerEmployee.JobTitle,
                mail_group = partnerEmployee.MailGroup,

            };
            return cRMPartnerEmployeeUpdateDTO;


        }
		
		public bool CRMActionTypeGeneric(PartnerEmployee partnerEmployee, string actionType)
        {
            bool result = false;
            string responseString = null;
            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create("https://login.microsoftonline.com/%7B4341b00e-adab-4fc1-92bd-0167af58f34b%7D/oauth2/token");
            tokenRequest.Method = "POST";
            string postData = "grant_type=+client_credentials&resource=https://dkbsdev.crm4.dynamics.com&client_id=9d575b22-612f-4d84-a8c1-38de9e26846a&client_secret=Q/AR?QvGkLB@06[hQUU6LNouQKK9Fuec";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            tokenRequest.ContentType = "application/x-www-form-urlencoded";
            tokenRequest.ContentLength = byte1.Length;
            Stream newStream = tokenRequest.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            string jsonString = null;
            HttpWebResponse response = tokenRequest.GetResponse() as HttpWebResponse;
            using (Stream responseStream1 = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream1, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            if (!string.IsNullOrEmpty(jsonString))
            {
                AuthenticationResponse authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(jsonString);
                string accessToken = authenticationResponse.access_token;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; 
                    try
                    {
                        string data = string.Empty;
                        HttpWebRequest request;

                        if (actionType == "CreatePartnerEmployeeCRM")
                        {
                            request = (HttpWebRequest)WebRequest.Create(CreateUrl);
                            data = JsonConvert.SerializeObject(GetCreateCrmPartnerEmployeeDto(partnerEmployee));
                           
                        }
                        else
                        {
                            data = JsonConvert.SerializeObject(GetUpdateCrmPartnerEmployeeDto(partnerEmployee));
                            request = (HttpWebRequest)WebRequest.Create(UpdateUrl);
                        }

                        //request = (HttpWebRequest)WebRequest.Create(URL);
                       // request = (HttpWebRequest)WebRequest.Create(URL);						
						
						request.ContentType = "application/json; charset=utf-8";
                        request.Headers.Add("Authorization", "Bearer " + accessToken);
                        request.Method = "POST";
                        Encoding utfencoding = new UTF8Encoding();
                        byte[] byte2 = utfencoding.GetBytes(data);
                        request.ContentLength = byte2.Length;
                        Stream newStream2 = request.GetRequestStream();
                        newStream2.Write(byte2, 0, byte2.Length);
                        using (HttpWebResponse dataResponse = request.GetResponse() as HttpWebResponse)
                        {
                            StreamReader reader = new StreamReader(dataResponse.GetResponseStream());
                            responseString = reader.ReadToEnd();                          
                        }
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.ToString());
                        //return null;
                    }
                    
                }
                
            }

            //if (responseString == "")
            //{
            //    return true;
            //}
            //else
            //    return false;
            return result;
        }

        public class AuthenticationResponse
        {
            public string token_type { get; set; }
            public string expires_in { get; set; }
            public string ext_expires_in { get; set; }
            public string expires_on { get; set; }
            public string not_before { get; set; }
            public string resource { get; set; }
            public string access_token { get; set; }
        }
		
		
    }
}
