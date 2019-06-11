using DKBS.Domain;
using DKBS.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.Infrastructure.Sharepoint
{
    public interface ISharepointService
    {
        Task<int> InsertCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<int> InsertCustomerContactAsync(ContactPerson contact, Customer customer);
        Task<bool> UpdateCustomerContactAsync(ContactPerson contact, Customer customer);
        Task<int> InsertPartnerAsync(CRMPartner partner);
        Task<bool> UpdatePartnerAsync(CRMPartner partner);
    }
    public class SharepointService : ISharepointService
    {
        private readonly IConfiguration _configuration;
        public string listName = string.Empty;

        public SharepointService(IConfiguration configuration)
        {
            _configuration = configuration;
            listName = _configuration["SharePointListName"];
        }
        public async Task<int> InsertCustomerAsync(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException("Customer can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                foreach (var prop in customer.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(customer);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle(listName);
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Organisation");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("ContentType can't be null.");
                    }

                    string zipCodeItemId = null;
                    string industryCodeItemId = null;

                    if (itemMetaData.Find(x => x.FieldName == "postNumber") != null)
                    {
                        //filter by zipcode item ID
                        List zipsList = web.Lists.GetByTitle("TownZipCodes");
                        CamlQuery query = new CamlQuery();
                        string zipCode = itemMetaData.Find(x => x.FieldName == "postNumber").Value;
                        query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='WorkZip' /><Value Type='Text'>" + zipCode + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
                        ListItemCollection zipColl = zipsList.GetItems(query);
                        context.Load(zipColl);
                        context.ExecuteQuery();
                        if (zipColl.Count == 1)
                        {
                            zipCodeItemId = zipColl[0].Id.ToString() + ";#";
                        }
                    }

                    if (itemMetaData.Find(x => x.FieldName == "industryCode") != null)
                    {
                        string industryTitle = itemMetaData.Find(x => x.FieldName == "industryCode").Value;
                        List industryLst = web.Lists.GetByTitle("IndustryCode");
                        CamlQuery query = new CamlQuery();
                        query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + industryTitle + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
                        ListItemCollection industryColl = industryLst.GetItems(query);
                        context.Load(industryColl);
                        context.ExecuteQuery();
                        if (industryColl.Count == 1)
                        {
                            industryCodeItemId = industryColl[0].Id.ToString() + ";#";
                        }
                    }

                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem newItem = lst.AddItem(itemCreateInfo);
                    newItem["ContentTypeId"] = ct.Id;

                    if (itemMetaData.Find(x => x.FieldName == "companyName") != null)
                    {
                        newItem["Title"] = itemMetaData.Find(x => x.FieldName == "companyName").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "address1") != null)
                    {
                        newItem["Address"] = itemMetaData.Find(x => x.FieldName == "address1").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "address2") != null)
                    {
                        newItem["Address2"] = itemMetaData.Find(x => x.FieldName == "address2").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "postNumber") != null)
                    {
                        newItem["ZipMachingFilter"] = zipCodeItemId;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "country") != null)
                    {
                        string country = itemMetaData.Find(x => x.FieldName == "country").Value;
                        switch (country)
                        {
                            case "Denmark":
                                newItem["Country"] = "1;#";
                                break;
                            case "Germany":
                                newItem["Country"] = "2;#";
                                break;
                            case "Sweden":
                                newItem["Country"] = "3;#";
                                break;
                            case "Andora":
                                newItem["Country"] = "4;#";
                                break;
                            default:
                                break;
                        }
                    }

                    if (itemMetaData.Find(x => x.FieldName == "phoneNumber") != null)
                    {
                        newItem["Phone"] = itemMetaData.Find(x => x.FieldName == "phoneNumber").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        newItem["accountID"] = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "industryCode") != null)
                    {
                        newItem["IndustryCode"] = industryCodeItemId;
                    }
                    newItem.Update();
                    context.ExecuteQuery();
                    return await Task.FromResult<int>(newItem.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException("Customer can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                foreach (var prop in customer.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(customer);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle(listName);
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Organisation");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("ContentType can't be null.");
                    }

                    string zipCodeItemId = null;
                    string industryCodeItemId = null;

                    if (itemMetaData.Find(x => x.FieldName == "postNumber") != null)
                    {
                        //filter by zipcode item ID
                        List zipsList = web.Lists.GetByTitle("TownZipCodes");
                        CamlQuery query = new CamlQuery();
                        string zipCode = itemMetaData.Find(x => x.FieldName == "postNumber").Value;
                        query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='WorkZip' /><Value Type='Text'>" + zipCode + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
                        ListItemCollection zipColl = zipsList.GetItems(query);
                        context.Load(zipColl);
                        context.ExecuteQuery();
                        if (zipColl.Count == 1)
                        {
                            zipCodeItemId = zipColl[0].Id.ToString() + ";#";
                        }
                    }

                    if (itemMetaData.Find(x => x.FieldName == "industryCode") != null)
                    {
                        string industryTitle = itemMetaData.Find(x => x.FieldName == "industryCode").Value;
                        List industryLst = web.Lists.GetByTitle("IndustryCode");
                        CamlQuery query = new CamlQuery();
                        query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + industryTitle + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
                        ListItemCollection industryColl = industryLst.GetItems(query);
                        context.Load(industryColl);
                        context.ExecuteQuery();
                        if (industryColl.Count == 1)
                        {
                            industryCodeItemId = industryColl[0].Id.ToString() + ";#";
                        }
                    }

                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        string accountId = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                        ListItem updatableItem = GetCustomerItem(context, lst, customer.SharePointId.Value);

                        if (updatableItem != null)
                        {
                            if (itemMetaData.Find(x => x.FieldName == "companyName") != null)
                            {
                                updatableItem["Title"] = itemMetaData.Find(x => x.FieldName == "companyName").Value;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "address1") != null)
                            {
                                updatableItem["Address"] = itemMetaData.Find(x => x.FieldName == "address1").Value;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "address2") != null)
                            {
                                updatableItem["Address2"] = itemMetaData.Find(x => x.FieldName == "address2").Value;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "postNumber") != null)
                            {
                                updatableItem["ZipMachingFilter"] = zipCodeItemId;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "country") != null)
                            {
                                string country = itemMetaData.Find(x => x.FieldName == "country").Value;
                                switch (country)
                                {
                                    case "Denmark":
                                        updatableItem["Country"] = "1;#";
                                        break;
                                    case "Germany":
                                        updatableItem["Country"] = "2;#";
                                        break;
                                    case "Sweden":
                                        updatableItem["Country"] = "3;#";
                                        break;
                                    case "Andora":
                                        updatableItem["Country"] = "4;#";
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (itemMetaData.Find(x => x.FieldName == "phoneNumber") != null)
                            {
                                updatableItem["Phone"] = itemMetaData.Find(x => x.FieldName == "phoneNumber").Value;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "industryCode") != null)
                            {
                                updatableItem["IndustryCode"] = industryCodeItemId;
                            }
                            updatableItem.Update();
                            context.ExecuteQuery();
                        }
                    }
                }

                return await Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> InsertCustomerContactAsync(ContactPerson contact, Customer customer)
        {
            try
            {
                if (contact == null)
                {
                    throw new ArgumentNullException("ContactPerson can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                foreach (var prop in contact.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(contact);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle(listName);
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Kontaktperson");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("ContentType can't be null.");
                    }

                    string relatedOrgId = null;
                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        if (customer.SharePointId > 0)
                        {
                            relatedOrgId = customer.SharePointId.ToString() + ";#";
                        }
                    }


                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem newItem = lst.AddItem(itemCreateInfo);
                    newItem["ContentTypeId"] = ct.Id;

                    if (itemMetaData.Find(x => x.FieldName == "firstName") != null || itemMetaData.Find(x => x.FieldName == "lastName") != null)
                    {
                        string firstName = itemMetaData.Find(x => x.FieldName == "firstName") != null ? itemMetaData.Find(x => x.FieldName == "firstName").Value : "";
                        string lastName = itemMetaData.Find(x => x.FieldName == "lastName") != null ? itemMetaData.Find(x => x.FieldName == "lastName").Value : "";
                        string joinedName = firstName + " " + lastName;
                        newItem["Title"] = joinedName;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "email") != null)
                    {
                        newItem["Email"] = itemMetaData.Find(x => x.FieldName == "email").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "telephone") != null)
                    {
                        newItem["Phone"] = itemMetaData.Find(x => x.FieldName == "telephone").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "mobilePhone") != null)
                    {
                        newItem["CellPhone"] = itemMetaData.Find(x => x.FieldName == "mobilePhone").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        string accountId = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                        newItem["accountID"] = accountId;
                        newItem["RelatedOrganization"] = relatedOrgId;
                    }
                    if (itemMetaData.Find(x => x.FieldName == "contactId") != null)
                    {
                        newItem["contactID"] = itemMetaData.Find(x => x.FieldName == "contactId").Value;
                    }
                    newItem.Update();
                    context.ExecuteQuery();
                    return await Task.FromResult<int>(newItem.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> UpdateCustomerContactAsync(ContactPerson contact, Customer customer)
        {
            try
            {
                if (contact == null)
                {
                    throw new ArgumentNullException("ContactPerson can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                itemMetaData.Add(new FieldMataData { FieldName = "contactId", Value = contact.ContactId });
                foreach (var prop in contact.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(contact);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle(listName);
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Kontaktperson");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("ContentType can't be null.");
                    }

                    string relatedOrgId = null;
                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        if (customer.SharePointId > 0)
                        {
                            relatedOrgId = customer.SharePointId.ToString() + ";#";
                        }
                    }

                    ListItem updatableItem = null;
                    if (itemMetaData.Find(x => x.FieldName == "contactId") != null)
                    {
                        string contactId = itemMetaData.Find(x => x.FieldName == "contactId").Value;
                        updatableItem = GetCustomerItem(context, lst, contact.SharePointId.Value);
                    }

                    if (updatableItem != null)
                    {
                        if (itemMetaData.Find(x => x.FieldName == "firstName") != null || itemMetaData.Find(x => x.FieldName == "lastName") != null)
                        {
                            string firstName = itemMetaData.Find(x => x.FieldName == "firstName") != null ? itemMetaData.Find(x => x.FieldName == "firstName").Value : "";
                            string lastName = itemMetaData.Find(x => x.FieldName == "lastName") != null ? itemMetaData.Find(x => x.FieldName == "lastName").Value : "";
                            string joinedName = firstName + " " + lastName;
                            updatableItem["Title"] = joinedName;
                        }

                        if (itemMetaData.Find(x => x.FieldName == "email") != null)
                        {
                            updatableItem["Email"] = itemMetaData.Find(x => x.FieldName == "email").Value;
                        }

                        if (itemMetaData.Find(x => x.FieldName == "telephone") != null)
                        {
                            updatableItem["Phone"] = itemMetaData.Find(x => x.FieldName == "telephone").Value;
                        }

                        if (itemMetaData.Find(x => x.FieldName == "mobilePhone") != null)
                        {
                            updatableItem["CellPhone"] = itemMetaData.Find(x => x.FieldName == "mobilePhone").Value;
                        }

                        if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                        {
                            string accountId = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                            updatableItem["accountID"] = accountId;
                            updatableItem["RelatedOrganization"] = relatedOrgId;
                        }
                        updatableItem.Update();
                        context.ExecuteQuery();
                    }
                }

                return await Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> InsertPartnerAsync(CRMPartner partner)
        {
            try
            {
                if (partner == null)
                {
                    throw new ArgumentNullException("Partner can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                foreach (var prop in partner.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(partner);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle("Partnere");
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    string zipCodeId = null;
                    if (!string.IsNullOrEmpty(itemMetaData.Find(x => x.FieldName == "postNumber").Value))
                    {
                        zipCodeId = GetZipCodeId(context, itemMetaData.Find(x => x.FieldName == "postNumber").Value) + ";#";
                    }
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Partner");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("Partner can't be null.");
                    }
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem newItem = lst.AddItem(itemCreateInfo);
                    newItem["ContentTypeId"] = ct.Id;
                    if (itemMetaData.Find(x => x.FieldName == "partnerName") != null)
                    {
                        newItem["CompanyName"] = itemMetaData.Find(x => x.FieldName == "partnerName").Value;
                    }
                    newItem.Update();
                    context.ExecuteQuery();
                    foreach (FieldMataData field in itemMetaData)
                    {
                        switch (field.FieldName)
                        {
                            case "partnertype":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["PartnerType"] = GetPartnerTypeID(field.Value) + ";#";
                                break;
                            case "accountId":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["accountID"] = field.Value;
                                break;
                            //case "membershipType":
                            //    break;
                            case "partnerName":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["CompanyName"] = field.Value;
                                break;
                            case "cvr":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["VatNumber"] = field.Value;
                                break;
                            case "telefon":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["Phone"] = field.Value + "#@#";
                                break;
                            case "centertype":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["CenterType"] = GetCenterTypeFormatedValue(field.Value);
                                break;
                            case "address1":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["Address1"] = field.Value;
                                break;
                            case "address2":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["Address2"] = field.Value;
                                break;
                            //case "town":
                            case "postNumber":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["ZipMachingFilter"] = zipCodeId;
                                break;
                            case "land":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["Country"] = GetLandId(field.Value);
                                break;
                            //case "stateAgreement":
                            //    break;
                            case "debitornummer":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["DebtorNumber"] = field.Value;
                                break;
                            case "debitornummer2":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["DebtorNumber2"] = field.Value;
                                break;
                            case "regions":
                                //region values have to be sepaprated by => ;#
                                if(!string.IsNullOrEmpty(field.Value))
                                newItem["Region"] = field.Value;
                                break;
                            case "membershipStartDate":
                                //have to be provided in UTC format string
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["MembershipStartDate"] = field.Value;
                                break;
                            case "publicURL":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["PublicURL"] = field.Value;
                                break;
                            case "email":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["EmailAddress"] = field.Value;
                                break;
                            case "website":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["Website"] = field.Value + ", " + field.Value;
                                break;
                            case "panoramView":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["PanoramaView"] = field.Value + ", " + field.Value;
                                break;
                            case "recommandedNPGRT60":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["Recommended"] = field.Value;
                                break;
                            case "qualityAssuredNPSGRD30":
                                if (!string.IsNullOrEmpty(field.Value))
                                    newItem["Quality"] = field.Value;
                                break;
                            default:
                                break;
                        }
                    }
                    newItem.Update();
                    context.ExecuteQuery();
                    return await Task.FromResult<int>(newItem.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> UpdatePartnerAsync(CRMPartner partner)
        {
            try
            {
                if (partner == null)
                {
                    throw new ArgumentNullException("Partner can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                foreach (var prop in partner.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(partner);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle("Partnere");
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Partner");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("Partner can't be null.");
                    }

                    string zipCodeId = null;
                    if (!string.IsNullOrWhiteSpace( itemMetaData.Find(x => x.FieldName == "postNumber").Value))
                    {
                        zipCodeId = GetZipCodeId(context, itemMetaData.Find(x => x.FieldName == "postNumber").Value) + ";#";
                    }

                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null && partner.SharePointId.HasValue)
                    {
                        ListItem updatableItem = GetPartnerItem(context, lst, partner.SharePointId.Value.ToString());

                        if (updatableItem != null)
                        {
                            foreach (FieldMataData field in itemMetaData)
                            {
                                switch (field.FieldName)
                                {
                                    case "accountId":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["accountID"] = field.Value;
                                        break;
                                    case "partnertype":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["PartnerType"] = GetPartnerTypeID(field.Value) + ";#";
                                        break;
                                    //case "membershipType":
                                    //    break;
                                    case "partnerName":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["CompanyName"] = field.Value;
                                        break;
                                    case "cvr":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["VatNumber"] = field.Value;
                                        break;
                                    case "telefon":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["Phone"] = field.Value + "#@#";
                                        break;
                                    case "centertype":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["CenterType"] = GetCenterTypeFormatedValue(field.Value);
                                        break;
                                    case "address1":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["Address1"] = field.Value;
                                        break;
                                    case "address2":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["Address2"] = field.Value;
                                        break;
                                    //case "town":
                                    case "postNumber":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["ZipMachingFilter"] = zipCodeId;
                                        break;
                                    case "land":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["Country"] = GetLandId(field.Value);
                                        break;
                                    //case "stateAgreement":
                                    //    break;
                                    case "debitornummer":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["DebtorNumber"] = field.Value;
                                        break;
                                    case "debitornummer2":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["DebtorNumber2"] = field.Value;
                                        break;
                                    case "regions":
                                        //region values have to be sepaprated by => ;#
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["Region"] = field.Value;
                                        break;
                                    case "membershipStartDate":
                                        //have to be provided in UTC format string
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["MembershipStartDate"] = field.Value;
                                        break;
                                    case "publicURL":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["PublicURL"] = field.Value;
                                        break;
                                    case "email":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["EmailAddress"] = field.Value;
                                        break;
                                    case "website":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["Website"] = field.Value + ", " + field.Value;
                                        break;
                                    case "panoramView":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["PanoramaView"] = field.Value + ", " + field.Value;
                                        break;
                                    case "recommandedNPGRT60":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["Recommended"] = field.Value;
                                        break;
                                    case "qualityAssuredNPSGRD30":
                                        if (!string.IsNullOrEmpty(field.Value))
                                            updatableItem["Quality"] = field.Value;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            updatableItem.Update();
                            context.ExecuteQuery();
                        }
                    }
                }

                return await Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private ClientContext GetClientContext()
        {
            ClientContext context = new ClientContext(_configuration["SharePointServerURL"]);
            context.AuthenticationMode = ClientAuthenticationMode.FormsAuthentication;
            context.FormsAuthenticationLoginInfo = new FormsAuthenticationLoginInfo(_configuration["SharePointUserName"], _configuration["SharePointPassword"]);
            context.ExecuteQuery();
            return context;
        }

        private static ListItem GetCustomerItem(ClientContext context, List customersLst, int id)
        {
            ListItem result = null;
            CamlQuery query = new CamlQuery();
            CamlQuery query2 = new CamlQuery();
            query2.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='ID' /><Value Type='Text'>" + id + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='Title'/><FieldRef Name='Address'/><FieldRef Name='Address2'/><FieldRef Name='ZipMachingFilter'/><FieldRef Name='Country'/><FieldRef Name='Phone'/><FieldRef Name='IndustryCode'/></ViewFields></View>";
            ListItemCollection customerColl = customersLst.GetItems(query2);
            context.Load(customerColl);
            context.ExecuteQuery();
            if (customerColl.Count == 1)
            {
                result = customerColl[0];
            }
            return result;
        }

        private static string GetZipCodeId(ClientContext context, string zipCode)
        {
            string result = null;
            List zipsList = context.Web.Lists.GetByTitle("TownZipCodes");
            CamlQuery query = new CamlQuery();
            query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='WorkZip' /><Value Type='Text'>" + zipCode + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
            ListItemCollection zipColl = zipsList.GetItems(query);
            context.Load(zipColl);
            context.ExecuteQuery();
            if (zipColl.Count == 1)
            {
                result = zipColl[0].Id.ToString() + ";#";
            }
            return result;
        }

        private static string GetPartnerTypeID(string partnereTypeTitle)
        {
            string result = null;
            switch (partnereTypeTitle)
            {
                case "Gold":
                    result = "1";
                    break;
                case "Ikke-partner":
                    result = "2";
                    break;
                case "Samarbejdspartner":
                    result = "3";
                    break;
                case "Bronze":
                    result = "4";
                    break;
                case "Silver":
                    result = "5";
                    break;
                case "Deaktiverede partnere":
                    result = "6";
                    break;
                case "Preferred partner":
                    result = "7";
                    break;
                default:
                    break;
            }
            return result;
        }
        private static string GetCenterTypeFormatedValue(string centerTypes)
        {
            string result = null;
            string[] centerTitles = centerTypes.Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < centerTitles.Length; i++)
            {
                if (centerTitles[i] == "Slotte & Herregårde")
                {
                    result = result + "8;#" + centerTitles[i] + ";#";
                }
                if (centerTitles[i] == "Ud i naturen")
                {
                    result = result + "9;#" + centerTitles[i] + ";#";
                }
                if (centerTitles[i] == "Teambuilding & aktiviteter")
                {
                    result = result + "10;#" + centerTitles[i] + ";#";
                }
                if (centerTitles[i] == "Det kulinariske arrangement")
                {
                    result = result + "11;#" + centerTitles[i] + ";#";
                }
                if (centerTitles[i] == "Strand & vand")
                {
                    result = result + "12;#" + centerTitles[i] + ";#";
                }
                if (centerTitles[i] == "Det skæve arrangement")
                {
                    result = result + "13;#" + centerTitles[i] + ";#";
                }
                if (centerTitles[i] == "By & seværdigheder")
                {
                    result = result + "14;#" + centerTitles[i] + ";#";
                }
                if (centerTitles[i] == "Firmafester")
                {
                    result = result + "15;#" + centerTitles[i] + ";#";
                }
            }

            return result;
        }
        private static string GetLandId(string landTitle)
        {
            string result = null;
            switch (landTitle)
            {
                case "Danmark":
                    result = "1;#";
                    break;
                case "UK":
                    result = "2;#";
                    break;
                case "Sverige":
                    result = "3;#";
                    break;
                case "Tyskland":
                    result = "4;#";
                    break;
                case "Norge":
                    result = "5;#";
                    break;
                case "Finland":
                    result = "6;#";
                    break;
                case "Belgien":
                    result = "7;#";
                    break;
                case "USA":
                    result = "8;#";
                    break;
                default:
                    break;
            }
            return result;
        }

        private static ListItem GetPartnerItem(ClientContext context, List customersLst, string accountId)
        {
            ListItem result = null;
            CamlQuery query2 = new CamlQuery();
            query2.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='ID' /><Value Type='Text'>" + accountId + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/><FieldRef Name='accountID'/><FieldRef Name='PartnerType'/><FieldRef Name='CompanyName'/><FieldRef Name='VatNumber'/><FieldRef Name='Phone'/><FieldRef Name='CenterType'/><FieldRef Name='Address1'/><FieldRef Name='Address2'/><FieldRef Name='ZipMachingFilter'/><FieldRef Name='Country'/><FieldRef Name='DebtorNumber'/><FieldRef Name='DebtorNumber2'/><FieldRef Name='Region'/><FieldRef Name='MembershipStartDate'/><FieldRef Name='PublicURL'/><FieldRef Name='EmailAddress'/><FieldRef Name='Website'/><FieldRef Name='PanoramaView'/><FieldRef Name='Recommended'/><FieldRef Name='Quality'/></ViewFields></View>";
            ListItemCollection customerColl2 = customersLst.GetItems(query2);
            context.Load(customerColl2);
            context.ExecuteQuery();
            if (customerColl2.Count == 1)
            {
                result = customerColl2[0];
            }

            return result;
        }

    }

}

