using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Longhaul_BO
{


    public class BO_Employee
    {
        public string Empcd { get; set; }

        public string Password { get; set; }

        public string CustomerCode { get; set; }

        public string Empnm { get; set; }

        public string USERROLE { get; set; }
    }

    public class BO_Message_Recipients_Status
    {
        public string ChennelID { get; set; }
        public string ChennelName { get; set; }
        public string ReadIncomming { get; set; }
        public string Check_Status { get; set; }
        public string msg { get; set; }
    
       
    }

    public class CreateMessage
    {

        public string MobileNO { get; set; }
        public string Message { get; set; }
        public string EntryBy { get; set; }
        public string status { get; set; }
        public string status_date { get; set; }

    }

    public class AllRequests
    {
        public int UID { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string MobileNo { get; set; }
        public string password { get; set; }
        public string retype_pwd { get; set; }
        public string ref_code { get; set; }
        public string insertdate { get; set; }
        public string EntryBy { get; set; }
        public string Approval { get; set; }
        public string ApprovalBy { get; set; }
        public string ApprovalDate { get; set; }


        //Keys Properties 
        public string baseppath { get; set; }
        public string instance { get; set; }
        public string token { get; set; }
        public string remark { get; set; }
        public string approval { get; set; }
        public string approvaldate { get; set; }
        public string channelid { get; set; }
        



    }

    public class BO_Location
    {
        public string Empcd { get; set; }
        public string Locationcode { get; set; }
        public string Locationname { get; set; }
    }
    public class BO_Purpose
    {
        public string Empcd { get; set; }
        public string Purposeid { get; set; }
        public string Purposename { get; set; }
    }

    public class BO_ApprovalRights
    {
        public string RowId { get; set; }
        public string appBy { get; set; }
        public string Branch { get; set; }
        public string Purpose { get; set; }
        public string From_Range { get; set; }
        public string To_Range { get; set; }
        public string From_Days { get; set; }
        public string To_Days { get; set; }
        public string rlavel { get; set; }
        public string EntryBy { get; set; }
        public string EntryDate { get; set; }
    }

    public class Report_users
    {
        public string MobileNo { get; set; }
        public string Message { get; set; }
        public string EntryBy { get; set; }
        public string Entrydate { get; set; }
        public string status { get; set; }
        public string status_date { get; set; }

    }

    public class All_user_RegisterList
    {
        public List<AllRequests> rprt_usrs { get; set; }
        public int totalcount { get; set; }
    }
    public class WhatsapApiKeys
    {
    public string instance_id { get; set; }
    public string token { get; set; } 
    }


   

}
