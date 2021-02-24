using Longhaul_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longhaul_DA
{   
    public class DA_Login
    {
         // public static BO_Employee DA_LoginEmployee(BO_Employee obj)
        public static BO_Employee DA_LoginEmployee(string empcd, string password)
        {
            BO_Employee objEmployee = new BO_Employee();
            DataTable dt = new DataTable();
            string[] param = new string[] { "@Empcd", "@pwd" }; //A786KEY,!nland@123  //K587SAV ,keshav@123
                                                                //  string[] ParamValues = new string[] { obj.Empcd, obj.Password };
            string[] ParamValues = new string[] { empcd, password };
            dt = SQL_Helper.Select("LongHaul..Usp_Admin_login", param, ParamValues, "MySqlConnection");
            if (dt.Rows.Count > 0)
            {
                
                objEmployee = new BO_Employee()
                {
                    Empcd = Convert.ToString(dt.Rows[0]["USERID"]),
                    Password = Convert.ToString(dt.Rows[0]["PWD"]),
                    Empnm = Convert.ToString(dt.Rows[0]["Empnm"]),
                    CustomerCode = Convert.ToString(dt.Rows[0]["CUSTOMERCODE"]),
                    USERROLE = Convert.ToString(dt.Rows[0]["USERROLE"])
                };
                
            }
            return objEmployee;
        }

        public static BO_Message_Recipients_Status DA_MessageRecipientStatus()
        {

            BO_Message_Recipients_Status MSR = new BO_Message_Recipients_Status();
            DataTable dt = new DataTable();
            string[] param = new string[] { "@Flag", "@EntryBy" };
            string[] paramvalues = new string[] { "GetChennelList","ravi"};
            dt = SQL_Helper.Select("LongHaul..usp_WhatAppCustomerData", param, paramvalues, "MySqlConnection");
            if (dt.Rows.Count > 0)
            {
                MSR = new BO_Message_Recipients_Status()
                {
                    ChennelID = Convert.ToString(dt.Rows[0]["ChennelID"]),
                    ChennelName = Convert.ToString(dt.Rows[0]["ChennelName"]),
                    ReadIncomming = Convert.ToString(dt.Rows[0]["ReadIncomming"]),
                  
                };
            }
            //else
            //{
            //    MSR.msg = "Exception Error";
            //}
            return MSR;
        }

        public static List<AllRequests> Allrqsts_users()
        {
            AllRequests AR = new AllRequests();
            DataTable dt = new DataTable();
            string[] param = new string[] { /* "@flag","@EntryBy", "@status_date"*/ };
            string[] paramvalues = new string[] {  /*"", /*"ravi", DateTime.Now.ToString()*/ };
            dt = SQL_Helper.Select("LongHaul..Usp_getAllRequestUsers", param, paramvalues, "MySqlConnection");
            List<AllRequests> li = new List<AllRequests>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    
                        AR = new AllRequests()
                        {
                            username = Convert.ToString(dt.Rows[0]["username"]),
                            email = Convert.ToString(dt.Rows[0]["email"]),
                            MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]),
                            password = Convert.ToString(dt.Rows[0]["password"]),
                            retype_pwd = Convert.ToString(dt.Rows[0]["retype_pwd"]),
                            ref_code = Convert.ToString(dt.Rows[0]["ref_code"]),

                        }; 
                    
                }
                li.Add(AR);
            }



            return li;
        }

        //public static List<BO_Menu> DA_GetMenuData(BO_Menu objec)
        //{
        //    BO_Menu objMenu = new BO_Menu();
        //    List<BO_Menu> listMenu = new List<BO_Menu>();
        //    DataTable dt = new DataTable();
        //    string[] param = new string[] { "@userid" };
        //    string[] ParamValues = new string[] {objec.Userid };
        //    dt = SQL_Helper.Select("LongHaul..Usp_Admin_menu", param, ParamValues, "MySqlConnection");
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            objMenu = new BO_Menu()
        //            {
        //                MenuId = Convert.ToInt32(dr["MenuId"]),
        //                ParentId = Convert.ToInt32(dr["ParentId"]),
        //                MenuText = Convert.ToString(dr["MenuText"]),
        //                MenuUrl = Convert.ToString(dr["MenuUrl"]),
        //                Is_Parent = Convert.ToString(dr["Is_Parent"])
        //            };
        //            listMenu.Add(objMenu);
        //        }
        //    }
        //    return listMenu;
        //}

        public static List<BO_Location> DA_BindLocation()
        {
            BO_Location objlocation = new BO_Location();
            List<BO_Location> listlocation = new List<BO_Location>();
            DataTable dt = new DataTable();
            string[] param = new string[] { };
            string[] ParamValues = new string[] { };
            dt = SQL_Helper.Select("LongHaul..Usp_GetLocations", param, ParamValues, "MySqlConnection");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    objlocation = new BO_Location()
                    {
                        Locationcode = Convert.ToString(dr["LocationCode"]),
                        Locationname = Convert.ToString(dr["LocationName"]),                       
                    };
                    listlocation.Add(objlocation);
                }
            }
            return listlocation;
        }

        public static List<BO_Purpose> DA_BindPurpose()
        {
            BO_Purpose objPurpose = new BO_Purpose();
            List<BO_Purpose> listPurpose = new List<BO_Purpose>();
            DataTable dt = new DataTable();
            string[] param = new string[] { };
            string[] ParamValues = new string[] { };
            dt = SQL_Helper.Select("LongHaul..Usp_GetPurpose", param, ParamValues, "MySqlConnection");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    objPurpose = new BO_Purpose()
                    {
                        Purposeid = Convert.ToString(dr["PurposeId"]),
                        Purposename = Convert.ToString(dr["PurposeName"]),
                    };
                    listPurpose.Add(objPurpose);
                }
            }
            return listPurpose;
        }

        public static string DA_SaveApprovalRights(BO_ApprovalRights obj)
        {
            string[] param = new string[] { "@Mode", "@appBy", "@Branch", "@Purpose", "@From_Range", "@To_Range", "@From_Days", "@To_Days", "@rlavel","@EntryBy" };
            string[] paramValues = new string[] { "INSERT", obj.appBy, obj.Branch,obj.Purpose, obj.From_Range, obj.To_Range, obj.From_Days, obj.To_Days, obj.rlavel,obj.EntryBy};
            string message = SQL_Helper.MessageReturn("USP_InsertUpdateAprovalRights", param, paramValues, "MySqlConnection");
            return message;
        }

        public static string Insert_CreateMessage(CreateMessage obj)
        {
            string[] param = new string[] { "@flag", "@MobieNo","@Message", "@EntryBy" };
            String[] paramValues = new string[] { "Insert", obj.MobileNO,obj.Message,"Ravi"};
            string message = SQL_Helper.MessageReturn("LongHaul..[usp_WhatAppCustomerData]", param, paramValues, "MySqlConnection");
            return message;
        }
        public static string DA_UpdateApprovalRights(BO_ApprovalRights obj)
        {
            string[] param = new string[] { "@Mode", "@Sno", "@appBy", "@Branch","@Purpose", "@From_Range", "@To_Range", "@From_Days", "@To_Days", "@rlavel","@EntryBy" };
            string[] paramValues = new string[] { "UPDATE", obj.RowId, obj.appBy, obj.Branch, obj.Purpose, obj.From_Range, obj.To_Range, obj.From_Days, obj.To_Days, obj.rlavel,obj.EntryBy };
            string message = SQL_Helper.MessageReturn("USP_InsertUpdateAprovalRights", param, paramValues, "MySqlConnection");
            return message;
        }

        public static List<BO_ApprovalRights> DA_BindApprovalRights()
        {
            BO_ApprovalRights obj = new BO_ApprovalRights();
            List<BO_ApprovalRights> list = new List<BO_ApprovalRights>();
            DataTable dt = new DataTable();
            string[] param = new string[] { "@Mode" };
            string[] ParamValues = new string[] { "SELECT" };
            dt = SQL_Helper.Select("LongHaul..USP_InsertUpdateAprovalRights", param, ParamValues, "MySqlConnection");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new BO_ApprovalRights()
                    {
                        RowId = Convert.ToString(dr["Sno"]),
                        appBy = Convert.ToString(dr["appBy"]),
                        Branch = Convert.ToString(dr["Branch"]),
                        Purpose = Convert.ToString(dr["Purpose"]),
                        From_Range = Convert.ToString(dr["From_Range"]),
                        To_Range = Convert.ToString(dr["To_Range"]),
                        From_Days = Convert.ToString(dr["From_Days"]),
                        To_Days = Convert.ToString(dr["To_Days"]),
                        rlavel = Convert.ToString(dr["rlavel"]),
                        EntryBy = Convert.ToString(dr["EntryBy"]),
                        EntryDate = Convert.ToString(dr["EntryDate"]),
                    };
                    list.Add(obj);
                }
            }
            return list;
        }
    }
}
